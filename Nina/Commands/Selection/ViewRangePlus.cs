using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace Nina.Selection
{
    [Transaction(TransactionMode.Manual)]
    public class ViewRangePlus : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                Document doc = commandData.Application.ActiveUIDocument.Document;
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                View activeView = doc.ActiveView as View;

                if (!(activeView is ViewPlan)) return Result.Cancelled;

                ViewPlan viewPlan = activeView as ViewPlan;
                PlanViewRange viewRange = viewPlan.GetViewRange();

                double currentOffset = viewRange.GetOffset(PlanViewPlane.CutPlane);
                double offsetValue = 1;

                if ((currentOffset + offsetValue) < viewRange.GetOffset(PlanViewPlane.TopClipPlane))
                    viewRange.SetOffset(PlanViewPlane.CutPlane, (currentOffset + offsetValue));
                else
                    TaskDialog.Show("Revit Nina Extension", "Top Clip plane is set below te cut plane");

                using (Transaction t = new Transaction(doc, string.Format("View Range +{0}", offsetValue)))
                {
                    t.Start();
                        viewPlan.SetViewRange(viewRange);
                    t.Commit();
                }

                return Result.Succeeded;
            }
            catch
            {
                message = "Unexpected Exception thrown.";
                return Autodesk.Revit.UI.Result.Failed;
            }

        }
    }
}

