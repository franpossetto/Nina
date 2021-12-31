using Autodesk.Revit.DB;
using Autodesk.Revit.DB.PointClouds;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nina.Visibility
{
    public class Utils
    {
        public static void HideRVT(Document doc)
        {
            Categories categories = doc.Settings.Categories;
            Category linkCategory = categories.get_Item(BuiltInCategory.OST_RvtLinks);
            View activeView = doc.ActiveView;

            bool hide = activeView.GetCategoryHidden(linkCategory.Id) ? false : true;
            PointCloudOverrides pc_ovverides = activeView.GetPointCloudOverrides();

            using (Transaction t = new Transaction(doc, "Point Clouds were hidden"))
            {
                try
                {
                    t.Start();
                    activeView.SetCategoryHidden(linkCategory.Id, hide);
                    t.Commit();
                }
                catch (Exception e)
                {
                    TaskDialog.Show("Exception", e.StackTrace);
                }
            }
        }
        public static void HideCAD(Document doc)
        {

            IEnumerable<ImportInstance> cads = new FilteredElementCollector(doc).OfClass(typeof(ImportInstance)).Cast<ImportInstance>().Where(i => i.IsLinked == true);

            Boolean anyHiddenElement = cads.Any(c => c.IsHidden(doc.ActiveView));
            using (Transaction t = new Transaction(doc, "CADs were hidden"))
            {
                FamilyElementVisibility cadVisibility = new FamilyElementVisibility(FamilyElementVisibilityType.ViewSpecific);
                List<ElementId> cadsId = cads.Select(c => c.Id).ToList();
                t.Start();
                if (anyHiddenElement) doc.ActiveView.UnhideElements(cadsId);
                else doc.ActiveView.HideElements(cadsId);
                t.Commit();
            }
        }
        public static void SetColorMode(Document doc, int colorMode)
        {
            //add selection

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IEnumerable<PointCloudInstance> pointClouds = collector.OfCategory(BuiltInCategory.OST_PointClouds)
                                                                    .WhereElementIsNotElementType().ToList()
                                                                    .Cast<PointCloudInstance>();
            PointCloudOverrides pco = doc.ActiveView.GetPointCloudOverrides();

            foreach (PointCloudInstance pointCloud in pointClouds)
            {
                PointCloudOverrideSettings pt_cloud_settings = pco.GetPointCloudScanOverrideSettings(pointCloud.Id);

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

                View activeView = doc.ActiveView;
                PointCloudOverrides overrides = activeView.GetPointCloudOverrides();
                PointCloudColorSettings pointCloudColorSettings = new PointCloudColorSettings();

                using (Transaction t = new Transaction(doc, "Point Clouds color mode was changed"))
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
