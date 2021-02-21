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

        private List<Autodesk.Revit.UI.RibbonPanel> _Panels = new List<Autodesk.Revit.UI.RibbonPanel>();
        public List<Autodesk.Revit.UI.RibbonPanel> Panels
        {
            get { return _Panels; }
            set { _Panels = value; }
        }

        private Autodesk.Revit.UI.RibbonPanel _Panel{ get; set; }
        public Autodesk.Revit.UI.RibbonPanel Panel
        {
            get { return _Panel; }
            set { _Panel = value; }
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
        public Autodesk.Revit.UI.RibbonPanel AddPanel(UIControlledApplication application, string ribbonPanelName)
        {
            Autodesk.Revit.UI.RibbonPanel panel = application.GetRibbonPanels(Tab.Name)
                                                        .FirstOrDefault(n => n.Name.Equals(Tab.Name, 
                                                                                           StringComparison.InvariantCulture));
            Panel = panel;
            Panels.Add(panel);

            if (panel != null)
                return panel;
            else
            {
                panel = application.CreateRibbonPanel(Tab.Name, ribbonPanelName);
                return panel;
            }
        }

        public Autodesk.Revit.UI.PulldownButton AddPulldownButton(PulldownButtonData pullDownButtonData)
        {
            PulldownButton pulldownButton = Panel.AddItem(pullDownButtonData) as PulldownButton;
            return pulldownButton;
        }
        public FluentTab(string ribbonTabName)
        {
            Tab = Create(ribbonTabName);
        }
    }

    public class FluentPanel
    {
        private Autodesk.Revit.UI.RibbonPanel _PanelId { get; set; }
        public Autodesk.Revit.UI.RibbonPanel PanelId
        {
            get
            {
                return _PanelId;
            }
            set
            {
                _PanelId = value;
            }
        }

        private Autodesk.Revit.UI.RibbonPanel _Panel { get; set; }
        public Autodesk.Revit.UI.RibbonPanel Panel
        {
            get
            {
                return _Panel;
            }
            set
            {
                _Panel = value;
            }
        }

        public FluentPanel(UIControlledApplication application, FluentTab tab, string ribbonPanelName)
        {
            Autodesk.Revit.UI.RibbonPanel panel = application.GetRibbonPanels(tab.Tab.Name)
                                                        .FirstOrDefault(n => n.Name.Equals(tab.Tab.Name, StringComparison.InvariantCulture));
            //Panels.Add(panel);

            if (panel != null)
            {
                Panel = panel;
            }
                
            else
            {
                panel = application.CreateRibbonPanel(tab.Tab.Name, ribbonPanelName);
            }
        }

    }


}

//objets have to return fluent objects.