using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace Nina
{
    class ExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            /// <summary>
            /// Create a new Tab on Ribbon Bar.
            /// </summary>
            const string RIBBON_TAB = "Revit API Extension";
            Ribbon.CreateRibbonTab(application, RIBBON_TAB);

            /// <summary>
            /// Create a new Panel on Ribbon Tab.
            /// </summary>

            const string RIBBON_PANEL = "My Addins";
            RibbonPanel ribbonPanel = Ribbon.CreateRibbonPanel(application, RIBBON_PANEL, RIBBON_TAB);

            /// <summary>
            /// Create new Buttons on Panel.
            /// </summary>
            /// 
            const string PUSH_BUTTON_NAME = "Push Button";
            const string PUSH_BUTTON_DESC = "This is a push button";

            PushButtonData pushDataButton = Ribbon.CreatePushButtonData(PUSH_BUTTON_NAME, PUSH_BUTTON_DESC, "Nina.ExternalCommand");

            PushButton pushButton = ribbonPanel.AddItem(pushDataButton) as PushButton;
            System.Drawing.Bitmap ico = Properties.Resources.icon30;
            System.Windows.Media.Imaging.BitmapSource icon30 = Ribbon.Icon(ico);
            pushButton.LargeImage = icon30;

            return Result.Succeeded;



        }
    }
}
