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

    public class Hide : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Application app = uiApp.Application;
            Document doc = uiDoc.Document;

            try
            {
                PointCloud.Hide(doc, false);

                LogDetail log = new LogDetail
                {
                    Message = "message"
                };
                Logger.WriteUsage(log);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                LogDetail log = new LogDetail();
                message = ex.Message;
                log.Message = message;

                return Result.Failed;
            }
        }
    }
}
