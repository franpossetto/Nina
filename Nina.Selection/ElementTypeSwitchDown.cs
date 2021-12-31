using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Settings = Nina.Common.Settings;

namespace Nina.Selection
{
    [Transaction(TransactionMode.Manual)]
    //generar boton
    public class SwitchDown : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            try
            {
                Autodesk.Revit.UI.Selection.Selection selection = uidoc.Selection;
                Utils.ElementSwitch(uidoc, doc, false);
            }

            catch (System.Exception exp)
            {
                return Autodesk.Revit.UI.Result.Failed;
            }

            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}