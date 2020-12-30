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

    public class SetFixedColor : IExternalCommand
    {
        /// <summary>
        ///     External Command
        /// </summary>
        /// <param name ="commandData"></param>
        /// <param name="message"></param>
        /// <param name="elements"></param>
        /// <returns></returns>

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Application app = uiApp.Application;
            Document doc = uiDoc.Document;

            Log.Information.Tool = "Set Color Mode (Fixed)";
            Log.Information.File = doc.Title;
            Log.Information.Revit = commandData.Application.Application.VersionName;
            Log.Information.UserName = commandData.Application.Application.Username;
            Log.Information.Nina = Settings.Default.Nina;
            Logger.Write(Log.Information);

            PointCloud.SetColorMode(doc, 1);
            return Result.Succeeded;
                
            
        }
    }
}
