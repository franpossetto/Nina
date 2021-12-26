using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Nina.Ribbon;

namespace Nina.Tabs
{
    public static class SelectionPanel
    {
        public static List<ButtonInfo> Language { get; set; }

        public static void Build(UIControlledApplication application, string tabName)
        {

            RibbonPanel selectionPanel = Utils.CreateRibbonPanel(application, "Type Selector", tabName);

            ButtonInfo buttonInfo_TypeUp = Language.Where(button => button.Id == "TypeUp").FirstOrDefault();
            ButtonInfo buttonInfo_TypeDown = Language.Where(button => button.Id == "TypeDown").FirstOrDefault();
            ButtonInfo buttonInfo_WallByDim = Language.Where(button => button.Id == "WallTypeByDimension").FirstOrDefault();
            
            string typeup_button_name = buttonInfo_TypeUp.Title ?? "Type\nUp";
            string typedown_button_name = buttonInfo_TypeDown.Title ?? "Type\nDown";
            string wall_by_dim_button_name = buttonInfo_WallByDim.Title ?? "WallType\nby Dim";

            PushButtonData wall_byDimension_data = Utils
                .CreatePushButtonData("wall_byDimension",
                                      wall_by_dim_button_name, 
                                      "Nina.Selection.WallByDimension");

            wall_byDimension_data.LongDescription = "Put the long description here";
            wall_byDimension_data.ToolTip = "Put the Tooltip here";
            // wall_byDimension_data.ToolTipImage = 

            PushButtonData elementType_switch_up_data = Utils
                .CreatePushButtonData("type_switch_up",
                                      typeup_button_name,
                                      "Nina.Selection.SwitchUp");

            elementType_switch_up_data.LongDescription = "Put the long description here";
            elementType_switch_up_data.ToolTip = "Put the Tooltip here";
            // elementType_switch_up_data.ToolTipImage = 

            PushButtonData elementType_switch_down_data = Utils
                .CreatePushButtonData("type_switch_down",
                                      typedown_button_name,
                                      "Nina.Selection.SwitchDown");

            elementType_switch_down_data.LongDescription = "Put the long description here";
            elementType_switch_down_data.ToolTip = "Put the Tooltip here";
            // elementType_switch_down_data.ToolTipImage = 

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

            switchup_button.LargeImage = Utils.GetIcon("nina_wall_switch_down_30");
            switchdown_button.LargeImage = Utils.GetIcon("nina_wall_switch_up_30");
            WallByDimension_button.LargeImage = Utils.GetIcon("nina_wall_by_dimension_30");

        }
    }
}
