using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Nina.Revit;

namespace Nina
{
    public static class Views
    {
        public static void Build(UIControlledApplication application, string tabName)
        {
            RibbonPanel viewPanel = Ribbon.CreateRibbonPanel(application, "Views", tabName);

            PushButtonData open_multiple_views_data = Ribbon
                .CreatePushButtonData("openMultipleViews", 
                                      "Open Multiple Views",
                                      "Nina.Visibility.OpenMultipleViews"
                                      );

            PushButtonData open_view_from_viewport_data = Ribbon
                .CreatePushButtonData("openViewport",
                                      "Open View from Viewport",
                                      "Nina.Visibility.OpenViewFromViewPort"
                                      );

            PushButtonData viewrange_plus_data = Ribbon
               .CreatePushButtonData("viewrange_plus", // button name
                                     "View Range up", // name in Revit UI
                                     "Nina.Selection.ViewRangePlus"); //cmd

            PushButtonData viewrange_minor_data = Ribbon
                .CreatePushButtonData("viewrange_down",
                                      "View Range down",
                                      "Nina.Selection.ViewRangeMinor");

            


            PulldownButtonData actions_pulldownbutton_data = new PulldownButtonData("viewActions", "Open Views");

            viewrange_plus_data.Image = Icons.viewrange_plus_16;
            viewrange_minor_data.Image = Icons.viewrange_minor_16;
            actions_pulldownbutton_data.Image = Icons.actions;

            IList<RibbonItem> view_actions = viewPanel.AddStackedItems(viewrange_plus_data,
                                                                               viewrange_minor_data,
                                                                               actions_pulldownbutton_data
                                                                               );



            PulldownButton actions_pulldownbutton = view_actions[2] as PulldownButton;


            PushButton item1 = actions_pulldownbutton.AddPushButton(open_multiple_views_data) as PushButton;
            PushButton item2 = actions_pulldownbutton.AddPushButton(open_view_from_viewport_data) as PushButton;


            open_multiple_views_data.Image = Icons.openViewport;
            open_view_from_viewport_data.Image = Icons.openMultipleViews;
        }
    }
}
