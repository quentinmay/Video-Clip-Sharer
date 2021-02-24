using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Clip_Sharer
{
    class Crop
    {
        public Point cropPosition1 { get; set; }
        public Point cropFormPosition1 { get; set; }
        public Point cropFormPosition2 { get; set; }
        public Point cropPosition2 { get; set; }
        public Size cropSize { get; set; }


        public Crop()
        {
            cropPosition1 = new Point(-1, -1);
            cropPosition2 = new Point(-1, -1);
            cropFormPosition1 = new Point(-1, -1);
            cropFormPosition2 = new Point(-1, -1);
            cropSize = new Size(-1, -1);
        }
        async public Task<bool> cropHandler(UISettings uiSettings, AxAXVLC.AxVLCPlugin2 axVLCPlugin, Point mousePosition)
        {
            Point cropPoint = await calculateCursorVideoPosition(uiSettings, axVLCPlugin, mousePosition);
            if (cropPoint.X < 0 || cropPoint.Y < 0) return false; //cropPoint is valid and ontop of video.
            if (cropPosition1.X == -1)
            {
                cropPosition1 = cropPoint;
                cropFormPosition1 = mousePosition;

                return true;
            } else if (cropPosition2.X == -1)
            {
                if (cropPoint.X > cropPosition1.X && cropPoint.Y < cropPosition1.Y) //cropPoint.Y < cropPosition1.Y actually means that cropPoint has to be HIGHER. 0,0 is at top left of screen. 
                {
                    
                    cropPosition2 = cropPoint;
                    cropFormPosition2 = mousePosition;
                    generateCropSize();
                    
                    
                    return true;
                }
            } else
            {
                Console.WriteLine("Crop has already been set. Clear crop to set a new one.");
            }

            return false;
        }


        //Does this to get the calculate the correct cropSize BOX dimensions from the positions given. This is used by ffmpeg when rendering.
        async public void generateCropSize()
        {
            cropSize = new Size(cropPosition2.X - cropPosition1.X, cropPosition1.Y - cropPosition2.Y);
            return;
        }
        async static public Task<Point> calculateCursorVideoPosition(UISettings uiSettings, AxAXVLC.AxVLCPlugin2 axVLCPlugin, Point mousePosition)
        {
            Point relativeMousePosition = await calculateRelativeMouse(uiSettings, axVLCPlugin, mousePosition);
            Point bestFitVideoSize = await calculateBestFitVideoSize(uiSettings, axVLCPlugin, mousePosition);

            double scale = (double)uiSettings.exportSettings.videoData.PrimaryVideoStream.Width / (double)bestFitVideoSize.X;

            Point absoluteMousePosition = new Point((int)Math.Floor((double)relativeMousePosition.X * scale), /*uiSettings.exportSettings.videoData.PrimaryVideoStream.Height -*/ (int)Math.Floor((double)relativeMousePosition.Y * scale));

            //Do quick doublecheck to make sure we are within bounds of the original video.
            if (absoluteMousePosition.X < 0 || absoluteMousePosition.X > (int)uiSettings.exportSettings.videoData.PrimaryVideoStream.Width ||
                absoluteMousePosition.Y < 0 || absoluteMousePosition.Y > (int)uiSettings.exportSettings.videoData.PrimaryVideoStream.Height) return new Point(-1, -1);

            return absoluteMousePosition;
        }

        async public static Task<Point> calculateRelativeMouse(UISettings uiSettings, AxAXVLC.AxVLCPlugin2 axVLCPlugin, Point mousePosition)
        {
            //use vlc media player position and aspect ratio.
            if (uiSettings.exportSettings.videoData == null) return new Point(-1, -1);
            Size size = axVLCPlugin.Size;
            Point location = axVLCPlugin.Location;

            //get greatest common divisor and get both to their lowest aspect ratios


            /* Test cases:
            If frameAspectRatio solved out is > videoAspectRatio solved out, then 
            16x9 1x1 fits to the Y 1.78 - 1
            16x9 16x10 fits to the Y 1.78 - 1.6
            16x9 16x8 fits to the X 1.78 - 2
            16x9 16x9 fit to both. 1.78 - 1.78
            1X1 16.9 fit to the X 1 - 1.78
            */
            Point bestFitVideoSize = await calculateBestFitVideoSize(uiSettings, axVLCPlugin, mousePosition);

            //Generates the size of the black bars that would be displayed on the VLC. Lets us know where the video position actually starts.
            int horizontalBlackBars = (int)Math.Floor(((double)axVLCPlugin.Size.Width - (double)bestFitVideoSize.X) / 2);
            if (horizontalBlackBars < 0) horizontalBlackBars = 0;
            int verticalBlackBars = (int)Math.Floor(((double)axVLCPlugin.Size.Height - (double)bestFitVideoSize.Y) / 2);
            if (verticalBlackBars < 0) verticalBlackBars = 0;

            Point videoPosition = new Point(axVLCPlugin.Location.X + horizontalBlackBars, axVLCPlugin.Location.Y + verticalBlackBars);

            //Now use all of this info to generate the mousePosition on the REAL video.
            //Mouse not in bounds of the UI video.
            if (mousePosition.X < (axVLCPlugin.Location.X + horizontalBlackBars) || mousePosition.X > (axVLCPlugin.Location.X + bestFitVideoSize.X + horizontalBlackBars)) return new Point(-1, -1);
            if (mousePosition.Y < (axVLCPlugin.Location.Y + verticalBlackBars) || mousePosition.Y > (axVLCPlugin.Location.Y + bestFitVideoSize.Y + verticalBlackBars)) return new Point(-1, -1);
            //This relativeMousePosition is the mouse positioning by pixel on the video frame.
            return new Point(mousePosition.X - videoPosition.X, mousePosition.Y - videoPosition.Y);
        }


        //Calculates the approximated BestFitVideoSize that VLC will default to when placing the imported video onto the VLC frame. Necessary because will be different for videos with different aspec ratios than 16x9.
        async public static Task<Point> calculateBestFitVideoSize(UISettings uiSettings, AxAXVLC.AxVLCPlugin2 axVLCPlugin, Point mousePosition)
        {
            Point frameAspectRatio = new Point((int)(axVLCPlugin.Width / greatestCommonDivisor(axVLCPlugin.Size.Width, axVLCPlugin.Size.Height)), (int)(axVLCPlugin.Height / (greatestCommonDivisor(axVLCPlugin.Size.Width, axVLCPlugin.Size.Height))));
            Point videoAspectRatio = new Point((int)((int)uiSettings.exportSettings.videoData.PrimaryVideoStream.Width / greatestCommonDivisor((int)uiSettings.exportSettings.videoData.PrimaryVideoStream.Width, (int)uiSettings.exportSettings.videoData.PrimaryVideoStream.Height)), (int)(uiSettings.exportSettings.videoData.PrimaryVideoStream.Height / (greatestCommonDivisor((int)uiSettings.exportSettings.videoData.PrimaryVideoStream.Width, (int)uiSettings.exportSettings.videoData.PrimaryVideoStream.Height))));
            if (((double)frameAspectRatio.X / (double)frameAspectRatio.Y) == ((double)videoAspectRatio.X / (double)videoAspectRatio.Y)) //Perfect aspect ratio that fits frame.

            {
                return  new Point(axVLCPlugin.Size.Width, axVLCPlugin.Size.Height);
            }
            else if (((double)frameAspectRatio.X / (double)frameAspectRatio.Y) > ((double)videoAspectRatio.X / (double)videoAspectRatio.Y)) //Vertical video. Taller than frame
            {

                //640x360frame 1000x1000video

                //360 = 1000 * z 
                //             360x360
                return new Point((int)Math.Floor((((double)axVLCPlugin.Size.Height * (double)videoAspectRatio.X) / (double)videoAspectRatio.Y)), axVLCPlugin.Size.Height);
            }
            else if (((double)frameAspectRatio.X / (double)frameAspectRatio.Y) < ((double)videoAspectRatio.X / (double)videoAspectRatio.Y)) //Horizontal video. Longer than frame
            {
                return  new Point(axVLCPlugin.Size.Width, (int)Math.Floor((((double)axVLCPlugin.Size.Width * (double)videoAspectRatio.Y) / (double)videoAspectRatio.X)));
            }
            else return new Point(-1, -1);
        }

        //Simple algorithm to find the greatest common divisor from 2 values given.
        public static long greatestCommonDivisor(long x, long y)
        {
            if (y == 0)return x;
            else return greatestCommonDivisor(y, x % y);
        }
    }


}
