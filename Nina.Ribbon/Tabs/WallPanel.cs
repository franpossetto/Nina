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
            
            PushButtonData wall_centerline_data = Utils
               .CreatePushButtonData("wall_centerline",
                                     "Set Wall Centerline",
                                     "Nina.Selection.SetWallCenterline");

            PushButtonData core_centerline_data = Utils
               .CreatePushButtonData("core_centerline",
                                     "Set Core Centerline",
                                     "Nina.Selection.SetCoreCenterline");

            PushButtonData finish_face_exterior_data = Utils
               .CreatePushButtonData("finish_face_exterior",
                                     "Set Finish Face: Exterior",
                                     "Nina.Selection.SetFinishFaceExterior");

            PushButtonData finish_face_interior_data = Utils
               .CreatePushButtonData("finish_face_interior",
                                     "Set Finish Face: Interior",
                                     "Nina.Selection.SetFinishFaceInterior");

            PushButtonData core_face_exterior_data = Utils
               .CreatePushButtonData("core_face_exterior",
                                     "Set Core Face: Exterior",
                                     "Nina.Selection.SetCoreFaceExterior");

            PushButtonData core_face_interior_data = Utils
               .CreatePushButtonData("core_face_interior",
                                     "Set Core Face: Interior",
                                     "Nina.Selection.SetCoreFaceInterior");

            PulldownButtonData wall_location_line_pulldowndata = new PulldownButtonData("wall_location_line", "Loc.\nLine");

            PulldownButton wall_location_line_pullDownButton = wallPanel.AddItem(wall_location_line_pulldowndata) as PulldownButton;
            wall_location_line_pullDownButton.LargeImage = Utils.GetIcon("nina_location_line_30");

            PushButton wall_centerline_button = wall_location_line_pullDownButton.AddPushButton(wall_centerline_data) as PushButton;
            PushButton core_centerline_button = wall_location_line_pullDownButton.AddPushButton(core_centerline_data) as PushButton;
            PushButton core_face_interior_button = wall_location_line_pullDownButton.AddPushButton(finish_face_exterior_data) as PushButton;
            PushButton core_face_exterior_button = wall_location_line_pullDownButton.AddPushButton(finish_face_interior_data) as PushButton;
            PushButton finish_face_interior_button = wall_location_line_pullDownButton.AddPushButton(core_face_exterior_data) as PushButton;
            PushButton finish_face_exterior_button = wall_location_line_pullDownButton.AddPushButton(core_face_interior_data) as PushButton;

        }
    }
}
