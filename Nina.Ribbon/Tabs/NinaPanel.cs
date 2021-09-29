using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Nina.Ribbon;

namespace Nina.Tabs
{
    public class NinaPanel
    {
        public static void Build(UIControlledApplication application, string tabName)
        {
            RibbonPanel ninaPanel = Utils.CreateRibbonPanel(application, "Nina ", tabName);

            #region Info Button

            PulldownButtonData info_button = new PulldownButtonData("info", "Info");
            info_button.LargeImage = Utils.GetIcon("nina_info_30");

            PushButtonData about_button_data = Utils
                .CreatePushButtonData("about", "About", "Nina.Common.About");

            about_button_data.LongDescription = "Put the long description here";
            about_button_data.ToolTip = "Put the Tooltip here";
            // about_button_data.ToolTipImage = 

            PushButtonData repo_button_data = Utils
                .CreatePushButtonData("github", "Github Repository", "Nina.Common.Github");

            repo_button_data.LongDescription = "Put the long description here";
            repo_button_data.ToolTip = "Put the Tooltip here";
            // repo_button_data.ToolTipImage = 

            PushButtonData logs_button_data = Utils
                .CreatePushButtonData("logs", "Logs", "Nina.Common.Logs");

            logs_button_data.LongDescription = "Put the long description here";
            logs_button_data.ToolTip = "Put the Tooltip here";
            // logs_button_data.ToolTipImage = 

            PulldownButton info_pullDownButton = ninaPanel.AddItem(info_button) as PulldownButton;
            info_pullDownButton.AddPushButton(about_button_data);
            info_pullDownButton.AddPushButton(repo_button_data);
            info_pullDownButton.AddPushButton(logs_button_data);

            #endregion

            # region Config Button

            PushButtonData settings_button_data = Utils
                .CreatePushButtonData("settings", "Config", "Nina.Common.Config");

            PushButton settings_button = ninaPanel.AddItem(settings_button_data) as PushButton;
            settings_button.LargeImage = Utils.GetIcon("nina_settings_30");

            #endregion

        }
    }
}
