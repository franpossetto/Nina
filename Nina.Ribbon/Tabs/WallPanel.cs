using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Nina.Ribbon;

namespace Nina.Tabs
{
    class WallPanel
    {
        public static void Build(UIControlledApplication application, string tabName)
        {
            RibbonPanel wallPanel = Utils.CreateRibbonPanel(application, "Walls", tabName);
            
            PushButtonData wall_location_centerline_data = Utils
               .CreatePushButtonData("wall_centerline",
                                     "Centerline",
                                     "Nina.PointCloud.ColorMode.SetFixedColor");

            PulldownButtonData wall_location_line_pulldowndata = new PulldownButtonData("wall_location_line", "Loc.\nLine");

            PulldownButton wall_location_line_pullDownButton = wallPanel.AddItem(wall_location_line_pulldowndata) as PulldownButton;
            wall_location_line_pullDownButton.LargeImage = Utils.GetIcon("nina_location_line_30");

            PushButton centerline_button = wall_location_line_pullDownButton.AddPushButton(wall_location_centerline_data) as PushButton;
        }
    }
}
