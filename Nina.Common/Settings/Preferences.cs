using System;
using System.Collections.Generic;
using System.Text;

namespace Nina.Common
{
    public class Preferences
    {
        public string Nina { get; set; }
        public string LogDirectory { get; set; }
        public bool CreateWallType { get; set; }
        public string WallTypePrefix { get; set; }
        public double ViewRangeStep { get; set; }
        public string WallTypeSelected { get; set; }
        public double Tolerance { get; set; }
        public bool ViewRangeTopBottom { get; set; }

        public Preferences()
        {
            Nina = "Nina_";
            LogDirectory = "";
            CreateWallType = false;
            WallTypePrefix = "";
            ViewRangeStep = 0.1;
            WallTypeSelected = "";
            Tolerance = 0.1;
            ViewRangeTopBottom = false;
        }
        public Preferences(Preferences savedSettings)
        {
            Nina = savedSettings.Nina;
            LogDirectory = savedSettings.LogDirectory;
            CreateWallType = savedSettings.CreateWallType;
            WallTypePrefix = savedSettings.WallTypePrefix;
            ViewRangeStep = savedSettings.ViewRangeStep;
            WallTypeSelected = savedSettings.WallTypeSelected;
            Tolerance = savedSettings.Tolerance;
            ViewRangeTopBottom = savedSettings.ViewRangeTopBottom;
        }
    }
}
