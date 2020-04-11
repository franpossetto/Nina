using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.PointClouds;

namespace Nina.Revit
{
    public class PointCloud
    {
        public static void Hide(Document doc, bool hide)
        {
            Categories categories = doc.Settings.Categories;
            Category pointCloudCategory = categories.get_Item(BuiltInCategory.OST_PointClouds);
            View activeView = doc.ActiveView;

            using(Transaction t = new Transaction(doc,"Point Clouds were hidden"))
            {
                try
                {
                    t.Start();
                        activeView.SetCategoryHidden(pointCloudCategory.Id, hide);
                    t.Commit();
                } catch(Exception e)
                {
                    TaskDialog.Show("Exception", e.StackTrace);
                }
            }
        }
        public static void SetColorMode(Document doc)
        {
            
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IEnumerable<PointCloudInstance> pointClouds = collector.OfCategory(BuiltInCategory.OST_PointClouds)
                                                                    .WhereElementIsNotElementType().ToList()
                                                                    .Cast<PointCloudInstance>();




            PointCloudOverrideSettings pt_cloud_settings = new PointCloudOverrideSettings();
            pt_cloud_settings.ColorMode = PointCloudColorMode.Normals;

            foreach (PointCloudInstance pointCloud in pointClouds)
            {
                View activeView = doc.ActiveView;
                PointCloudOverrides overrides = activeView.GetPointCloudOverrides();
                PointCloudColorSettings pointCloudColorSettings = new PointCloudColorSettings();

                using (Transaction t = new Transaction(doc, "Point Clouds were hidden"))
                {
                    try
                    {
                        t.Start();
                        overrides.SetPointCloudScanOverrideSettings(pointCloud.Id, pt_cloud_settings);
                        t.Commit();
                    }
                    catch (Exception e)
                    {
                        TaskDialog.Show("Exception", e.StackTrace);
                    }
                }
            }
                
                

           
        }
    }
}
