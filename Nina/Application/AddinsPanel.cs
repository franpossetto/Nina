using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Nina.Revit;

namespace Nina
{
    public static class AddinsPanel
    {
        public static void Build(UIControlledApplication application)
        {
            RibbonPanel RevitAPIExtensionPanel = Ribbon.CreateRibbonPanel(application, "Revit API Extension");

            PushButtonData push_button_data = Ribbon
                .CreatePushButtonData("push_button_name", "Button Name", "Nina.Info.About");

            PushButton item19 = RevitAPIExtensionPanel.AddItem(push_button_data) as PushButton;
            item19.LargeImage = Icons.links_hide_30;

        }
    }
}
