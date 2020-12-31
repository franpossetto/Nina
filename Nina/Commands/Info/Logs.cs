
//.NET common used namespaces
using System;
using System.IO;
using System.Collections.Generic;

//Revit.NET common used namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Logging.Core;

namespace Nina.Info
{
    [Transaction(TransactionMode.Manual)]
    public class Logs: IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            Log.Information.Tool = "Open Logs Directory";
            Log.Information.File = doc.Title;
            Log.Information.Revit = commandData.Application.Application.VersionName;
            Log.Information.UserName = commandData.Application.Application.Username;
            Log.Information.Nina = Settings.Default.Nina;
            Logger.Write(Log.Information);
        
            try
            {
                System.Diagnostics.Process.Start(Settings.Default.LogDirectory);
            }
            catch
            {
                return Result.Failed;
            }
            
            return Result.Succeeded;
        }
    }
}
