using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Video_Clip_Sharer
{
    class UISettings
    {
        public ExportSettings exportSettings { get; }
        public bool showCrop { get; }
        public bool stayInBoundary { get; }
        //public List<Box> boxes;

        public UISettings()
        {
            this.exportSettings = new ExportSettings();
            this.stayInBoundary = false;
            this.showCrop = true;
        }

        public UISettings(ExportSettings exportSettings)
        {
            this.exportSettings = exportSettings;
            this.stayInBoundary = false;
            this.showCrop = true;
        }

        public UISettings(string json)
        {
            //JsonSerializer.Deserialize(json);
        }
    }
}
