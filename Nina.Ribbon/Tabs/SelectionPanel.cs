﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace Nina.Tabs
{
    public static class SelectionPanel
    {
        public static void Build(UIControlledApplication application, string tabName)
        {

            RibbonPanel selectionPanel = Ribbon.CreateRibbonPanel(application, "Type Selector", tabName);

            PushButtonData wall_byDimension_data = Ribbon
                .CreatePushButtonData("wall_byDimension", 
                                      "WallType\nby Dim", 
                                      "Nina.Selection.WallByDimension"); 

            PushButtonData elementType_switch_up_data = Ribbon
                .CreatePushButtonData("type_switch_up",
                                      "Type\nup",
                                      "Nina.Selection.SwitchUp");

            PushButtonData elementType_switch_down_data = Ribbon
                .CreatePushButtonData("type_switch_down",
                                      "Type\ndown",
                                      "Nina.Selection.SwitchDown");

            //PushButtonData select_all_model_elements_data = Ribbon
            //    .CreatePushButtonData("model_elements_active_view",
            //                          "Model Elements in active view",
            //                          "Nina.Selection.SelectAllModelElements");

            //PushButtonData select_all_anno_elements_data = Ribbon.
            //    CreatePushButtonData("anno_elements_active_view",
            //                         "Annotative Elements in active view",
            //                         "Nina.Selection.SelectAllAnnotationElements");


            //Panel Selection
            PulldownButtonData elementByDimension_data = new PulldownButtonData("byDimension", "WallType by dimension");

            PushButton switchup_button = selectionPanel.AddItem(elementType_switch_up_data) as PushButton;
            PushButton switchdown_button = selectionPanel.AddItem(elementType_switch_down_data) as PushButton;
            PushButton WallByDimension_button = selectionPanel.AddItem(wall_byDimension_data) as PushButton;

            switchup_button.LargeImage = Ribbon.GetIcon("nina_wall_switch_down_30");
            switchdown_button.LargeImage = Ribbon.GetIcon("nina_wall_switch_up_30");
            WallByDimension_button.LargeImage = Ribbon.GetIcon("nina_wall_by_dimension_30");

        }
    }
}
