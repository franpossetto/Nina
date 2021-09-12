using Autodesk.Revit.DB;
namespace Nina.Selection.Model
{
    public class WallFamilyType
    {
        public WallType walltype { get; set; }
        public string family { get; set; }
        public string type { get; set; }
        public string key { get; set; }
    }
}