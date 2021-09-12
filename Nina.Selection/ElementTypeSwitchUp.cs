using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace Nina.Selection
{
    [Transaction(TransactionMode.Manual)]
    public class SwitchUp : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            try
            {
                Autodesk.Revit.UI.Selection.Selection selection = uidoc.Selection;
                //Nina.FamilyType.WallSwitch(uidoc, doc, true);
                Utils.ElementSwitch(uidoc, doc, true);
            }

            catch (System.Exception exp)
            {

                return Autodesk.Revit.UI.Result.Failed;
            }

            return Autodesk.Revit.UI.Result.Succeeded;

        }
    }
}