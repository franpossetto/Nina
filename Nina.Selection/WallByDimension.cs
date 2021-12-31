using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System;

namespace Nina.Selection
{
    [Transaction(TransactionMode.Manual)]
    public class WallByDimension : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            try
            {

                XYZ p1 = uidoc.Selection.PickPoint("Pick the first point");
                XYZ p2 = uidoc.Selection.PickPoint("Pick the second point");

                double distance = p1.DistanceTo(p2);

                Utils.SelectWall(uidoc, doc, distance);

            }

            catch (System.Exception exp)
            {
               
                return Autodesk.Revit.UI.Result.Failed;
            }

            return Autodesk.Revit.UI.Result.Succeeded;

        }
    }
}