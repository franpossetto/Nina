using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Nina.Revit;
using Logging.Core;

namespace Nina.Visibility
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class OpenViewFromViewPort : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Application app = uiApp.Application;
            Document doc = uiDoc.Document;

            Log log = new Log
            {
                Tool = "Open View from Viewport",
                Document = doc.Title,
                Revit = commandData.Application.Application.VersionName,
                UserName = commandData.Application.Application.Username,
                Nina = Settings.Default.Nina
            };

            try
            {
                Autodesk.Revit.UI.Selection.Selection selection = uiDoc.Selection;
                ICollection<ElementId> viewPortIds = selection.GetElementIds();

                Nina.Revit.Views.OpenFromViewPort(doc, uiDoc, viewPortIds);
            }
            catch (System.Exception exp)
            {
                log.Message = exp.Message;
                log.Exception = exp;
                return Autodesk.Revit.UI.Result.Failed;
            }

            Logger.Write(log);
            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}

