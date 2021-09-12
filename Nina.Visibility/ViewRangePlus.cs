using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Settings = Nina.Common.Settings;

namespace Nina.Visibility
{
    [Transaction(TransactionMode.Manual)]
    public class ViewRangePlus : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

  
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

                if (Settings.Preferences.ViewRangeTopBottom)
                {
                    viewRange.SetOffset(PlanViewPlane.CutPlane, (currentOffsetCutPlane + offsetValue));
                    viewRange.SetOffset(PlanViewPlane.TopClipPlane, (currentOffsetTop + offsetValue));
                    viewRange.SetOffset(PlanViewPlane.BottomClipPlane, (currentOffsetBottom + offsetValue));
                }
                else if (!Settings.Preferences.ViewRangeTopBottom && (currentOffsetCutPlane + offsetValue) < viewRange.GetOffset(PlanViewPlane.TopClipPlane)) viewRange.SetOffset(PlanViewPlane.CutPlane, (currentOffsetCutPlane + offsetValue));
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

                return Autodesk.Revit.UI.Result.Failed;
            }

            return Autodesk.Revit.UI.Result.Succeeded;

        }
    }
}