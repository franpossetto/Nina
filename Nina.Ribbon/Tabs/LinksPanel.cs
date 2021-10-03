using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Nina.Ribbon;

namespace Nina.Tabs
{
    public static class LinksPanel
    {
        public static void Build(UIControlledApplication application, string tabName)
        {
            RibbonPanel linksPanel = Utils.CreateRibbonPanel(application, "Links", tabName);

            PulldownButtonData hide_links = new PulldownButtonData("hideLinks", 
                                                                   "Show\nHide");

            hide_links.LargeImage = Utils.GetIcon("nina_hide_links_30");
            hide_links.LongDescription = "Put the long description here";

            PushButtonData rvt_links_hide_data = Utils
                .CreatePushButtonData("links_hide", 
                                      "Show\nHide RVT Links",
                                      "Nina.Visibility.HideRevitLinks");
            
            rvt_links_hide_data.LongDescription = "Put the long description here";
            rvt_links_hide_data.ToolTip = "Put the Tooltip here";
            // rvt_links_hide.ToolTipImage = 

            PushButtonData dwg_links_hide_data = Utils
                .CreatePushButtonData("cad_links_hide", 
                                      "Show\nHide DWG Links",
                                      "Nina.Visibility.HideCADLinks");

            dwg_links_hide_data.LongDescription = "Put the long description here";
            dwg_links_hide_data.ToolTip = "Put the Tooltip here";
            // rvt_links_hide.ToolTipImage = 

            PulldownButton info_pullDownButton = linksPanel.AddItem(hide_links) as PulldownButton;
            info_pullDownButton.AddPushButton(rvt_links_hide_data);
            info_pullDownButton.AddPushButton(dwg_links_hide_data);


        }
    }
}
