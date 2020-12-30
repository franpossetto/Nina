using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Logging.Core;
using System;

namespace Nina.Selection
{
    [Transaction(TransactionMode.Manual)]
    public class WallByDimension : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                Document doc = commandData.Application.ActiveUIDocument.Document;
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                
                Log.Information.Tool = "Wall By Dimension";
                Log.Information.File = doc.Title;
                Log.Information.Revit = commandData.Application.Application.VersionName;
                Log.Information.UserName = commandData.Application.Application.Username;
                Log.Information.Nina = Settings.Default.Nina;
                Logger.Write(Log.Information);

                XYZ p1 = uidoc.Selection.PickPoint("Pick the first point");
                XYZ p2 = uidoc.Selection.PickPoint("Pick the second point");

                double distance = p1.DistanceTo(p2);

                Nina.Revit.FamilyType.SelectWall(uidoc, doc, distance);


                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch
            {
                message = "Unexpected Exception thrown.";
                
                return Autodesk.Revit.UI.Result.Failed;
            }

        }
    }
}

