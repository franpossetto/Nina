using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace Nina.Selection
{
    [Transaction(TransactionMode.Manual)]
    public class WallSwitchUp : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                Document doc = commandData.Application.ActiveUIDocument.Document;
                UIDocument uidoc = commandData.Application.ActiveUIDocument;


                Autodesk.Revit.UI.Selection.Selection selection = uidoc.Selection;
                //Nina.FamilyType.WallSwitch(uidoc, doc, true);
                Nina.Revit.Selector.WallSwitch(uidoc, doc, true);
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

