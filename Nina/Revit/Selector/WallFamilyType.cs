using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nina.Revit
{
    public class WallFamilyType
    {
        public WallType walltype { get; set; }
        public string family { get; set; }
        public string type { get; set; }
        public string key { get; set; }
    }
}
