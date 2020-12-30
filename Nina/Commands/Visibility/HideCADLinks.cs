using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Logging.Core;
using Nina.Revit;
using System;

namespace Nina.Visibility
{
    [Transaction(TransactionMode.Manual)]
    public class HideCADLinks : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Application app = uiApp.Application;
            Document doc = uiDoc.Document;

            Log.Information.Tool = "Hide DWG Links";
            Log.Information.File = doc.Title;
            Log.Information.Revit = commandData.Application.Application.VersionName;
            Log.Information.UserName = commandData.Application.Application.Username;
            Log.Information.Nina = Settings.Default.Nina;
            Logger.Write(Log.Information);

            try
            {
                Links.HideCAD(doc);
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }

        }
    }
}

