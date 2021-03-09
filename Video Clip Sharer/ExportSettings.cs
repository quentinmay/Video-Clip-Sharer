using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFMpegCore;

namespace Video_Clip_Sharer
{
    class ExportSettings
    {
        public string videoPath { get; set; }
        public IMediaAnalysis videoData { get; set; }
        public List<AudioTrack> audioTracks { get; }
        public Crop crop { get; set; }
        public Size reScale { get; }
        public double startTime { get; set; }
        public double endTime { get; set; }
        public int quality { get; set; }
        public double fps { get; set; }
        public string outputName { get; set; }
        public string outputFormat { get; set; }
        public Size scale { get; set; }
        public Size outputScale { get; set; }


        public ExportSettings()
        {
            this.audioTracks = new List<AudioTrack>();
            this.videoPath = null;
            this.videoData = null;
            this.endTime = -1;
            this.startTime = -1;
            this.crop = new Crop();
            this.quality = 10;
            this.fps = -1;
            this.outputName = "";
            this.outputFormat = "h264"; //default to h264
        }

        
        /*
        async public Task<ExportSettings> generateExportSettingsFromJson(string json)
        {
            this.videoData = await FFProbe.AnalyseAsync(json.);
            foreach (var audioStream in this.videoData.AudioStreams)
            {
                this.audioTracks.Add(new AudioTrack(audioStream));
            }


        }*/

        async public void clearCrop()
        {
            this.crop = new Crop();
        }

        async public Task<string> createFFmpegCommand()
        {
            if (this.videoData == null) return "";
            List<string> ffmpegCommandList = new List<string>();

            string input = "-i \"" + this.videoPath + "\"";
            ffmpegCommandList.Add(input);
            //Default code and settings
            //set filter_complex for multiple audio channels
            switch(this.outputFormat)
            {
                case "gif"://http://blog.pkh.me/p/21-high-quality-gif-with-ffmpeg.html use this for generating beter commands meant for gifs.

                    return "";
                    break; 
                default: //any format other than gif. Need to add more 
                    ffmpegCommandList.Add(await this.generateAudioTracksTag());

                    ffmpegCommandList.Add(await this.generateVFTag());

                    ffmpegCommandList.Add(await this.generateQualityTag());

                    ffmpegCommandList.Add(await this.generateStartTag());

                    ffmpegCommandList.Add(await this.generateEndTag());

                    ffmpegCommandList.Add(await this.generateFPSTag());

                    ffmpegCommandList.Add(await this.generateOutputTag());

                    //Removes empty string that would just add extra spaces. Then formats the list as a runnable string command
                    ffmpegCommandList.RemoveAll(s => string.IsNullOrEmpty(s));
                    string ffmpegCommand = String.Join(" ", ffmpegCommandList);
                    return ffmpegCommand;
                    break;
            }

        }

        //Uses the 
        async public Task<string> generateOutputTag()
        {
            string directory = Path.GetDirectoryName(videoPath);
            string fileName = "";
            
            if (String.IsNullOrEmpty(outputName)) {
                fileName = "Clipped-" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + "-" + Path.GetFileName((string)videoData.Path).ToString();
            } else
            {
                fileName = outputName + Path.GetExtension(videoPath);
            }
            this.outputName = Path.Combine(directory, fileName).ToString();
            return "\"" + Path.Combine(directory, fileName).ToString() + "\"";

        }
        async public Task<string> generateFPSTag()
        {

            if (Math.Ceiling(fps) == Math.Ceiling((double)videoData.PrimaryVideoStream.FrameRate)) return ""; //If the FPS doesnt change. We dont want to change fps when include for when outputfps = 29.9 and originalfps = 30
            return "-r " + fps;
        }

        async public Task<string> generateEndTag()
        {
            if (endTime == -1) return "";
            return "-to " + this.endTime / 1000;

        }

        //http://ffmpeg.org/ffmpeg.html reference for setting start and end times
        async public Task<string> generateStartTag()
        {
            if (startTime == -1) return "";
            return "-ss " + this.startTime / 1000;

        }

        //https://trac.ffmpeg.org/wiki/Encode/H.264 reference for quality parameter for h264 encoding specifically
        async public Task<string> generateQualityTag()
        {
            //copy encoding hardcoded in for now. Room still is left for encoding into different formats like h265, nvenc etc, but they also0 have different quality parameters.
            var qualityString = "";
            qualityString = "-crf " + quality; //copy implies that it copys the video encoding format so that we dont reencode into something different.
            return qualityString;

        }

        async public Task<string> generateVFTag()
        {
            string vfString = "";
            if (crop.cropPosition2.X == -1) return "";
            vfString = "-vf crop=" + crop.cropSize.Width + ":" + crop.cropSize.Height + ":" + crop.cropPosition1.X + ":" + crop.cropPosition2.Y;
            return vfString;

        }

        async public Task<string> generateAudioTracksTag()
        {
            int keptAudioTracksCount = 0;
            foreach (var audioTrack in audioTracks) { if (audioTrack.keep == true) keptAudioTracksCount++; }
            string filterComplex = "";
            if (keptAudioTracksCount > 0) filterComplex = "-filter_complex ";


            // WHAT WE REALLY WANT
            //-filter_complex "[0:a:1]volume=.1" For a single track
            //-filter_complex "[0:a:0]volume=.1[a];[0:a:1]volume=1[b];[a][b]amix=inputs=2"
            //https://blog.nytsoi.net/2017/12/31/ffmpeg-combining-audio-tracks follow this blog to keep up and understand the commands
            var index = 97; //ASCII for a. Need since we need to assign alphabetical characters to audio tracks in ffmpeg
            string charsPre = "";

            foreach (var audioTrack in audioTracks)
            {
                if (audioTrack.keep == true)
                {
                    charsPre += "[" + (char)index + "]";
                    filterComplex += ("[0:a:" + (((int)audioTrack.audioStream.Index) - 1) + "]volume=" + ((double)audioTrack.volume / 100));
                    if (keptAudioTracksCount > 1) filterComplex += "[" + (char)index + "];";//if were saving multiple audiotracks, we need to add this onto the end for the amix later

                    index++;
                }
            }
            if (keptAudioTracksCount > 1)
            {
                filterComplex += charsPre + "amix=inputs=" + keptAudioTracksCount;
            }
            //if (filterComplex.Last() == ';') filterComplex = filterComplex.Remove(filterComplex.Length - 1, 1); //removes ending ; if its there. should only occur when using 1 audio track
            return filterComplex;
        }
        public double getDuration()
        {
            double startTime = 0;
            double endTime = (double)videoData.Duration.TotalMilliseconds;
            if (this.startTime != -1) startTime = this.startTime;
            if (this.endTime != -1) endTime = this.endTime;

            return endTime - startTime;

        }

    }
}
