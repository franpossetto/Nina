using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using Nina.Ribbon;

namespace Nina.Tabs
{
    public static class Views
    {
        public static void Build(UIControlledApplication application, string tabName)
        {

            RibbonPanel viewPanel = Utils.CreateRibbonPanel(application, "Views", tabName);

            PushButtonData open_multiple_views_data = Utils
                  .CreatePushButtonData("openMultipleViews",
                                        "Open Multiple Views",
                                        "Nina.Visibility.OpenMultipleViews"
                                        );

            open_multiple_views_data.LongDescription = "Put the long description here";
            open_multiple_views_data.ToolTip = "Put the Tooltip here";
            // rvt_links_hide.ToolTipImage = 

            PushButtonData open_view_from_viewport_data = Utils
                  .CreatePushButtonData("openViewport",
                                        "Open View from Viewport",
                                        "Nina.Visibility.OpenViewFromViewPort"
                                        );

            open_view_from_viewport_data.LongDescription = "Put the long description here";
            open_view_from_viewport_data.ToolTip = "Put the Tooltip here";
            // rvt_links_hide.ToolTipImage = 

            PushButtonData viewrange_plus_data = Utils
                  .CreatePushButtonData("viewrange_plus",
                                        "View Range up",
                                        "Nina.Visibility.ViewRangePlus");

            viewrange_plus_data.LongDescription = "Put the long description here";
            viewrange_plus_data.ToolTip = "Put the Tooltip here";
            // rvt_links_hide.ToolTipImage = 

            PushButtonData viewrange_minor_data = Utils
                  .CreatePushButtonData("viewrange_down",
                                        "View Range down",
                                        "Nina.Visibility.ViewRangeMinor");

            viewrange_minor_data.LongDescription = "Put the long description here";
            viewrange_minor_data.ToolTip = "Put the Tooltip here";
            // rvt_links_hide.ToolTipImage = 

            PulldownButtonData actions_pulldownbutton_data = new PulldownButtonData("viewActions", "Open views");

            viewrange_plus_data.Image = Utils.GetIcon("nina_view_range_plus_16");
            viewrange_minor_data.Image = Utils.GetIcon("nina_view_range_minor_16");
            actions_pulldownbutton_data.Image = Utils.GetIcon("nina_actions_16");

            IList<RibbonItem> view_actions = viewPanel.AddStackedItems(viewrange_plus_data,
                                                                               viewrange_minor_data,
                                                                               actions_pulldownbutton_data
                                                                               );

            PulldownButton actions_pulldownbutton = view_actions[2] as PulldownButton;


            PushButton item1 = actions_pulldownbutton.AddPushButton(open_multiple_views_data) as PushButton;
            PushButton item2 = actions_pulldownbutton.AddPushButton(open_view_from_viewport_data) as PushButton;

            //open_multiple_views_data.Image = Utils.GetIcon("nina_open_multiple_views_16");
            //open_view_from_viewport_data.Image = Utils.GetIcon("nina_open_multiple_views_from_viewport_16");
        }
    }
}
