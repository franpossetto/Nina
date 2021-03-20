using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Logging.Core;

namespace Nina.Selection
{
    [Transaction(TransactionMode.Manual)]
    public class ViewRangePlus : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            Log log = new Log
            {
                Tool = "Set View Range (+)",
                Document = doc.Title,
                Revit = commandData.Application.Application.VersionName,
                UserName = commandData.Application.Application.Username,
                Nina = Settings.Default.Nina
            };

            try
            {
                View activeView = doc.ActiveView as View;

                if (!(activeView is ViewPlan)) return Result.Cancelled;

                ViewPlan viewPlan = activeView as ViewPlan;
                PlanViewRange viewRange = viewPlan.GetViewRange();

                double currentOffsetCutPlane = viewRange.GetOffset(PlanViewPlane.CutPlane);
                double currentOffsetBottom = viewRange.GetOffset(PlanViewPlane.BottomClipPlane);
                double currentOffsetTop = viewRange.GetOffset(PlanViewPlane.TopClipPlane);

                double offsetValue = 1;

                if (Settings.Default.ViewRangeTopBottom)
                {
                    viewRange.SetOffset(PlanViewPlane.CutPlane, (currentOffsetCutPlane + offsetValue));
                    viewRange.SetOffset(PlanViewPlane.TopClipPlane, (currentOffsetTop + offsetValue));
                    viewRange.SetOffset(PlanViewPlane.BottomClipPlane, (currentOffsetBottom + offsetValue));
                } else if (!Settings.Default.ViewRangeTopBottom && (currentOffsetCutPlane + offsetValue) < viewRange.GetOffset(PlanViewPlane.TopClipPlane)) viewRange.SetOffset(PlanViewPlane.CutPlane, (currentOffsetCutPlane + offsetValue));
                else
                    TaskDialog.Show("Revit Nina Extension", "Top Clip plane is set below te cut plane");

                using (Transaction t = new Transaction(doc, string.Format("View Range +{0}", offsetValue)))
                {
                    t.Start();
                    viewPlan.SetViewRange(viewRange);
                    t.Commit();
                }
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

