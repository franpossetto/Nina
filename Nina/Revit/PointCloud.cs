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
            
            PointCloudOverrides pc_ovverides =  activeView.GetPointCloudOverrides();

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
        public static void SetColorMode(Document doc, int colorMode)
        {
            
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IEnumerable<PointCloudInstance> pointClouds = collector.OfCategory(BuiltInCategory.OST_PointClouds)
                                                                    .WhereElementIsNotElementType().ToList()
                                                                    .Cast<PointCloudInstance>();



            PointCloudOverrides pco = doc.ActiveView.GetPointCloudOverrides();
            PointCloudOverrideSettings pt_cloud_settings = pco.GetPointCloudScanOverrideSettings(pointClouds.FirstOrDefault().Id);

            switch (colorMode)
            {
                case 0:
                    pt_cloud_settings.ColorMode = PointCloudColorMode.Elevation;
                    break;
                case 1:
                    pt_cloud_settings.ColorMode = PointCloudColorMode.FixedColor;
                    break;
                case 2:
                    pt_cloud_settings.ColorMode = PointCloudColorMode.Intensity;
                    break;
                case 3:
                    pt_cloud_settings.ColorMode = PointCloudColorMode.NoOverride;
                    break;
                case 4:
                    pt_cloud_settings.ColorMode = PointCloudColorMode.Normals;
                    break;

                default:
                    break;
            }

            foreach (PointCloudInstance pointCloud in pointClouds)
            {
                View activeView = doc.ActiveView;
                PointCloudOverrides overrides = activeView.GetPointCloudOverrides();
                PointCloudColorSettings pointCloudColorSettings = new PointCloudColorSettings();

                if (pt_cloud_settings.ColorMode == PointCloudColorMode.Intensity){

                }
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
