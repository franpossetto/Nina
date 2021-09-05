using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace Nina.Tabs
{
    public static class LinksPanel
    {
        public static void Build(UIControlledApplication application, string tabName)
        {
            RibbonPanel linksPanel = Ribbon.CreateRibbonPanel(application, "Links", tabName);

            PulldownButtonData hide_links = new PulldownButtonData("hideLinks", "Show\nHide");
            hide_links.LargeImage = Ribbon.GetIcon("nina_hide_links_30");

            PushButtonData rvt_links_hide = Ribbon
                .CreatePushButtonData("links_hide", "Show\nHide RVT Links", "Nina.Visibility.HideRevitLinks");

            PushButtonData dwg_links_hide = Ribbon
                .CreatePushButtonData("cad_links_hide", "Show\nHide DWG Links", "Nina.Visibility.HideCADLinks");

            PulldownButton info_pullDownButton = linksPanel.AddItem(hide_links) as PulldownButton;
            info_pullDownButton.AddPushButton(rvt_links_hide);
            info_pullDownButton.AddPushButton(dwg_links_hide);


        }
    }
}
