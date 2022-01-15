using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFmpeg.NET; //used for actually encoding.
using FFmpeg.NET.Events;
using FFMpegCore; //used for FFProbe. Necessary
using Newtonsoft.Json;

namespace Video_Clip_Sharer
{

    public partial class Form1 : Form
    {

        private UISettings uiSettings = new UISettings();
        private string ffmpegDirectory = Directory.GetCurrentDirectory();
        private CancellationTokenSource cancelSource;

        public Form1()
        {


            InitializeComponent();

            //Brings all the pictureBoxes that lay on the video to the front.
            greenRange.BringToFront();
            redRangeStart.BringToFront();
            redRangeEnd.BringToFront();
            pictureBoxBottomCrop.BringToFront();
            pictureBoxLeftCrop.BringToFront();
            pictureBoxRightCrop.BringToFront();
            pictureBoxTopCrop.BringToFront();
            onBoot();
        }

        async private void onBoot()
        {
            //Should check for ffmpeg/ffprobe binaries before allowing anything to be loaded.
            populateVideoList(""); //await loadTempJson();
            //await checkForFFmpeg();
            this.Size = new Size(this.Size.Width, this.Size.Height - 200);
        }
        /*
        //After someone clicks the textBoxFfmpegBinaries, they get asked to give a directory. Once a direction is given. it checks if the files are there or not. If there is, set data section to that path.
        private void textBoxFFmpegBinaries_Click(object sender, EventArgs e)
        {
            using (var folderChooser = new FolderBrowserDialog())
            {
                DialogResult path = folderChooser.ShowDialog();
                if (path == DialogResult.OK && !string.IsNullOrWhiteSpace(folderChooser.SelectedPath))
                {
                    try
                    {
                        if (!Directory.Exists(folderChooser.SelectedPath)) throw new Exception();
                        //uiSettings = new UISettings(json);
                        string ffmpegExe = Path.Combine(folderChooser.SelectedPath, "ffmpeg.exe");
                        string ffprobeExe = Path.Combine(folderChooser.SelectedPath, "ffprobe.exe");
                        if (!File.Exists(ffmpegExe) || !File.Exists(ffprobeExe)) throw new Exception();
                        this.ffmpegDirectory = folderChooser.SelectedPath;
                        textBoxFFmpegBinaries.Text = folderChooser.SelectedPath;
                        string tempFilePath = Path.Combine(Path.GetTempPath(), "SimpleVideoEditor\\ffmpegPath.json");
                        string jsonUISettings = JsonConvert.SerializeObject(folderChooser.SelectedPath, Formatting.Indented);
                        File.WriteAllText(tempFilePath, jsonUISettings);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Failed to find FFmpeg and FFprobe in given path.");
                    }
                }
            }
        }
        */


        /*
        //First check to see if the Temp path has the ffmpegPath saved as json. If it doesnt or any errors occur, automatically unpack the 2 to the temp path then update the json and data section.
        async public Task checkForFFmpeg()
        {
            try
            {
                string tempSavePath = Path.Combine(Path.GetTempPath(), "SimpleVideoEditor\\ffmpegPath.json");
                if (!File.Exists(tempSavePath)) throw new Exception();

                string json = File.ReadAllText(tempSavePath);

                if (String.IsNullOrEmpty(json)) throw new Exception("ffmpegPath.json content was either null or empty.");
                var directory = JsonConvert.DeserializeObject<dynamic>(json);
                if (!Directory.Exists(directory)) throw new Exception("Given path within ffmpegPath.json doesn't exist.");
                //uiSettings = new UISettings(json);
                string ffmpegExe = Path.Combine(directory, "ffmpeg.exe");
                string ffprobeExe = Path.Combine(directory, "ffprobe.exe");
                if (!File.Exists(ffmpegExe) || !File.Exists(ffprobeExe)) throw new Exception("ffmpeg.exe or ffprobe.exe missing from the saved json file path.");
                this.ffmpegDirectory = directory;
                textBoxFFmpegBinaries.Text = directory;
                textBoxFFmpegBinaries.BackColor = Color.Lime;
            }
            catch (Exception err)
            {
                try
                { 
                    
                    //string tempSavePath = Path.Combine(Path.GetTempPath(), "SimpleVideoEditor\\ffmpegPath.json");
                    string ffmpegExe = Path.Combine(Path.GetTempPath(), "SimpleVideoEditor\\ffmpeg.exe");
                    string ffprobeExe = Path.Combine(Path.GetTempPath(), "SimpleVideoEditor\\ffprobe.exe");
                    if (!File.Exists(ffmpegExe))
                    {
                        using (FileStream fsDst = new FileStream(ffmpegExe, FileMode.CreateNew, FileAccess.Write))
                        {
                            byte[] bytes = Video_Clip_Sharer.Properties.Resources.ffmpeg;

                            fsDst.Write(bytes, 0, bytes.Length);
                        }
                    }

                    if (!File.Exists(ffprobeExe))
                    {
                        using (FileStream fsDst = new FileStream(ffprobeExe, FileMode.CreateNew, FileAccess.Write))
                        {
                            byte[] bytes = Video_Clip_Sharer.Properties.Resources.ffprobe;

                            fsDst.Write(bytes, 0, bytes.Length);
                        }
                    }
                    

                    this.ffmpegDirectory = Path.GetDirectoryName(ffmpegExe);
                    textBoxFFmpegBinaries.Text = Path.GetDirectoryName(ffmpegExe);
                    textBoxFFmpegBinaries.BackColor = Color.Lime;
                    string tempFilePath = Path.Combine(Path.GetTempPath(), "SimpleVideoEditor\\ffmpegPath.json");
                    string jsonUISettings = JsonConvert.SerializeObject(Path.GetTempPath(), Formatting.Indented);
                    File.WriteAllText(tempFilePath, jsonUISettings);
                    
                }
                catch (Exception error)
                {
                    textBoxLog.Text = error.ToString();
                    Console.WriteLine(error.ToString());
                    textBoxFFmpegBinaries.BackColor = Color.Red;
                    MessageBox.Show("Wasn't able to find or produce ffmpeg/ffprobe binaries in temp path.");
                }

            }
        }
        */
        async public Task loadTempJson()
        {
            /*
            try
            {

                string tempSavePath = Path.Combine(Path.GetTempPath(), "SimpleVideoEditor\\lastSave.json");
                if (!File.Exists(tempSavePath)) throw new Exception(); ;
                
                string json = File.ReadAllText(tempSavePath);
                if (String.IsNullOrEmpty(json)) throw new Exception();
                //uiSettings = new UISettings(json);
                var samr = JsonConvert.DeserializeObject<UISettings>(json);
                //JavaScriptSerializer oJS = new JavaScriptSerializer();
                //UISettings samr = oJS.Deserialize<UISettings>(json);
                //UISettings samr = System.Text.Json.JsonSerializer.Deserialize<UISettings>(json);

                Console.WriteLine("\n" + samr.ToString());
                //Console.WriteLine(JsonConvert.SerializeObject(samr, Formatting.Indented));
                if (samr.exportSettings.videoPath == null) { Console.WriteLine("return"); throw new Exception(); }
                Console.Write("initializeUI because samr exists");
                initializeUI(samr);

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
                //MessageBox.Show("Some kind of error");
            }*/
            try
            {
                string tempSavePath = Path.Combine(Path.GetTempPath(), "SimpleVideoEditor\\defaultDirectory.json");
                if (!File.Exists(tempSavePath)) throw new Exception(); ;

                string json = File.ReadAllText(tempSavePath);
                if (String.IsNullOrEmpty(json)) throw new Exception(); ;
                //uiSettings = new UISettings(json);
                var directory = JsonConvert.DeserializeObject<dynamic>(json);
                if (Directory.Exists((string)directory))
                    populateVideoList(((string)directory));
            }
            catch (Exception err)
            {
                //MessageBox.Show("Failed to load last used directory.");
                populateVideoList("");
                return;
            }
        }

        async public Task importVideo(string path)
        {
            //MessageBox.Show(this.ffmpegDirectory);
            FFMpegOptions.Configure(new FFMpegOptions { RootDirectory = this.ffmpegDirectory, TempDirectory = "/tmp" });
            IMediaAnalysis tmp = await FFProbe.AnalyseAsync(path);

            uiSettings.exportSettings.videoData = tmp;
            if (uiSettings.exportSettings.audioTracks.Count == 0)
            {
                uiSettings.exportSettings.audioTracks.Clear();
                foreach (var audioStream in uiSettings.exportSettings.videoData.AudioStreams)
                {
                    uiSettings.exportSettings.audioTracks.Add(new AudioTrack(audioStream));
                }
            }
            if (uiSettings.exportSettings.fps == -1) uiSettings.exportSettings.fps = (double)uiSettings.exportSettings.videoData.PrimaryVideoStream.FrameRate;
            linkLabelVideoPath.Text = Path.GetFullPath(path);
            axVLCPlugin21.playlist.items.clear();
            axVLCPlugin21.playlist.stop();
            var id = axVLCPlugin21.playlist.add(@"file:///" + Path.GetFullPath(path), Path.GetFileName(path), null); //add command line options to try to play all audio streams at once
            axVLCPlugin21.Refresh();
            axVLCPlugin21.playlist.playItem(id);
            axVLCPlugin21.volume = 10;


            uiSettings.exportSettings.scale = new Size(uiSettings.exportSettings.videoData.PrimaryVideoStream.Width, uiSettings.exportSettings.videoData.PrimaryVideoStream.Height);
            uiSettings.exportSettings.outputScale = uiSettings.exportSettings.scale;

            textBoxScaleX.Text = ""; //Set equal to none first so the event will trigger twice. NECESSARY
            textBoxScaleX.Text = uiSettings.exportSettings.videoData.PrimaryVideoStream.Width.ToString();

            return;

        }


        //When we want to initialize the UI using only a video path. Called whenever we want to import a new video.
        async public void initializeUI(string path)
        {
            var tmpUISettings = new UISettings();
            tmpUISettings.exportSettings.videoPath = path;
            initializeUI(tmpUISettings);
        }


        //This is the initializeUI setting that relies on uiSettings. Made specifically to save uiSettings for a later date. Not currently implemented, but is just the overloaded constructor we 
        //can use right now.
        async private void initializeUI(UISettings uiSettings)
        {
            try
            {
                if (!File.Exists(uiSettings.exportSettings.videoPath))
                {
                    throw new Exception();
                }
                this.uiSettings = uiSettings;
                if (this.uiSettings.exportSettings.videoPath != null)
                {

                    await importVideo(uiSettings.exportSettings.videoPath);
                }
                checkBoxShowCrop.Checked = uiSettings.showCrop;
                checkBoxStayInBoundary.Checked = uiSettings.stayInBoundary;
                trackBarFPS.Value = (int)uiSettings.exportSettings.fps;
                trackBarQuality.Value = uiSettings.exportSettings.quality;
                textBoxOutputName.Text = uiSettings.exportSettings.outputName;
                trackBarAudioTrack.Maximum = (int)uiSettings.exportSettings.videoData.AudioStreams.Count;

                if (uiSettings.exportSettings.audioTracks.Count != 0)
                {
                    if (!double.IsNaN(uiSettings.exportSettings.audioTracks.First().volume))
                    {
                        trackBarVolume.Value = uiSettings.exportSettings.audioTracks.First().volume;
                    }

                }

                //After we've finished setting up the ui, we can then visualize a new crop and a new video range bar.
                visualizeCrop(axVLCPlugin21);
                visualizeStart(uiSettings.exportSettings.startTime);
                visualizeEnd(uiSettings.exportSettings.endTime);
            }
            catch (Exception err)
            {
                //textBoxLog.Text = err.ToString();
                advancedConsoleLog(err.ToString());
                Console.WriteLine(err.ToString());
                MessageBox.Show("Error initializing UI.");
            }
        }


        //This actually adjusts the sizes for the Crop picture boxes so that they fit to the video on the UI in the correct way.
        //More complex a function than you'd expect. When you shift the size for the width and height, the width expands RIGHT. and the height expands DOWN.
        async public void visualizeCrop(AxAXVLC.AxVLCPlugin2 axVLCPlugin)
        {
            //move left and bottom crops
            if (uiSettings.exportSettings.crop.cropPosition1.X >= 0 && uiSettings.exportSettings.crop.cropPosition2.X == -1)//Crop 1 set but not crop 2 yet. 
            {
                Point bottomOriginalLocation = new Point(axVLCPlugin.Location.X, axVLCPlugin.Location.Y + axVLCPlugin.Size.Height);
                pictureBoxBottomCrop.Height = bottomOriginalLocation.Y - uiSettings.exportSettings.crop.cropFormPosition1.Y;
                pictureBoxBottomCrop.Location = new Point(bottomOriginalLocation.X, bottomOriginalLocation.Y - pictureBoxBottomCrop.Height);
                pictureBoxLeftCrop.Width = uiSettings.exportSettings.crop.cropFormPosition1.X - pictureBoxLeftCrop.Location.X;

            }
            else if (uiSettings.exportSettings.crop.cropPosition1.X >= 0 && uiSettings.exportSettings.crop.cropPosition2.X > 0)//Crop 2 set, so now we can visualize it
            {
                pictureBoxTopCrop.Height = uiSettings.exportSettings.crop.cropFormPosition2.Y - pictureBoxTopCrop.Location.Y;
                Point rightOriginalLocation = new Point(axVLCPlugin.Location.X + axVLCPlugin.Size.Width, axVLCPlugin.Location.Y);
                pictureBoxRightCrop.Location = new Point(uiSettings.exportSettings.crop.cropFormPosition2.X, pictureBoxRightCrop.Location.Y);
                pictureBoxRightCrop.Width = rightOriginalLocation.X - pictureBoxRightCrop.Location.X;
            }
            else //Otherwise, neither crop position is set, so that means were trying to reset the crop locations and sizes
            {
                Point bottomOriginalLocation = new Point(axVLCPlugin.Location.X, axVLCPlugin.Location.Y + axVLCPlugin.Size.Height);
                Point rightOriginalLocation = new Point(axVLCPlugin.Location.X + axVLCPlugin.Size.Width, axVLCPlugin.Location.Y);
                pictureBoxBottomCrop.Height = 0;
                pictureBoxBottomCrop.Location = bottomOriginalLocation;
                pictureBoxTopCrop.Height = 0;
                pictureBoxLeftCrop.Width = 0;
                pictureBoxRightCrop.Width = 0;
                pictureBoxRightCrop.Location = rightOriginalLocation;
      
            }


        }

        //Function very similar to visualizeCrop. But instead of visualizing, we want to set the outputScale to reflect the crop.
        async public void setScaleFromCrop()
        {

            if (uiSettings.exportSettings.crop.cropPosition1.X >= 0 && uiSettings.exportSettings.crop.cropPosition2.X == -1)//Crop 1 set but not crop 2 yet. 
            {
                return;
            }
            else if (uiSettings.exportSettings.crop.cropPosition1.X >= 0 && uiSettings.exportSettings.crop.cropPosition2.X > 0)//Crop 2 set, so we have a new scale.
            {
                //Sets scale of video to the scaled size of the video
                
                uiSettings.exportSettings.outputScale = new Size(Math.Abs(uiSettings.exportSettings.crop.cropPosition1.X - uiSettings.exportSettings.crop.cropPosition2.X), Math.Abs(uiSettings.exportSettings.crop.cropPosition1.Y - uiSettings.exportSettings.crop.cropPosition2.Y));
                textBoxScaleX.Text = Math.Abs((uiSettings.exportSettings.crop.cropPosition1.X - uiSettings.exportSettings.crop.cropPosition2.X)).ToString();
            }
            else //Otherwise, neither crop position is set, so that means were trying to reset the scale.
            {
                uiSettings.exportSettings.outputScale = uiSettings.exportSettings.scale;
                textBoxScaleX.Text = ""; //Setting it to null will automatically make it populate with the correct values.
            }
            
        }

        async public void updateScaleTextBox()
        {
            try
            {

                if (uiSettings.exportSettings.outputScale.Width == 0) return;
                double width = double.Parse(textBoxScaleX.Text);
                int height = 0;
                if (uiSettings.exportSettings.crop.cropPosition2.X != -1) // If crop exists, use the aspect ratio of the crop
                {
                    height = (int)Math.Floor(width * (double)(uiSettings.exportSettings.crop.cropPosition1.Y - uiSettings.exportSettings.crop.cropPosition2.Y) / (double)(Math.Abs((double)uiSettings.exportSettings.crop.cropPosition1.X - uiSettings.exportSettings.crop.cropPosition2.X)));

                } else //If crop doesnt exist, our aspect ratio should be the same as default.
                {
                    height = (int)Math.Floor(width * (double)uiSettings.exportSettings.scale.Height / (double)uiSettings.exportSettings.scale.Width);
                    
                }
                
                textBoxScaleY.Text = height.ToString();
                if (width == 0 || height == 0) return;
                if (uiSettings.exportSettings.outputScale.Width != width)
                {
                    uiSettings.exportSettings.outputScale = new Size((int)width, height);
                }
            } catch (Exception err) {
                Console.WriteLine(err);
            }
        }

        async public void setStart(double currentTime)
        {

            if (uiSettings.exportSettings.endTime > currentTime || uiSettings.exportSettings.endTime == -1)
            {

                uiSettings.exportSettings.startTime = currentTime;
                visualizeStart(currentTime);
            }
        }
        async public void visualizeStart(double startTime)
        {

            double percent = startTime / (double)axVLCPlugin21.input.length;
            if (startTime == -1) percent = 0; //If startime wasnt defined, then just sset it to be 100% size
            redRangeStart.Width = (int)Math.Floor((double)redRangeStart.MaximumSize.Width * percent); //percentage * max size of red bar gives us 20% of the bar.
        }

        async public void visualizeEnd(double endTime)
        {
            double percent = ((double)(axVLCPlugin21.input.length - endTime) / (double)axVLCPlugin21.input.length);
            if (endTime == -1) percent = 0; //If endtime wasnt defined, then just sset it to be 100% size
            Point originalLocation = new Point(redRangeStart.Location.X + redRangeStart.MaximumSize.Width, redRangeEnd.Location.Y);
            int difference = (int)Math.Floor((double)redRangeEnd.MaximumSize.Width * percent);
            redRangeEnd.Location = new Point(originalLocation.X - difference, redRangeEnd.Location.Y);
            redRangeEnd.Width = difference;
        }



        async public void setEnd(double currentTime)
        {
            //More tricky than setStart because we need to move the bar as we increase the width as well.
            //Original Location has to be hard coded in or else this becomes much more complex.

            if (uiSettings.exportSettings.startTime < currentTime || uiSettings.exportSettings.startTime == -1)
            {

                uiSettings.exportSettings.endTime = currentTime;
                visualizeEnd(currentTime);
            }
        }
        async private void buttonTestPlayVideo_Click(object sender, EventArgs e)
        {
            if (uiSettings.exportSettings.twoPass == true && uiSettings.exportSettings.outputFormat != "gif" && uiSettings.exportSettings.outputFormat != "audio/mp3")
            {
                uiSettings.exportSettings.currentPass = 1;
                advancedConsoleLog(await uiSettings.exportSettings.createFFmpegCommand());
                //textBoxLog.Text = await uiSettings.exportSettings.createFFmpegCommand();
                uiSettings.exportSettings.currentPass = 2;
                //textBoxLog.Text += "\n" + await uiSettings.exportSettings.createFFmpegCommand();
                advancedConsoleLog(await uiSettings.exportSettings.createFFmpegCommand());
                uiSettings.exportSettings.currentPass = 1;
            } else
            {
                advancedConsoleLog(await uiSettings.exportSettings.createFFmpegCommand());
                //textBoxLog.Text = await uiSettings.exportSettings.createFFmpegCommand();
            }
        }


        private void Form1_DragDrop_1(object sender, DragEventArgs e)
        {
            
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files == null) return;
            string file = files[0];


            if (IsMediaFile(file))
            {
                initializeUI(file);
            }
        }
        static bool IsMediaFile(string path)
        {
            string[] mediaExtensions = {
            ".AVI", ".MP4", ".MOV", ".MKV", ".WEBM", ".FLV"
            };
            return -1 != Array.IndexOf(mediaExtensions, Path.GetExtension(path).ToUpperInvariant());
        }

        private void Form1_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void linkLabelVideoPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", "/select," + linkLabelVideoPath.Text.ToString());
        }

        private void buttonSetStart_Click(object sender, EventArgs e)
        {
            if (uiSettings.exportSettings.videoData == null) return;
            setStart(axVLCPlugin21.input.time);

        }

        private void buttonSetEnd_Click(object sender, EventArgs e)
        {
            if (uiSettings.exportSettings.videoData == null) return;
            //Calculates percentage of REMAINING time. (total time - current time) / total time
            setEnd(axVLCPlugin21.input.time);
        }

        async private void populateVideoList(string path)
        {
            Console.WriteLine("populateVideoList: " + path);
            if (Directory.Exists(path) && !String.IsNullOrEmpty(path))
            {
                listViewVideos.Items.Clear();
                string[] mediaExtensions = {
            ".AVI", ".MP4", ".MOV", ".MKV", ".WEBM", ".FLV"
            };
                long timeStart = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                DirectoryInfo objDirectoryInfo = new DirectoryInfo(path);
                List<FileInfo> videoFiles = new List<FileInfo>();
                bool shown = false;
                foreach (var mediaExtension in mediaExtensions)
                {
                    long middleTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    if (middleTime - timeStart > 3000 && shown == false)
                    {
                        MessageBox.Show("This video directory is huge. Consider using a smaller one");
                        shown = true;
                    }
                    if (middleTime - timeStart > 20000)
                    {
                        populateVideoList("");
                        return;
                    }
                    videoFiles.AddRange(objDirectoryInfo.GetFiles("*" + mediaExtension, SearchOption.AllDirectories));
                }

                //long timeMiddle = 
                //MessageBox.Show("After first " + (timeMiddle - timeStart));
                foreach (var file in videoFiles)
                {
                    ListViewItem tmp = new ListViewItem(file.Name.ToString());
                    tmp.SubItems.Add(file.LastWriteTime.ToString());
                    tmp.SubItems.Add((file.Length / 1000000).ToString() + "mb");
                    tmp.SubItems.Add(file.FullName);
                    listViewVideos.Items.Add(tmp);
                }
                long timeEnd = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                //if (timeEnd - timeStart > 3000) MessageBox.Show("This video directory is huge. Consider using a smaller one");
                labelDirectoryLoadTime.Text = "Directory Load Time: " + (timeEnd - timeStart) + "ms.";
                //MessageBox.Show(timeEnd - timeStart + " milliseconds");
                textBoxVideoListPath.Text = path;

                string tempFilePath = Path.Combine(Path.GetTempPath(), "SimpleVideoEditor\\defaultDirectory.json");
                Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
                string jsonUISettings = JsonConvert.SerializeObject(path, Formatting.Indented);
                File.WriteAllText(tempFilePath, jsonUISettings);
            }
            else
            {

                if (path != Environment.GetFolderPath(Environment.SpecialFolder.MyVideos).ToString()) //Stops reloading the function if the argument is the same as the path. This stops infinite looping
                {
                    populateVideoList(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos).ToString());
                }

            }

        }
        private ColumnHeader SortingColumn = null;
        private void listViewVideos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = listViewVideos.Columns[e.Column];
            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            listViewVideos.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            listViewVideos.Sort();

        }

        private void listViewVideos_ItemActivate(object sender, EventArgs e)
        {
            initializeUI(Path.GetFullPath(listViewVideos.SelectedItems[0].SubItems[3].Text));
        }

        async private void axVLCPlugin21_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //If theres no video, then we shouldnt be sending any shortcuts.
            if (uiSettings.exportSettings.videoData == null) return;
            keyCodeEventHandler(e.KeyCode.ToString());
        }

        async private void keyCodeEventHandler(string key)
        {
            switch (key)
            {
                case "C": //set crop point
                    bool truth = await uiSettings.exportSettings.crop.cropHandler(uiSettings, axVLCPlugin21, this.PointToClient(Cursor.Position));
                    if (truth == true)
                    {
                        visualizeCrop(axVLCPlugin21);
                        setScaleFromCrop();
                    }
                    break;
                case "OemOpenBrackets": //[ set start point
                    setStart(axVLCPlugin21.input.time);
                    break;
                case "Oem6": //] set end point
                    setEnd(axVLCPlugin21.input.time);
                    break;
                case "J": //J goto start and pause
                    if (uiSettings.exportSettings.startTime >= 0)
                        axVLCPlugin21.input.time = uiSettings.exportSettings.startTime;
                    else axVLCPlugin21.input.time = 0;

                    axVLCPlugin21.playlist.pause();
                    axVLCPlugin21.playlist.togglePause();
                    break;
                case "L": //L stop the media player
                    if (uiSettings.exportSettings.endTime > 0)
                        axVLCPlugin21.input.time = uiSettings.exportSettings.endTime;
                    else axVLCPlugin21.input.time = 0;

                    axVLCPlugin21.playlist.pause();
                    axVLCPlugin21.playlist.togglePause();
                    break;
                case "Space": //Space so pause media player
                    axVLCPlugin21.playlist.togglePause();
                    break;
                case "G":
                    //MessageBox.Show((await Crop.calculateCursorVideoPosition(uiSettings, axVLCPlugin21, this.PointToClient(Cursor.Position))).ToString());
                    break;
                default:
                    break;

            }
        }

        private void buttonClearCrop_Click(object sender, EventArgs e)
        {
            uiSettings.exportSettings.clearCrop();
            setScaleFromCrop(); //Fixes the scaling if we clear the crop
            visualizeCrop(axVLCPlugin21);
        }


        //Just a function to make the pictureBoxes that make up the crop visible and invisible when we switch the checkBox
        private void checkBoxShowCrop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowCrop.Checked)
            {
                pictureBoxBottomCrop.Visible = true;
                pictureBoxTopCrop.Visible = true;
                pictureBoxLeftCrop.Visible = true;
                pictureBoxRightCrop.Visible = true;
            }
            else
            {
                pictureBoxBottomCrop.Visible = false;
                pictureBoxTopCrop.Visible = false;
                pictureBoxLeftCrop.Visible = false;
                pictureBoxRightCrop.Visible = false;
            }
        }

        private void trackBarFPS_ValueChanged(object sender, EventArgs e)
        {
            labelFPS.Text = trackBarFPS.Value.ToString();
            if (uiSettings.exportSettings.fps != trackBarFPS.Value)
            {
                uiSettings.exportSettings.fps = trackBarFPS.Value;
            }
        }

        private void trackBarQuality_ValueChanged(object sender, EventArgs e)
        {
            labelQuality.Text = trackBarQuality.Value.ToString();
            if (uiSettings.exportSettings.quality != trackBarQuality.Value)
            {
                uiSettings.exportSettings.quality = trackBarQuality.Value;
            }
        }

        //Designed speicifcally for the Stay In Boundary thing. When we get passed the boundary (end time), reset back to the start time.
        private void axVLCPlugin21_MediaPlayerTimeChanged(object sender, AxAXVLC.DVLCEvents_MediaPlayerTimeChangedEvent e)
        {
            if (checkBoxStayInBoundary.Checked) //We only use Stay in Boundary when the check box is checked.
            {
                if (uiSettings.exportSettings.endTime == -1) return; // If the endTime doesnt exist, we dont have any issues where wed need to go back
                if (axVLCPlugin21.input.time < uiSettings.exportSettings.startTime || axVLCPlugin21.input.time > uiSettings.exportSettings.endTime)
                {
                    if (uiSettings.exportSettings.startTime == -1)
                    {
                        axVLCPlugin21.input.time = 0;
                    }
                    else
                    {
                        axVLCPlugin21.input.time = uiSettings.exportSettings.startTime;
                    }
                }
            }
        }

        async private Task setExport(ExportSettings exportSettings)
        {
            Console.WriteLine("\nStarting export...");
            try {
                progressBarRender.Value = 0;
                var inputFile = new MediaFile(exportSettings.videoPath);
                
                var ffmpeg = new Engine(Path.Combine(this.ffmpegDirectory, "ffmpeg.exe"));
                //textBoxLog.Text = this.ffmpegDirectory;
                ffmpeg.Progress += OnProgress;
                ffmpeg.Data += OnData;
                ffmpeg.Error += OnError;
                ffmpeg.Complete += OnComplete;
                cancelSource = new CancellationTokenSource();

                if (uiSettings.exportSettings.twoPass == true && uiSettings.exportSettings.outputFormat != "gif" && uiSettings.exportSettings.outputFormat != "audio/mp3")
                {
                    //First Pass:
                    uiSettings.exportSettings.currentPass = 1;
                    string ffmpegCommand = await uiSettings.exportSettings.createFFmpegCommand();
                    await ffmpeg.ExecuteAsync(ffmpegCommand, cancelSource.Token);
                    //Second Pass:

                    cancelSource = new CancellationTokenSource();
                    uiSettings.exportSettings.currentPass = 2;
                    ffmpegCommand = await uiSettings.exportSettings.createFFmpegCommand();
                    uiSettings.exportSettings.currentPass = 1;
                    await ffmpeg.ExecuteAsync(ffmpegCommand, cancelSource.Token);
                    linkLabelOutputPath.Text = uiSettings.exportSettings.outputName;

                } else
                {
                    string ffmpegCommand = await uiSettings.exportSettings.createFFmpegCommand();
                    await ffmpeg.ExecuteAsync(ffmpegCommand, cancelSource.Token);
                    linkLabelOutputPath.Text = uiSettings.exportSettings.outputName;
                }


            } catch(Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Error while booting ffmpeg.");
            }
            return;


        }

        //Gets the useful progress data. Issue is that it is created on another worker thread, so we cant access the objects generated on the UI. We need to throw all this event data back
        //to the original thread and then interpret that data.
        private void OnProgress(object sender, ConversionProgressEventArgs e)
        {

            //This process is technically on a different thread from the one the forms objects were created on. Because of this, we need to send it back to the main process to access our objects
            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { onProgressMainThread(e); });

        }
        //This function should be run back through the main thread. This is where we can actually interpret the data we receive from the events
        //With this, can calculate lots of other necessary or useful utilities.Ex - progressPercentage, estimatedTimeTillComplete
        private void onProgressMainThread(ConversionProgressEventArgs e)
        {
            //double estimatedTotalFrames = <-- gonna require ton of a code to check the framerate and calculate the total seconds then multiply. 
            try
            {
                int progress = (int)Math.Floor(((double)e.ProcessedDuration.TotalMilliseconds / (double)(uiSettings.exportSettings.getDuration())) * 100);
                double secondsRemaining = ((double)uiSettings.exportSettings.getDuration() / 1000) - (double)e.ProcessedDuration.TotalSeconds;
                double framesRemaining = uiSettings.exportSettings.fps * secondsRemaining;
                //textBoxLog.Text += "\n" + framesRemaining;
                double timeTillComplete = (double)(framesRemaining / (double)e.Fps);
                if (timeTillComplete < 100000)
                {
                    labelRenderTimeToComplete.Text = "Time To Complete: " + TimeSpan.FromSeconds(timeTillComplete).ToString(@"hh\h\:mm\m\:ss\s");
                }
                if (progress >= 99)
                { //Jank cuz technically never equals 100%. onProgress updates even after onComplete gets run for some reason.
                    progressBarRender.Value = 100;
                }
                else
                {
                    progressBarRender.Value = progress;
                }

                labelPercentComplete.Text = progressBarRender.Value.ToString() + "%";


                labelRenderTimeElapsed.Text = "Time Elapsed: " + TimeSpan.FromSeconds(e.ProcessedDuration.TotalSeconds).ToString(@"hh\h\:mm\m\:ss\s");
                labelFileSize.Text = "File Size: " + ((double)e.SizeKb / (double)1000).ToString(".0") + "MBs";
                Console.WriteLine("Bitrate: {0}", e.Bitrate);
                Console.WriteLine("Fps: {0}", e.Fps);
                Console.WriteLine("Frame: {0}", e.Frame);
                Console.WriteLine("ProcessedDuration: {0}", e.ProcessedDuration);
                Console.WriteLine("Size: {0} kb", e.SizeKb);
                Console.WriteLine("TotalDuration: {0}\n", e.TotalDuration); //<---Doesnt work
            } catch (Exception err)
            {
                Console.Write(err);
            }
        }
        private void OnData(object sender, ConversionDataEventArgs e)
        {
            //This process is technically on a different thread from the one the forms objects were created on. Because of this, we need to send it back to the main process to access our objects
            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { onDataMainThread(e); });
            return;
            //Console.WriteLine("[{0} => {1}]: {2}", e.Input.FileInfo.Name, e.Output.FileInfo.Name, e.Data);
        }
        private void onDataMainThread(ConversionDataEventArgs e)
        {

            labelFFmpegConsole.Text = e.Data;
        }

        private void OnComplete(object sender, ConversionCompleteEventArgs e)
        {
            cancelSource.Cancel();
            cancelSource = null;
            progressBarRender.Value = 100;
            labelPercentComplete.Text = progressBarRender.Value.ToString() + "%";
            Console.WriteLine("\nCompleted");

            return;
            Console.WriteLine("Completed conversion from {0} to {1}", e.Input.FileInfo.FullName, e.Output.FileInfo.FullName);
        }

        private void OnError(object sender, ConversionErrorEventArgs e)
        {
            advancedConsoleLog(e.Exception.ToString());
            //textBoxLog.Text = e.Exception.ToString();
            MessageBox.Show("Error when booting FFmpeg");

            Console.WriteLine(e.Exception);
            Console.WriteLine("\nonError");
            return;
            Console.WriteLine("[{0} => {1}]: Error: {2}\n{3}", e.Input.FileInfo.Name, e.Output.FileInfo.Name, e.Exception.ExitCode, e.Exception.InnerException);
        }

        //Event run when we click the "Clip" button. Should interpret the uiSettings and start the export assuming there is a video to be rendered.
        async private void buttonClip_Click(object sender, EventArgs e)
        {

            if (uiSettings.exportSettings.videoPath == null)
            {
                MessageBox.Show("No video being edited right now.");
                return;
            }
            if (cancelSource == null) //checks to see if ffmpeg process already running. Don't want to run if there is already a render going.
            {
                try
                {
                    
                    setExport(uiSettings.exportSettings);
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            }
            else
            {
                MessageBox.Show("One clip is already rendering. Either cancel or wait for it to finish.");
            }
        }
        //Even for when we change the output name text box. Simply changes the export settings to reflex it.
        private void textBoxOutputName_TextChanged(object sender, EventArgs e)
        {
            uiSettings.exportSettings.outputName = textBoxOutputName.Text;
        }


        //Cancels running "render" process
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (cancelSource != null) //Checks to see if a render process is already running. Dont want to cancel if there isnt
            {
                cancelSource.Cancel();
                cancelSource = null;
            }

        }
        //Save last export settings to temp folder so we can load the last instance to the project when we boot. And cancel ffmpeg encoding if being done
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cancel render process
            if (cancelSource != null)
            {
                cancelSource.Cancel();
                cancelSource = null;
            }
            try
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), "SimpleVideoEditor\\lastSave.json");
                Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
                string jsonUISettings = JsonConvert.SerializeObject(uiSettings, Formatting.Indented);
                File.WriteAllText(tempFilePath, jsonUISettings);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
                MessageBox.Show("Failed to save to temp directory for some reason.");
            }

        }

        //Timer made to track the VLC time of a video and update the TimeStamp label to the correct time. Used because VLC time change event is janky and unreliable.
        private void timerVLCTimeStamp_Tick(object sender, EventArgs e)
        {
            if (uiSettings.exportSettings.videoPath != null)
            {
                labelTimestamp.Text = TimeSpan.FromMilliseconds(axVLCPlugin21.input.time).ToString(@"mm\:ss");
            }
            /*if (string.IsNullOrEmpty(ffmpegDirectory))
            {
                textBoxFFmpegBinaries.BackColor = Color.Red;
            }*/
        }


        //When it shifts, we need to make sure we change the audioTrack on VLC and the current audio track that we are editing when we change the volume bar.
        private void trackBarAudioTrack_ValueChanged(object sender, EventArgs e)
        {
            if (uiSettings.exportSettings.audioTracks.Count > 0) //We need to make sure the audioTracks exist or might cause issues.
            {
                axVLCPlugin21.audio.track = trackBarAudioTrack.Value;
                checkBoxSaveAudioTrack.Checked = uiSettings.exportSettings.audioTracks[trackBarAudioTrack.Value - 1].keep;
                checkBoxNoiseReduction.Checked = uiSettings.exportSettings.audioTracks[trackBarAudioTrack.Value - 1].noiseReduce;
                trackBarVolume.Value = uiSettings.exportSettings.audioTracks[trackBarAudioTrack.Value - 1].volume;
                axVLCPlugin21.audio.volume = trackBarVolume.Value;
                labelCurrentAudioTrack.Text = "Current Audio Track: " + axVLCPlugin21.audio.track;
            }
        }

        //Event for when we change the trackBarVolume. Assuming 
        private void trackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            labelVolume.Text = trackBarVolume.Value.ToString();
            if (uiSettings.exportSettings.audioTracks.Count > 0) //We need to make sure the audioTracks exist or might cause issues.
            {
                //axVLCPlugin21.audio.volume = trackBarVolume.Value; <-- im pretty sure spamming changes to this crashes the program.
                uiSettings.exportSettings.audioTracks[trackBarAudioTrack.Value - 1].volume = trackBarVolume.Value;
                
            }

        }

        private void checkBoxSaveAudioTrack_CheckedChanged(object sender, EventArgs e)
        {
            if (uiSettings.exportSettings.audioTracks.Count > 0)
            {
                uiSettings.exportSettings.audioTracks[trackBarAudioTrack.Value - 1].keep = checkBoxSaveAudioTrack.Checked;
            }
        }
        private void checkBoxNoiseReduction_CheckedChanged(object sender, EventArgs e)
        {
            if (uiSettings.exportSettings.audioTracks.Count > 0)
            {
                uiSettings.exportSettings.audioTracks[trackBarAudioTrack.Value - 1].noiseReduce = checkBoxNoiseReduction.Checked;
            }
        }


        //We want to update the videoList to a different path and give the user a choice to 
        private void textBoxVideoListPath_Click(object sender, EventArgs e)
        {
            using (var folderChooser = new FolderBrowserDialog())
            {
                DialogResult path = folderChooser.ShowDialog();
                if (path == DialogResult.OK && !string.IsNullOrWhiteSpace(folderChooser.SelectedPath))
                {
                    populateVideoList(folderChooser.SelectedPath);
                }
            }
        }
        

        //When we click the output path, we want it to show that file to us.
        private void linkLabelOutputPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(linkLabelOutputPath.Text.ToString()))
            {
                Process.Start("explorer.exe", "/select," + linkLabelOutputPath.Text.ToString());
            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //If theres no video, then we shouldnt be sending any shortcuts.
            if (uiSettings.exportSettings.videoData == null) return;
            keyCodeEventHandler(e.KeyCode.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBoxSearchListView_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            uiSettings.exportSettings.outputFormat = comboBoxOutputFormat.SelectedItem.ToString();
        }

        private void textBoxScaleX_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxScaleX.Text))
            {
                textBoxScaleX.Text = uiSettings.exportSettings.scale.Width.ToString();
                return;
            }
            try
            {

                if (!double.IsNaN(double.Parse(textBoxScaleX.Text)))
                {
                    updateScaleTextBox();
                }
            } catch(Exception err)
            {
                Console.WriteLine(err);
            }

            
        }

        private void buttonDev_Click(object sender, EventArgs e)
        {

            if (textBoxLog.Visible)
            {
               this.Size = new Size(this.Size.Width, this.Size.Height - 200);
            } else
            {
                this.Size = new Size(this.Size.Width, this.Size.Height + 200);

            }
            textBoxLog.Visible = !textBoxLog.Visible;
            buttonTestPlayVideo.Visible = !buttonTestPlayVideo.Visible;
        }

        private void buttonAdvancedSettings_Click(object sender, EventArgs e)
        {
            if (this.uiSettings.exportSettings.videoPath != null)
            {
                using (AdvancedSettingsForm advancedSettings = new AdvancedSettingsForm(uiSettings.exportSettings.videoData, uiSettings.exportSettings.startTime, uiSettings.exportSettings.endTime, uiSettings.exportSettings.bitrate, uiSettings.exportSettings.twoPass))
                {
                    advancedSettings.ShowDialog();
                    uiSettings.exportSettings.bitrate = advancedSettings.bitrate;
                    uiSettings.exportSettings.twoPass = advancedSettings.twoPass;
                }

            }

        }

        private void textBoxScaleX_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void trackBarVolume_MouseUp(object sender, MouseEventArgs e)
        {
            //labelVolume.Text = trackBarVolume.Value.ToString();
            if (uiSettings.exportSettings.audioTracks.Count > 0) //We need to make sure the audioTracks exist or might cause issues.
            {
                axVLCPlugin21.audio.volume = trackBarVolume.Value; //<-- im pretty sure spamming changes to this crashes the program.
                //uiSettings.exportSettings.audioTracks[trackBarAudioTrack.Value - 1].volume = trackBarVolume.Value;
            }
        }

        public void advancedConsoleLog(string str)
        {
            advancedConsoleLog(str, Color.DarkSlateGray);
        }
        public void advancedConsoleLog(string str, Color color)
        {
            DateTime time = DateTime.Now;
            if (textBoxLog.TextLength == 0)
            {
                textBoxLog.Select(0, 0);

            }
            else
            {
                textBoxLog.Select(textBoxLog.TextLength, 0);

            }
            textBoxLog.SelectionColor = Color.Black;
            textBoxLog.SelectedText += "[" + time.ToLocalTime().ToString() + "] ";
            textBoxLog.SelectionColor = color;
            textBoxLog.SelectedText += str + Environment.NewLine;


        }
    }


    //Listview comparer class gotten from Microsoft website. Need to update and make my own.
    public class ListViewComparer : System.Collections.IComparer
    {
        private int ColumnNumber;
        private SortOrder SortOrder;

        public ListViewComparer(int column_number, SortOrder sort_order)
        {
            ColumnNumber = column_number;
            SortOrder = sort_order;
        }

        public int Compare(object object_x, object object_y)
        {
            ListViewItem item_x = object_x as ListViewItem;
            ListViewItem item_y = object_y as ListViewItem;
            string string_x;
            if (item_x.SubItems.Count <= ColumnNumber)
            {
                string_x = "";
            }
            else
            {
                string_x = item_x.SubItems[ColumnNumber].Text;
            }

            string string_y;
            if (item_y.SubItems.Count <= ColumnNumber)
            {
                string_y = "";
            }
            else
            {
                string_y = item_y.SubItems[ColumnNumber].Text;
            }

            int result;
            double double_x, double_y;
            if (double.TryParse(string_x, out double_x) &&
                double.TryParse(string_y, out double_y))
            {
                result = double_x.CompareTo(double_y);
            }
            else
            {
                DateTime date_x, date_y;
                if (DateTime.TryParse(string_x, out date_x) &&
                    DateTime.TryParse(string_y, out date_y))
                {

                    result = date_x.CompareTo(date_y);
                }
                else
                {
                    result = string_x.CompareTo(string_y);
                }
            }

            if (SortOrder == SortOrder.Ascending)
            {
                return result;
            }
            else
            {
                return -result;
            }
        }
    }


    }

