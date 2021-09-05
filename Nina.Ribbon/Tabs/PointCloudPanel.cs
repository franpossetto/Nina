using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace Nina.Tabs
{
    class PointCloudPanel
    {
        public static void Build(UIControlledApplication application, string tabName)
        {
            RibbonPanel visibilityPanel = Ribbon.CreateRibbonPanel(application, "Point Cloud ", tabName);

            PushButtonData pointcloud_fixedColor_data = Ribbon
                .CreatePushButtonData("pointcloud_fixedColor",
                                      "Set Fixed Color",
                                      "Nina.Visibility.SetFixedColor");

            PushButtonData pointcloud_intensity_data = Ribbon
                .CreatePushButtonData("pointcloud_intensity",
                                      "Set Intensity",
                                      "Nina.Visibility.SetIntensity");

            PushButtonData pointcloud_noOverride_data = Ribbon
                .CreatePushButtonData("pointcloud_noOverride",
                                      "Set No Override",
                                      "Nina.Visibility.SetNoOverride");

            PushButtonData pointcloud_normals_data = Ribbon
                .CreatePushButtonData("pointcloud_normals",
                                      "Set Normals",
                                      "Nina.Visibility.SetNormals");

            PushButtonData pointcloud_elevation_data = Ribbon
                .CreatePushButtonData("pointcloud_elevation",
                                      "Set Elevation",
                                      "Nina.Visibility.SetElevation");

            PushButtonData pointCloud_show_data = Ribbon
                .CreatePushButtonData("pointcloud_show",
                                      "Show\nHide",
                                      "Nina.Visibility.Hide");

            PushButtonData links_show_data = Ribbon
                .CreatePushButtonData("links_show",
                                      "Show/Hide \n Revit Links",
                                      "Nina.Visibility.HideRevitLinks");

            PushButtonData viewrange_up_data = Ribbon
                .CreatePushButtonData("viewrange_up",
                                      "View Range up",
                                      "Nina.Visibility.HideRevitLinks");

            PushButton showPointCloud = visibilityPanel.AddItem(pointCloud_show_data) as PushButton;
            showPointCloud.LargeImage = Ribbon.GetIcon("nina_show_hide_point_cloud_30");

            PulldownButtonData colorMode_pulldowndata = new PulldownButtonData("pointcloud_colormode", "Color\nMode");

            PulldownButton colorMode_pullDownButton = visibilityPanel.AddItem(colorMode_pulldowndata) as PulldownButton;
            colorMode_pullDownButton.LargeImage = Ribbon.GetIcon("nina_color_mode_30");

            PushButton setelevation_button = colorMode_pullDownButton.AddPushButton(pointcloud_elevation_data) as PushButton;
            PushButton setfixedcolor_button = colorMode_pullDownButton.AddPushButton(pointcloud_fixedColor_data) as PushButton;
            PushButton setintensity_button = colorMode_pullDownButton.AddPushButton(pointcloud_intensity_data) as PushButton;
            PushButton setnooverride_button = colorMode_pullDownButton.AddPushButton(pointcloud_noOverride_data) as PushButton;
            PushButton setnormals_button = colorMode_pullDownButton.AddPushButton(pointcloud_normals_data) as PushButton;


        }
    }
}
