using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Nina.Revit;

namespace Nina
{
    public static class LinksPanel
    {
        public static void Build(UIControlledApplication application, string tabName)
        {
            RibbonPanel linksPanel = Ribbon.CreateRibbonPanel(application, "Links", tabName);

            PushButtonData links_hide_data = Ribbon
                .CreatePushButtonData("links_hide", "Show\nHide", "Nina.Visibility.HideRevitLinks");

            PushButton item19 = linksPanel.AddItem(links_hide_data) as PushButton;
            item19.LargeImage = Icons.links_hide_30;
        }
    }
}
