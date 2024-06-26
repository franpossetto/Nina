﻿using Autodesk.Revit.DB;
using Autodesk.Revit.DB.PointClouds;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nina.Visibility
{
    public class Utils
    {
        public static void HideRVT(Document doc)
        {
            Categories categories = doc.Settings.Categories;
            Category linkCategory = categories.get_Item(BuiltInCategory.OST_RvtLinks);
            Autodesk.Revit.DB.View activeView = doc.ActiveView;

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

                Autodesk.Revit.DB.View activeView = doc.ActiveView;
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

        public static void OpenMultipleViews(Document doc, UIDocument uiDoc, List<ElementId> viewIds)
        {
            foreach (ElementId id in viewIds)
            {
                try
                {
                    Autodesk.Revit.DB.View view = doc.GetElement(id) as Autodesk.Revit.DB.View;
                    uiDoc.RequestViewChange(view);
                }
                catch
                {
                    // cannot do it.
                }
            }
        }

        public static void OpenFromViewPort(Document doc, UIDocument uiDoc, ICollection<ElementId> viewPortIds)
        {
            foreach (ElementId id in viewPortIds)
            {
                try
                {
                    Viewport viewport = doc.GetElement(id) as Viewport;
                    ElementId viewId = viewport.ViewId;
                    Autodesk.Revit.DB.View view = doc.GetElement(viewId) as Autodesk.Revit.DB.View;
                    uiDoc.RequestViewChange(view);
                }
                catch
                {
                    // cannot do it.
                }
            }
        }

        public static void HideSectionBox(Document doc)
        {
            View3D view = doc.ActiveView as View3D;

            using (Transaction t = new Transaction(doc))
            {
                t.Start("Toggle Section Box");
                view.IsSectionBoxActive = !view.IsSectionBoxActive;
                t.Commit();
            }
        }

    }
}
