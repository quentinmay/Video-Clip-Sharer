using FFMpegCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//newtonsoft cant SERIALIZE (object -> jsonString) Points properly.
//System.Json cant SERIALIZE dynamic

namespace Video_Clip_Sharer
{
    class AudioTrack
    {
        public AudioStream audioStream;
        public string name;
        public int volume;
        public bool keep;
        public bool noiseReduce;
        public AudioTrack()
        {
            name = "";
            volume = 100;
            keep = true;
            noiseReduce = false;
        }
        public AudioTrack(dynamic audioStream)
        {
            this.audioStream = audioStream;
            this.name = audioStream.Language;
            this.volume = 100;
            this.keep = true;
            this.noiseReduce = false;
        }

    }
}
