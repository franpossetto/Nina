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
            PushButtonData open_multiple_views = Ribbon
                .CreatePushButtonData("openMultipleViews", "Open\nMultiple", "Nina.Visibility.OpenMultipleViews");

            PushButton open_multiple_views_button = viewPanel.AddItem(open_multiple_views) as PushButton;
            open_multiple_views_button.LargeImage = Icons.openMultipleViews;

        }
    }
}
