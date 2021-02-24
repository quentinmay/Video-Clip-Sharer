using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Clip_Sharer
{
    class Box
    {
        public Point boxPosition;
        public Point boxSize;
        public Color boxColor;



        async static public Task<Point> calculateUIPosition(Form1 form, AxAXVLC.AxVLCPlugin2 axVLCPlugin)
        {
            //Task 1. Get video location of (50, 80)
            //boxPosition = (50, 80) example
            //use vlc media player position and aspect ratio.
            //form.currentVideo.PrimaryVideoStream.Width
            //Video_Clip_Sharer.Form1.ActiveForm.axVLC
            //form.axVLC
            Size size = axVLCPlugin.Size; 
            Point location = axVLCPlugin.Location;
            Console.WriteLine(size);
            Console.WriteLine(location);
            return new Point(0, 0);
        }

        public static long greatestCommonDivisor(long x, long y)
        {
            if (y == 0)
            {
                return x;
            } else
            {
                return greatestCommonDivisor(y, x % y);
            }
        }

    }
}
