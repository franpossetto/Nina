using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Nina.Ribbon;

namespace Nina.Tabs
{
    class PointCloudPanel
    {
        public static void Build(UIControlledApplication application, string tabName)
        {
            RibbonPanel visibilityPanel = Utils.CreateRibbonPanel(application, "Point Cloud ", tabName);

            PushButtonData pointCloud_isolate_data = Utils
                .CreatePushButtonData("pointcloud_isolate",
                                      "Isolate\nTemp ",
                                      "Nina.PointCloud.Isolate");

            pointCloud_isolate_data.LongDescription = "Put the long description here";
            pointCloud_isolate_data.ToolTip = "Put the Tooltip here";
            // pointCloud_isolate_data.ToolTipImage = 

            PushButtonData pointCloud_show_data = Utils
                .CreatePushButtonData("pointcloud_show",
                                      "Show\nHide",
                                      "Nina.PointCloud.Hide");

            pointCloud_show_data.LongDescription = "Put the long description here";
            pointCloud_show_data.ToolTip = "Put the Tooltip here";
            // pointCloud_show_data.ToolTipImage = 

            PushButtonData pointcloud_fixedColor_data = Utils
                .CreatePushButtonData("pointcloud_fixedColor",
                                      "Set Fixed Color",
                                      "Nina.PointCloud.ColorMode.SetFixedColor");

            pointcloud_fixedColor_data.LongDescription = "Put the long description here";
            pointcloud_fixedColor_data.ToolTip = "Put the Tooltip here";
            // pointcloud_fixedColor_data.ToolTipImage = 

            PushButtonData pointcloud_intensity_data = Utils
                .CreatePushButtonData("pointcloud_intensity",
                                      "Set Intensity",
                                      "Nina.PointCloud.ColorMode.SetIntensity");

            pointcloud_intensity_data.LongDescription = "Put the long description here";
            pointcloud_intensity_data.ToolTip = "Put the Tooltip here";
            // pointcloud_intensity_data.ToolTipImage = 

            PushButtonData pointcloud_noOverride_data = Utils
                .CreatePushButtonData("pointcloud_noOverride",
                                      "Set No Override",
                                      "Nina.PointCloud.ColorMode.SetNoOverride");

            pointcloud_noOverride_data.LongDescription = "Put the long description here";
            pointcloud_noOverride_data.ToolTip = "Put the Tooltip here";
            // pointcloud_noOverride_data.ToolTipImage = 

            PushButtonData pointcloud_normals_data = Utils
                .CreatePushButtonData("pointcloud_normals",
                                      "Set Normals",
                                      "Nina.PointCloud.ColorMode.SetNormals");

            pointcloud_normals_data.LongDescription = "Put the long description here";
            pointcloud_normals_data.ToolTip = "Put the Tooltip here";
            // pointcloud_normals_data.ToolTipImage = 

            PushButtonData pointcloud_elevation_data = Utils
                .CreatePushButtonData("pointcloud_elevation",
                                      "Set Elevation",
                                      "Nina.PointCloud.ColorMode.SetElevation");

            pointcloud_elevation_data.LongDescription = "Put the long description here";
            pointcloud_elevation_data.ToolTip = "Put the Tooltip here";
            // pointcloud_elevation_data.ToolTipImage = 

            PushButton pointCloudIsolate = visibilityPanel.AddItem(pointCloud_isolate_data) as PushButton;
            pointCloudIsolate.LargeImage = Utils.GetIcon("nina_point_cloud_isolate_30");

            PushButton showPointCloud = visibilityPanel.AddItem(pointCloud_show_data) as PushButton;
            showPointCloud.LargeImage = Utils.GetIcon("nina_show_hide_point_cloud_30");

            PulldownButtonData colorMode_pulldowndata = new PulldownButtonData("pointcloud_colormode", "Color\nMode");

            PulldownButton colorMode_pullDownButton = visibilityPanel.AddItem(colorMode_pulldowndata) as PulldownButton;
            colorMode_pullDownButton.LargeImage = Utils.GetIcon("nina_color_mode_30");

            PushButton setelevation_button = colorMode_pullDownButton.AddPushButton(pointcloud_elevation_data) as PushButton;
            PushButton setfixedcolor_button = colorMode_pullDownButton.AddPushButton(pointcloud_fixedColor_data) as PushButton;
            PushButton setintensity_button = colorMode_pullDownButton.AddPushButton(pointcloud_intensity_data) as PushButton;
            PushButton setnooverride_button = colorMode_pullDownButton.AddPushButton(pointcloud_noOverride_data) as PushButton;
            PushButton setnormals_button = colorMode_pullDownButton.AddPushButton(pointcloud_normals_data) as PushButton;


        }
    }
}
