using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Clip_Sharer
{
    public partial class AdvancedSettingsForm : Form
    {
        public bitrate bitrate { get; set; }
        public double duration { get; set; }
        FFMpegCore.IMediaAnalysis videoData { get; set; }
        public bool twoPass { get; set; }
        public AdvancedSettingsForm(FFMpegCore.IMediaAnalysis videoData, double startTime, double endTime, bitrate bitrate, bool twoPass)
        {
            InitializeComponent();
            this.bitrate = bitrate;

            this.videoData = videoData;
            this.twoPass = twoPass;
            populateVideoData(videoData, startTime, endTime, bitrate, twoPass);

        }
        private void populateVideoData(FFMpegCore.IMediaAnalysis videoData, double startTime, double endTime, bitrate bitrate, bool twoPass)
        {
            try
            {
                double endTimeTemp = endTime;
                double startTimeTemp = startTime;
                if (endTime == -1) endTimeTemp = videoData.PrimaryVideoStream.Duration.TotalMilliseconds;
                if (startTime == -1) startTimeTemp = 0;
                this.duration = endTimeTemp - startTimeTemp;
                labelVideoLength.Text = "Output Video Length: " + TimeSpan.FromMilliseconds(this.duration).ToString(@"mm\m\:ss\s");


                labelAverageBitrate.Text = "Video Average Bitrate: " + (int)(videoData.PrimaryVideoStream.BitRate/1000) + " kbps";
                labelAudioBitrate.Text = "No Audio Tracks";
                if (videoData.PrimaryAudioStream != null && !double.IsNaN(videoData.PrimaryAudioStream.BitRate))
                {
                    labelAudioBitrate.Text = "Audio Average Bitrate: " + (int)(videoData.PrimaryAudioStream.BitRate/1000) + " kbps";
                }


                textBoxMinBitrate.Text = bitrate.minBitrate.ToString();
                textBoxAvgBitrate.Text = bitrate.avgBitrate.ToString();
                textBoxMaxBitrate.Text = bitrate.maxBitrate.ToString();
                checkBoxTwoPass.Checked = twoPass;

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        /*
        //H264 https://trac.ffmpeg.org/wiki/Encode/H.264


            -Quality: -crf 0-63

            -Variable Bitrate: -q:v 10

            -Constant Bitrate: -b:v 5000k

            -Min Bitrate: -minrate 500k

            -Max Bitrate: -maxrate 8000k

                    //VP9 - -crf 0-63

        //VP9 https://trac.ffmpeg.org/wiki/Encode/VP9
            -Use maxbitrate with no constant bitrate to effectively get VARIABLE bitrate
            -Variable Bitrate:

            -crf 0-63

        //h264 NVENC https://gist.github.com/nico-lab/e1ba48c33bf2c7e1d9ffdd9c1b8d0493 nvenc

            -rc (0 = constant QP) (1 = variable bitrate) (2 = constant bitrate) (3 = variable bitrate with minqp)
            -qp 0-51 CAN ONLY BE USED WITH CONSTANT BITRATE above . DOESNT WORK FOR 2.
            -cq 0-51 CAN BE USED WITH 3, 1.
            -maxrate 500k
            -b:v CAN BE USED WITH 2 (CONSTANT BITRATE).

        Encoder h264_nvenc [NVIDIA NVENC H.264 encoder]:
            General capabilities: delay hardware
            Threading capabilities: none
            Supported hardware devices: cuda cuda d3d11va d3d11va
            Supported pixel formats: yuv420p nv12 p010le yuv444p p016le yuv444p16le bgr0 rgb0 cuda d3d11
        h264_nvenc AVOptions:
          -preset            <int>        E..V...... Set the encoding preset (from 0 to 11) (default medium)
             default         0            E..V......
             slow            1            E..V...... hq 2 passes
             medium          2            E..V...... hq 1 pass
             fast            3            E..V...... hp 1 pass
             hp              4            E..V......
             hq              5            E..V......
             bd              6            E..V......
             ll              7            E..V...... low latency
             llhq            8            E..V...... low latency hq
             llhp            9            E..V...... low latency hp
             lossless        10           E..V......
             losslesshp      11           E..V......
          -profile           <int>        E..V...... Set the encoding profile (from 0 to 3) (default main)
             baseline        0            E..V......
             main            1            E..V......
             high            2            E..V......
             high444p        3            E..V......
          -level             <int>        E..V...... Set the encoding level restriction (from 0 to 51) (default auto)
             auto            0            E..V......
             1               10           E..V......
             1.0             10           E..V......
             1b              9            E..V......
             1.0b            9            E..V......
             1.1             11           E..V......
             1.2             12           E..V......
             1.3             13           E..V......
             2               20           E..V......
             2.0             20           E..V......
             2.1             21           E..V......
             2.2             22           E..V......
             3               30           E..V......
             3.0             30           E..V......
             3.1             31           E..V......
             3.2             32           E..V......
             4               40           E..V......
             4.0             40           E..V......
             4.1             41           E..V......
             4.2             42           E..V......
             5               50           E..V......
             5.0             50           E..V......
             5.1             51           E..V......
          -rc                <int>        E..V...... Override the preset rate-control (from -1 to INT_MAX) (default -1)
             constqp         0            E..V...... Constant QP mode
             vbr             1            E..V...... Variable bitrate mode
             cbr             2            E..V...... Constant bitrate mode
             vbr_minqp       8388612      E..V...... Variable bitrate mode with MinQP (deprecated)
             ll_2pass_quality 8388616      E..V...... Multi-pass optimized for image quality (deprecated)
             ll_2pass_size   8388624      E..V...... Multi-pass optimized for constant frame size (deprecated)
             vbr_2pass       8388640      E..V...... Multi-pass variable bitrate mode (deprecated)
             cbr_ld_hq       8            E..V...... Constant bitrate low delay high quality mode
             cbr_hq          16           E..V...... Constant bitrate high quality mode
             vbr_hq          32           E..V...... Variable bitrate high quality mode
          -rc-lookahead      <int>        E..V...... Number of frames to look ahead for rate-control (from 0 to INT_MAX) (default 0)
          -surfaces          <int>        E..V...... Number of concurrent surfaces (from 0 to 64) (default 0)
          -cbr               <boolean>    E..V...... Use cbr encoding mode (default false)
          -2pass             <boolean>    E..V...... Use 2pass encoding mode (default auto)
          -gpu               <int>        E..V...... Selects which NVENC capable GPU to use. First GPU is 0, second is 1, and so on. (from -2 to INT_MAX) (default any)
             any             -1           E..V...... Pick the first device available
             list            -2           E..V...... List the available devices
          -delay             <int>        E..V...... Delay frame output by the given amount of frames (from 0 to INT_MAX) (default INT_MAX)
          -no-scenecut       <boolean>    E..V...... When lookahead is enabled, set this to 1 to disable adaptive I-frame insertion at scene cuts (default false)
          -forced-idr        <boolean>    E..V...... If forcing keyframes, force them as IDR frames. (default false)
          -b_adapt           <boolean>    E..V...... When lookahead is enabled, set this to 0 to disable adaptive B-frame decision (default true)
          -spatial-aq        <boolean>    E..V...... set to 1 to enable Spatial AQ (default false)
          -spatial_aq        <boolean>    E..V...... set to 1 to enable Spatial AQ (default false)
          -temporal-aq       <boolean>    E..V...... set to 1 to enable Temporal AQ (default false)
          -temporal_aq       <boolean>    E..V...... set to 1 to enable Temporal AQ (default false)
          -zerolatency       <boolean>    E..V...... Set 1 to indicate zero latency operation (no reordering delay) (default false)
          -nonref_p          <boolean>    E..V...... Set this to 1 to enable automatic insertion of non-reference P-frames (default false)
          -strict_gop        <boolean>    E..V...... Set 1 to minimize GOP-to-GOP rate fluctuations (default false)
          -aq-strength       <int>        E..V...... When Spatial AQ is enabled, this field is used to specify AQ strength. AQ strength scale is from 1 (low) - 15 (aggressive) (from 1 to 15) (default 8)
          -cq                <float>      E..V...... Set target quality level (0 to 51, 0 means automatic) for constant quality mode in VBR rate control (from 0 to 51) (default 0)
          -aud               <boolean>    E..V...... Use access unit delimiters (default false)
          -bluray-compat     <boolean>    E..V...... Bluray compatibility workarounds (default false)
          -init_qpP          <int>        E..V...... Initial QP value for P frame (from -1 to 51) (default -1)
          -init_qpB          <int>        E..V...... Initial QP value for B frame (from -1 to 51) (default -1)
          -init_qpI          <int>        E..V...... Initial QP value for I frame (from -1 to 51) (default -1)
          -qp                <int>        E..V...... Constant quantization parameter rate control method (from -1 to 51) (default -1)
          -weighted_pred     <int>        E..V...... Set 1 to enable weighted prediction (from 0 to 1) (default 0)
          -coder             <int>        E..V...... Coder type (from -1 to 2) (default default)
             default         -1           E..V......
             auto            0            E..V......
             cabac           1            E..V......
             cavlc           2            E..V......
             ac              1            E..V......
             vlc             2            E..V......
          -b_ref_mode        <int>        E..V...... Use B frames as references (from 0 to 2) (default disabled)
             disabled        0            E..V...... B frames will not be used for reference
             each            1            E..V...... Each B frame will be used for reference
             middle          2            E..V...... Only (number of B frames)/2 will be used for reference
          -a53cc             <boolean>    E..V...... Use A53 Closed Captions (if available) (default true)
          -dpb_size          <int>        E..V...... Specifies the DPB size used for encoding (0 means automatic) (from 0 to INT_MAX) (default 0)
        */

    

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdvancedSettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxMinBitrate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxMinBitrate.Text))
                {
                    this.bitrate.minBitrate = 0;
                } else
                {
                    int val = int.Parse(textBoxMinBitrate.Text);
                    this.bitrate.minBitrate = val;
                }
            } catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
      
        }

        private void textBoxAvgBitrate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxAvgBitrate.Text))
                {
                    this.bitrate.avgBitrate = 0;
                    labelOutputFileSize.Text = "Expected Output File Size:";
                }
                else
                {
                    int val = int.Parse(textBoxAvgBitrate.Text);
                    this.bitrate.avgBitrate = val;


                    double expectedFileSize = ((((double)this.bitrate.avgBitrate / 8192.0) * (this.duration / 1000.0)) + ((videoData.PrimaryAudioStream != null && !double.IsNaN(videoData.PrimaryAudioStream.BitRate)) ? ((videoData.PrimaryAudioStream.BitRate / 8192000.0) * (this.duration / 1000.0)) : 0));
                    labelOutputFileSize.Text = "Expected Output File Size: " + Math.Round(expectedFileSize, 2).ToString() + "MB";

                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        private void textBoxMaxBitrate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxMaxBitrate.Text))
                {
                    this.bitrate.maxBitrate = 0;
                }
                else
                {
                    int val = int.Parse(textBoxMaxBitrate.Text);
                    this.bitrate.maxBitrate = val;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        private void textBoxMinBitrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxAvgBitrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void textBoxMaxBitrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkBoxTwoPass_CheckedChanged(object sender, EventArgs e)
        {
            this.twoPass = checkBoxTwoPass.Checked;
        }
    }
}
