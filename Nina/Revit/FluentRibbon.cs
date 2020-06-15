using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;

namespace Nina.Revit
{
    public class FluentRibbon
    {
        
        //myTab.AddPanel(panelObject).AddPushButton(pushbuttonObject1, pushbuttonObject2, pushbuttonObject3);
        
        //myTab.SelectPanel(panelObject).AddPushButton(pushbuttonObject);
        
        //myTab.SelectPanel(panelObject).AddPulldownButton(pulldownButtonObject).AddPushButton(pushbuttonObject);
        
        //myTab.SelectPanel(panelObject)
             //.AddStakedItems(pushbuttonObject1, pushbuttonObject2, pushbuttonObject3)
             //.GetStakedItem(position)
             //.ConvertToPullButton();

    }

    public class FluentTab
    {
        private RibbonTab _Tab { get; set; }
        public RibbonTab Tab
        {
            get
            {
                return _Tab;
            }
            set
            {
                _Tab = value;
            }
        }

        public RibbonTab Create(string ribbonTabName)
        {
            RibbonControl ribbon = ComponentManager.Ribbon;
            RibbonTab tab = ribbon.FindTab(ribbonTabName);
            return tab;
        }

        public Autodesk.Revit.UI.RibbonPanel GetPanel(UIApplication uiApp,  string ribbonPanelName)
        {
            Autodesk.Revit.UI.RibbonPanel panel = uiApp.GetRibbonPanels(ribbonPanelName)
                                                       .FirstOrDefault(n => n.Name.Equals(ribbonPanelName, 
                                                                                          StringComparison.InvariantCulture
                                                                                          ));
            return panel;
        }
        public IList<Autodesk.Revit.UI.RibbonPanel> GetPanels(UIApplication uiApp)
        {
            IList<Autodesk.Revit.UI.RibbonPanel> panels = uiApp.GetRibbonPanels(Tab.Name);
            return panels;
        }






        FluentTab(string ribbonTabName)
        {
            Tab = Create(ribbonTabName);
        }
    }

    public class FluentButton
    {
    }
}
