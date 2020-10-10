using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

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

