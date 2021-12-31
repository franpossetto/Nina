using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.PointClouds;
using System.Linq;

namespace Nina.PointCloud
{
    public class Utils
    {
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

        public static void Hide(Document doc, bool temp)
        {
            Categories categories = doc.Settings.Categories;
            Category pointCloudCategory = categories.get_Item(BuiltInCategory.OST_PointClouds);
            View activeView = doc.ActiveView;

            bool hide = activeView.GetCategoryHidden(pointCloudCategory.Id) ? false : true;
            PointCloudOverrides pc_ovverides = activeView.GetPointCloudOverrides();

            using (Transaction t = new Transaction(doc, "Point Clouds were hidden"))
            {
                try
                {
                    if (!temp && activeView.ViewTemplateId == ElementId.InvalidElementId)
                    {
                        t.Start();
                        activeView.SetCategoryHidden(pointCloudCategory.Id, hide);
                        t.Commit();
                    }
                    else if (!temp && activeView.ViewTemplateId != ElementId.InvalidElementId)
                        TaskDialog.Show("Hide Point Clouds", "To use this tool, disable the View Template in the Active View");

                    else if (temp && hide)
                    {
                        t.Start();
                        activeView.HideCategoryTemporary(pointCloudCategory.Id);
                        t.Commit();
                    }
                    else { }

                }
                catch (Exception e)
                {
                    TaskDialog.Show("Exception", e.StackTrace);
                }
            }
        }

        public static void Isolate(Document doc)
        {
            Categories categories = doc.Settings.Categories;
            Category pointCloudCategory = categories.get_Item(BuiltInCategory.OST_PointClouds);
            View activeView = doc.ActiveView;

            using (Transaction t = new Transaction(doc, "Isolate Point clouds"))
            {
                t.Start();
                if (!activeView.IsTemporaryHideIsolateActive()) activeView.IsolateCategoryTemporary(pointCloudCategory.Id);
                else activeView.DisableTemporaryViewMode(TemporaryViewMode.TemporaryHideIsolate);
                t.Commit();
            }
        }

        public static void IsolateTemporary(Document doc)
        {
            Categories categories = doc.Settings.Categories;
            Category pointCloudCategory = categories.get_Item(BuiltInCategory.OST_PointClouds);
            View activeView = doc.ActiveView;

            using (Transaction t = new Transaction(doc, "Isolate Point clouds"))
            {
                t.Start();
                if (!activeView.IsTemporaryHideIsolateActive()) activeView.IsolateCategoryTemporary(pointCloudCategory.Id);
                else activeView.DisableTemporaryViewMode(TemporaryViewMode.TemporaryHideIsolate);
                t.Commit();

            }
        }
    }
}
