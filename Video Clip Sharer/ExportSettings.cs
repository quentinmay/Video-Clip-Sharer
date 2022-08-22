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
        public bitrate bitrate { get; set; }
        public bool twoPass { get; set; }
        public int currentPass { get; set; }
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
            this.bitrate = new bitrate();
            this.twoPass = false;
            this.currentPass = 1;

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

                    ffmpegCommandList.Add(await this.generateGifVfTag());

                    ffmpegCommandList.Add(await this.generateStartTag());

                    ffmpegCommandList.Add(await this.generateEndTag());

                    ffmpegCommandList.Add(await this.generateOutputTag());

                    return String.Join(" ", ffmpegCommandList); ;
                    break;
                case "audio/mp3":

                    ffmpegCommandList.Add(await this.generateAudioTracksTag());

                    //ffmpegCommandList.Add(await this.generateAudioQualityTag());


                    //ffmpegCommandList.Add(await this.generateGifVfTag());

                    ffmpegCommandList.Add(await this.generateStartTag());

                    ffmpegCommandList.Add(await this.generateEndTag());

                    ffmpegCommandList.Add(await this.generateOutputTag());

                    return String.Join(" ", ffmpegCommandList); ;
                    break;
                case "h264_nvenc":
                case "hevc_nvenc":
                    ffmpegCommandList.Add(await this.generateAudioTracksTag());

                    ffmpegCommandList.Add(await this.generateVFTag());

                    ffmpegCommandList.Add(await this.generateQualityTag());

                    ffmpegCommandList.Add(await this.generateStartTag());

                    ffmpegCommandList.Add(await this.generateEndTag());

                    ffmpegCommandList.Add(await this.generateFPSTag());

                    ffmpegCommandList.Add(await this.generateEncodingTag());

                    ffmpegCommandList.Add(await this.generateOutputTag());


                    return String.Join(" ", ffmpegCommandList);
                    break;
                case "libx264":
                case "libvpx-vp9": //Can just goto default since it works similar to h264
                default: //any format not accounted for. Need to add more 
                    ffmpegCommandList.Add(await this.generateAudioTracksTag());

                    ffmpegCommandList.Add(await this.generateVFTag());

                    ffmpegCommandList.Add(await this.generateQualityTag());

                    ffmpegCommandList.Add(await this.generateStartTag());

                    ffmpegCommandList.Add(await this.generateEndTag());

                    ffmpegCommandList.Add(await this.generateFPSTag());

                    ffmpegCommandList.Add(await this.generateEncodingTag());

                    ffmpegCommandList.Add(await this.generateOutputTag());

                    //Removes empty string that would just add extra spaces. Then formats the list as a runnable string command
                    ffmpegCommandList.RemoveAll(s => string.IsNullOrEmpty(s));

                    return String.Join(" ", ffmpegCommandList);
                    break;
            }

        }
        //Generates the encoding tag that lists the video encoding format we want to output to.
        async public Task<string> generateEncodingTag()
        {
            switch (this.outputFormat)
            {
                case "libx264":
                case "libx265":
                    return "-c:v " + outputFormat;
                    break;
                case "h264_nvenc":
                case "hevc_nvenc":
                    return "-c:v " + outputFormat;
                    break;
                case "libvpx-vp9":
                    return "-c:v " + outputFormat;
                    break;
                default:
                    //return blank because if its blank, we dont want to change the encoding.
                    return "";
                    break;
            }
            //copy encoding hardcoded in for now. Room still is left for encoding into different formats like h265, nvenc etc, but they also0 have different quality parameters.


        }

        async public Task<string> generateGifVfTag()
        {
            string vfString = "";

            //set width to be even because FFMPEG cant handle uneven widths or height.
            int width = this.outputScale.Width;
            if (this.outputScale.Width % 2 == 1) width += 1;

            if (crop.cropPosition2.X != -1)
            { //Generate VF with crop
                vfString = "-vf crop=" + crop.cropSize.Width + ":" + crop.cropSize.Height + ":" + crop.cropPosition1.X + ":" + crop.cropPosition2.Y + ",fps=" + this.fps + ",scale=" + width + ":-2,split[s0][s1];[s0]palettegen[p];[s1][p]paletteuse";
            } else
            { //Generate VF without crop.
                vfString = "-vf fps=" + this.fps + ",scale=" + width + ":-2,split[s0][s1];[s0]palettegen[p];[s1][p]paletteuse";
            }
            return vfString;

        }

        //Uses the 
        async public Task<string> generateOutputTag()
        {
            string directory = Path.GetDirectoryName(videoPath);
            string fileName = "";
            string extension = "";
            switch(this.outputFormat)
            {
                case "gif":
                    extension = ".gif";
                    break;
                case "libvpx-vp9":
                    extension = ".webm";
                    break;
                case "audio/mp3":
                    extension = ".mp3";
                    break;
                case "h264_nvenc":
                case "hevc_nvenc":
                case "libx264":
                case "libx265":
                    extension = ".mp4";
                    break;
                default:
                    extension = Path.GetExtension(videoPath);
                    break;
            }
            
            if (String.IsNullOrEmpty(outputName)) {
                fileName = "Clipped-" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + "-" + Path.GetFileName((string)videoData.Path).ToString();
            } else
            {
                fileName = outputName;
            }
            
            this.outputName = Path.ChangeExtension(Path.Combine(directory, fileName).ToString(), extension); //changes extension after.

            if (twoPass == false || this.outputFormat == "gif" || this.outputFormat == "audio/mp3")
            {
                return "\"" + Path.ChangeExtension(Path.Combine(directory, fileName).ToString(), extension).ToString() + "\"";
            }
            else if (currentPass == 1)
            {
                return "-pass 1 -an -f " + ( (extension.Replace(".", "") == "mkv") ? "matroska" : (extension.Replace(".", "") == "webm") ? "null": extension.Replace(".", "")) + " NUL";

            } else
            {
                return "-pass 2 " + "\"" + Path.ChangeExtension(Path.Combine(directory, fileName).ToString(), extension).ToString() + "\"";

            }

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
            if (this.bitrate.minBitrate == 0 && this.bitrate.avgBitrate == 0 && this.bitrate.maxBitrate == 0) //If we dont use any advanced bitrate options.
            {
                Console.WriteLine(this.outputFormat);
                switch (this.outputFormat)
                {
                    case "h264_nvenc":
                    case "hevc_nvenc":
                        return "-cq " + quality;
                        break;
                    case "libvpx-vp9": //https://trac.ffmpeg.org/wiki/Encode/VP9
                        return "-crf " + quality + " -b:v 0";
                        break;
                    case "libx264":
                    case "libx265":
                    case "Default (try remux)":
                        if (this.twoPass == false)
                        {
                            return "-crf " + quality;
                        } else
                        {
                            return "";
                        }
                        break;
                    default:
                        //copy implies that it copys the video encoding format so that we dont reencode into something different.
                        return "-crf " + quality;
                        break;
                }
            } else //Then we are using min, avg, or max bitrate
            {
                List<string> bitrateAr = new List<string>();
                if (this.bitrate.minBitrate != 0)
                {
                    bitrateAr.Add("-minrate " + this.bitrate.minBitrate + "k");
                }
                if (this.bitrate.avgBitrate != 0)
                {
                    bitrateAr.Add("-b:v " + this.bitrate.avgBitrate + "k");
                }
                if (this.bitrate.maxBitrate != 0)
                {
                    bitrateAr.Add("-maxrate " + this.bitrate.maxBitrate + "k");
                }
                return String.Join(" ", bitrateAr);
            }
            //copy encoding hardcoded in for now. Room still is left for encoding into different formats like h265, nvenc etc, but they also0 have different quality parameters.


        }

        async public Task<string> generateVFTag()
        {
            string vfString = "";

            //set width to be even because FFMPEG cant handle uneven widths or height.
            int width = this.outputScale.Width;
            if (this.outputScale.Width % 2 == 1) width += 1;

            if (crop.cropPosition2.X == -1)
            { //Generate VF without crop.
                vfString = "-vf scale=" + width + ":-2";
            }
            else
            { //Generate VF with crop
                vfString = "-vf crop=" + crop.cropSize.Width + ":" + crop.cropSize.Height + ":" + crop.cropPosition1.X + ":" + crop.cropPosition2.Y + ",scale=" + width + ":-2";
            }
            return vfString;

        }

        async public Task<string> generateAudioTracksTag()
        {
            int keptAudioTracksCount = 0;
            foreach (var audioTrack in audioTracks) { if (audioTrack.keep == true) keptAudioTracksCount++; }
            string filterComplex = "";
            if (keptAudioTracksCount > 0)
            {
                filterComplex = "-filter_complex \"";
            } else //Instead where its <=0, delete all audio tracks.
            {
                filterComplex = "-an";
            }

            // WHAT WE REALLY WANT
            //-filter_complex "[0:a:1]volume=.1" For a single track
            //-filter_complex "[0:a:0]volume=.1[a];[0:a:1]volume=1[b];[a][b]amix=inputs=2"
            //https://blog.nytsoi.net/2017/12/31/ffmpeg-combining-audio-tracks follow this blog to keep up and understand the commands
            var index = 97; //ASCII for a. Need since we need to assign alphabetical characters to audio tracks in ffmpeg
            string charsPre = "";

            //In the case of MOV, its weird. FFprobe counts the audio track index starting from 0 instead of 1. This adjusts for that.
            var indexSubtractor = 1;
            if (audioTracks.Find(track => track.audioStream.Index == 0) != null) indexSubtractor = 0; 

                foreach (var audioTrack in audioTracks)
            {

                if (audioTrack.keep == true)
                {

                    charsPre += "[" + (char)index + "]";
                    filterComplex += "[0:a:" + (((int)audioTrack.audioStream.Index) - indexSubtractor) + "]";

                    if (audioTrack.noiseReduce == true)
                    {
                        filterComplex += "arnndn=m=\\'" + AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "cb.rnnn\\',";
                    }

                    filterComplex += "volume=" + ((double)audioTrack.volume / 100);
                    if (keptAudioTracksCount > 1) filterComplex += "[" + (char)index + "];";//if were saving multiple audiotracks, we need to add this onto the end for the amix later

                    index++;
                }
            }
            if (keptAudioTracksCount > 1)
            {
                filterComplex += charsPre + "amix=inputs=" + keptAudioTracksCount;
            }
            filterComplex += "\"";
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
    public class bitrate {
        public int minBitrate { get; set; }
        public int avgBitrate { get; set; }
        public int maxBitrate { get; set; }

        public bitrate()
        {
            this.minBitrate = 0;
            this.avgBitrate = 0;
            this.maxBitrate = 0;
        }
        public bitrate(int minBitrate, int avgBitrate, int maxBitrate)
        {
            this.minBitrate = minBitrate;
            this.avgBitrate = avgBitrate;
            this.maxBitrate = maxBitrate;
        }
    }

}
