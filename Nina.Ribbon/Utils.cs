using System;
using System.Linq;
using System.Collections.Generic;
using Autodesk.Revit.UI;
using System.Reflection;
using Autodesk.Windows;
using System.IO;
using System.Windows.Media.Imaging;

namespace Nina.Ribbon
{
    public static class Utils
    {
        static string ButtonIconsFolder = @"C:\ProgramData\Autodesk\ApplicationPlugins\Nina.bundle\Resources\";

        public static void CreateRibbonTab(UIControlledApplication application,
                                           string ribbonTabName)
        {
            RibbonControl ribbon = ComponentManager.Ribbon;
            RibbonTab tab = ribbon.FindTab(ribbonTabName);

            if (tab == null) application.CreateRibbonTab(ribbonTabName);
        }

        public static Autodesk.Revit.UI.RibbonPanel CreateRibbonPanel(UIControlledApplication application,
                                                                      string ribbonPanelName,
                                                                      string ribbonTabName)
        {
            /// <summary>
            /// This metthod is used to create a new Ribbon panel.
            /// Add a ribbonTabName if you need to include this panel inside on Existing Tab.
            /// <param name="application">An object that is passed to the external application 
            /// </summary>

            Autodesk.Revit.UI.RibbonPanel panel = application.GetRibbonPanels(ribbonTabName).FirstOrDefault(n => n.Name.Equals(ribbonTabName, StringComparison.InvariantCulture));

            if (panel != null) return panel;
            else return application.CreateRibbonPanel(ribbonTabName, ribbonPanelName);
        }

        public static Autodesk.Revit.UI.RibbonPanel CreateRibbonPanel(UIControlledApplication application, string ribbonPanelName)
        {
            List<Autodesk.Revit.UI.RibbonPanel> panels = application.GetRibbonPanels();

            Autodesk.Revit.UI.RibbonPanel panel = panels.Where(p => p.Name == ribbonPanelName).FirstOrDefault();
            if (panel != null) return panel;
            else return application.CreateRibbonPanel(ribbonPanelName);
        }

        public static PushButtonData CreatePushButtonData(string pushButtonName,
                                                          string pushButtonText,
                                                          string className)
        {
            /// <summary>
            /// This metthod is used to create a new PushButtonData.
            /// className: The name of the class containing the implementation for the command.
            /// <param name="application">An object that is passed to the external application 
            /// </summary>

            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData pushButtonData = new PushButtonData(pushButtonName, pushButtonText, assemblyPath, className);
            return pushButtonData;
        }

        public static void AddPushButton(Autodesk.Revit.UI.RibbonPanel ribbonPanel,
                                         PushButtonData pushButtonData)
        {
            PushButton pushButton = ribbonPanel.AddItem(pushButtonData) as PushButton;
        }

        public static BitmapImage GetIcon(string iconName)
        {
            return new BitmapImage(new Uri(Path.Combine(Nina.Ribbon.Utils.ButtonIconsFolder, $"{iconName}.png"), UriKind.Absolute));
        }

    }
}
