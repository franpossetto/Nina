using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Logging.Core;

namespace Nina.Selection
{
    [Transaction(TransactionMode.Manual)]
    //generar boton
    public class SwitchDown : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                Document doc = commandData.Application.ActiveUIDocument.Document;
                UIDocument uidoc = commandData.Application.ActiveUIDocument;

                Log.Information.Tool = "Switch-down Element Type";
                Log.Information.File = doc.Title;
                Log.Information.Revit = commandData.Application.Application.VersionName;
                Log.Information.UserName = commandData.Application.Application.Username;
                Log.Information.Nina = Settings.Default.Nina;
                Logger.Write(Log.Information);

                Autodesk.Revit.UI.Selection.Selection selection = uidoc.Selection;
                //Nina.FamilyType.WallSwitch(uidoc, doc, false);
                Nina.Revit.Selector.ElementSwitch(uidoc, doc, false);
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

