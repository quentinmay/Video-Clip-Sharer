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
        public AdvancedSettingsForm()
        {
            InitializeComponent();
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
                -qp 0-51 CAN ONLY BE USED WITH CONSTANT QP above 
            */

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
