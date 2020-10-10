using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace Nina.Info
{
    [Transaction(TransactionMode.Manual)]
    public class About : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                Document doc = commandData.Application.ActiveUIDocument.Document;
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                TaskDialog.Show("Revit Nina Extension", "This page is in progress");
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

