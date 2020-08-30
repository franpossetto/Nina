using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using Nina.Revit;

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
            const string RIBBON_TAB = "Nina";
            Ribbon.CreateRibbonTab(application, RIBBON_TAB);

            /// <summary>
            /// Create a new Panel on Ribbon Tab.
            /// </summary>

            const string INFO_PANEL = "Info";
            const string VISIBILITY_PANEL = "Visibility";
            const string SELECTION_PANEL = "Selection";
            //const string CREATION_PANEL = "Creation";


            RibbonPanel infoPanel = Ribbon.CreateRibbonPanel(application, INFO_PANEL, RIBBON_TAB);
            //RibbonPanel creationPanel = Ribbon.CreateRibbonPanel(application, CREATION_PANEL, RIBBON_TAB);
            RibbonPanel selectionPanel = Ribbon.CreateRibbonPanel(application, SELECTION_PANEL, RIBBON_TAB);
            RibbonPanel visibilityPanel = Ribbon.CreateRibbonPanel(application, VISIBILITY_PANEL, RIBBON_TAB);
            
            #region Colors - Icons
            System.Drawing.Bitmap ico1 = Properties.Resources.dark;
            System.Windows.Media.Imaging.BitmapSource icon1 = Ribbon.Icon(ico1);

            System.Drawing.Bitmap ico2 = Properties.Resources.green;
            System.Windows.Media.Imaging.BitmapSource icon2 = Ribbon.Icon(ico2);

            System.Drawing.Bitmap ico3 = Properties.Resources.dark;
            System.Windows.Media.Imaging.BitmapSource icon3 = Ribbon.Icon(ico3);

            System.Drawing.Bitmap ico4 = Properties.Resources.green;
            System.Windows.Media.Imaging.BitmapSource icon4 = Ribbon.Icon(ico4);

            System.Drawing.Bitmap ico5 = Properties.Resources.red;
            System.Windows.Media.Imaging.BitmapSource icon5 = Ribbon.Icon(ico5);

            System.Drawing.Bitmap ico6 = Properties.Resources.gray;
            System.Windows.Media.Imaging.BitmapSource icon6 = Ribbon.Icon(ico6);

            System.Drawing.Bitmap ico7 = Properties.Resources.purple;
            System.Windows.Media.Imaging.BitmapSource icon7 = Ribbon.Icon(ico7);

            System.Drawing.Bitmap ico8 = Properties.Resources.wall_by_dimension;
            System.Windows.Media.Imaging.BitmapSource icon8 = Ribbon.Icon(ico8);

            System.Drawing.Bitmap ico9 = Properties.Resources.wall_switch_up;
            System.Windows.Media.Imaging.BitmapSource icon9 = Ribbon.Icon(ico9);

            System.Drawing.Bitmap ico10 = Properties.Resources.wall_switch_down;
            System.Windows.Media.Imaging.BitmapSource icon10 = Ribbon.Icon(ico10);

            System.Drawing.Bitmap ico11 = Properties.Resources.info;
            System.Windows.Media.Imaging.BitmapSource icon11 = Ribbon.Icon(ico11);

            System.Drawing.Bitmap ico12 = Properties.Resources.walltype_creation;
            System.Windows.Media.Imaging.BitmapSource icon12 = Ribbon.Icon(ico12);

            System.Drawing.Bitmap ico13 = Properties.Resources.pointcloud;
            System.Windows.Media.Imaging.BitmapSource icon13 = Ribbon.Icon(ico13);

            System.Drawing.Bitmap ico14 = Properties.Resources.pointcloud_yellow;
            System.Windows.Media.Imaging.BitmapSource icon14 = Ribbon.Icon(ico14);

            System.Drawing.Bitmap ico15 = Properties.Resources.pointcloud_red;
            System.Windows.Media.Imaging.BitmapSource icon15 = Ribbon.Icon(ico15);

            System.Drawing.Bitmap ico16 = Properties.Resources.links_hide;
            System.Windows.Media.Imaging.BitmapSource icon16 = Ribbon.Icon(ico16);

            System.Drawing.Bitmap ico17 = Properties.Resources.select_model_elements;
            System.Windows.Media.Imaging.BitmapSource icon17 = Ribbon.Icon(ico17);

            System.Drawing.Bitmap ico18 = Properties.Resources.select_ann_elements;
            System.Windows.Media.Imaging.BitmapSource icon18 = Ribbon.Icon(ico18);

            System.Drawing.Bitmap ico19 = Properties.Resources.sel_all;
            System.Windows.Media.Imaging.BitmapSource icon19 = Ribbon.Icon(ico19);

            #endregion

            #region About Panel

            const string about_name = "About";
            const string about_desc = "About";
            PushButtonData about_button = Ribbon.CreatePushButtonData(about_name,
                                                                      about_desc,
                                                                      "Nina.About");
            about_button.Image = icon1;

            const string repo_name = "Repo";
            const string repo_desc = "Github Repository";
            PushButtonData repo_button = Ribbon.CreatePushButtonData(repo_name,
                                                                     repo_desc,
                                                                     "Nina.Github");
            about_button.Image = icon1;

            const string docs_name = "Docs";
            const string docs_desc = "Docs";
            PushButtonData docs_button = Ribbon.CreatePushButtonData(docs_name,
                                                                     docs_desc,
                                                                     "Nina.About");
            about_button.Image = icon1;


            PulldownButtonData info_button = new PulldownButtonData("Info_button", "Info");
            info_button.LargeImage = icon11;

            PulldownButton info_pullDownButton = infoPanel.AddItem(info_button) as PulldownButton;

            info_pullDownButton.AddPushButton(about_button);
            info_pullDownButton.AddPushButton(repo_button);
            info_pullDownButton.AddPushButton(docs_button);

            #endregion

            #region Creation
            //const string wallTypesBatchCreation_name= "walltype_batchCreation";
            //const string wallTypesBatchCreation_desc = "WallType \n Batch Creation";
            //PushButtonData wallTypesBatchCreation_button = Ribbon.CreatePushButtonData(wallTypesBatchCreation_name,
            //                                                                    wallTypesBatchCreation_desc,
            //                                                                    "Nina.Creation.Batch.WallTypes");

            //wallTypesBatchCreation_button.Image = icon8;
            //PushButton wallTypesBatchCreation_pushButton = creationPanel.AddItem(wallTypesBatchCreation_button) as PushButton;
            //wallTypesBatchCreation_pushButton.LargeImage = icon12;


            #endregion

            #region Selection Panel
            const string wall_byDimension_name = "wall_byDimension";
            const string wall_byDimension_desc = "WallType \n by Dimension";
            PushButtonData wall_byDimension_button = Ribbon.CreatePushButtonData(wall_byDimension_name,
                                                                                wall_byDimension_desc,
                                                                                "Nina.Selection.WallByDimension");
            wall_byDimension_button.Image = icon8;

            const string elementType_switch_up_name = "elementType_switch_up";
            const string elementType_switch_up_desc = "FamilyType \n switch-up";
            PushButtonData elementType_switch_up_button = Ribbon.CreatePushButtonData(elementType_switch_up_name,
                                                                                  elementType_switch_up_desc,
                                                                                  "Nina.Selection.WallSwitchUp");
            elementType_switch_up_button.Image = icon9;

            const string elementType_switch_down_name = "elementType_switch_down";
            const string elementType_switch_down_desc = "FamilyType \n switch-down";
            PushButtonData elementType_switch_down_button = Ribbon.CreatePushButtonData(elementType_switch_down_name,
                                                                                  elementType_switch_down_desc,
                                                                                  "Nina.Selection.WallSwitchDown");
            elementType_switch_down_button.Image = icon10;



            PushButton item16 = selectionPanel.AddItem(wall_byDimension_button) as PushButton;
            item16.LargeImage = icon8;

            selectionPanel.AddSeparator();

            PushButton item17 = selectionPanel.AddItem(elementType_switch_up_button) as PushButton;
            item17.LargeImage = icon9;


            PushButton item18 = selectionPanel.AddItem(elementType_switch_down_button) as PushButton;
            item18.LargeImage = icon10;

            const string select_all_model_elements_name = "model_lements_active_view";
            const string select_all_model_elements_desc = "Model Elements in active view";
            PushButtonData select_all_model_elements_button = Ribbon.CreatePushButtonData(select_all_model_elements_name,
                                                                                   select_all_model_elements_desc,
                                                                                   "Nina.Selection.SelectAllModelElements");


            select_all_model_elements_button.LargeImage = icon17;

            const string select_all_model_elements_name2 = "annotative_elements_active_view";
            const string select_all_model_elements_desc2 = "Annotative Elements in active view";
            PushButtonData select_all_model_elements_button2 = Ribbon.CreatePushButtonData(select_all_model_elements_name2,
                                                                                   select_all_model_elements_desc2,
                                                                                   "Nina.Selection.SelectAllModelElements");

            selectionPanel.AddSeparator();

            select_all_model_elements_button2.LargeImage = icon18;
            #endregion

            PulldownButtonData selectAllPullButton = new PulldownButtonData("selectAll", "Select \n All");
            PulldownButton selectAllGroup = selectionPanel.AddItem(selectAllPullButton) as PulldownButton;
            selectAllGroup.LargeImage = icon19;
            
            PushButton _item1 = selectAllGroup.AddPushButton(select_all_model_elements_button) as PushButton;
            //selectAllGroup.AddSeparator();
            PushButton _item2 = selectAllGroup.AddPushButton(select_all_model_elements_button2) as PushButton;

            #region Visibility Panel
            //PulldownButtonData changeModeGroup = new PulldownButtonData("PulldownGroup1", "Pulldown Group 1");
            //changeModeGroup.ToolTip = changeModeGroup.Text;
            //changeModeGroup.Image = icon7;

            const string pointcloud_hide_name = "pointcloud_hide";
            const string pointcloud_hide_desc = "Hide Point Cloud";
            PushButtonData pointcloud_hide_button = Ribbon.CreatePushButtonData(pointcloud_hide_name,
                                                                                pointcloud_hide_desc,
                                                                                "Nina.Visibility.Hide");
            pointcloud_hide_button.Image = icon1;


            const string pointcloud_elevation_name = "pointcloud_elevation";
            const string pointcloud_elevation_desc = "Set Elevation";
            PushButtonData pointcloud_elevation_button = Ribbon.CreatePushButtonData(pointcloud_elevation_name,
                                                                                     pointcloud_elevation_desc,
                                                                                     "Nina.Visibility.SetElevation");

            const string pointcloud_fixedColor_name = "pointcloud_fixedColor";
            const string pointcloud_fixedColor_desc = "Set Fixed Color";
            PushButtonData pointcloud_fixedColor_button = Ribbon.CreatePushButtonData(pointcloud_fixedColor_name,
                                                                                      pointcloud_fixedColor_desc,
                                                                                      "Nina.Visibility.SetFixedColor");

            const string pointcloud_intensity_name = "pointcloud_intensity";
            const string pointcloud_intensity_desc = "Set Intensity";
            PushButtonData pointcloud_intensity_button = Ribbon.CreatePushButtonData(pointcloud_intensity_name,
                                                                                     pointcloud_intensity_desc,
                                                                                     "Nina.Visibility.SetIntensity");

            const string pointcloud_noOverride_name = "pointcloud_noOverride";
            const string pointcloud_noOverride_desc = "Set No Override";
            PushButtonData pointcloud_noOverride_button = Ribbon.CreatePushButtonData(pointcloud_noOverride_name,
                                                                                      pointcloud_noOverride_desc,
                                                                                      "Nina.Visibility.SetNoOverride");

            const string pointcloud_normals_name = "pointcloud_normals";
            const string pointcloud_normals_desc = "Set Normals";
            PushButtonData pointcloud_normals_button = Ribbon.CreatePushButtonData(pointcloud_normals_name,
                                                                                   pointcloud_normals_desc,
                                                                                   "Nina.Visibility.SetNormals");
            // A PulldownButton data
            PulldownButtonData ChangeModeGroup = new PulldownButtonData("ChangeMode", "Point Clouds Color Mode");
            ChangeModeGroup.ToolTip = "PointCloud visibility change mode";
            ChangeModeGroup.Image = icon6;

            const string links_show_name = "show_links";
            const string links_show_desc = "Show/Hide \n Revit Links";
            PushButtonData links_show_button = Ribbon.CreatePushButtonData(links_show_name,
                                                                                links_show_desc,
                                                                                "Nina.Visibility.HideRevitLinks");

            PushButton item19 = visibilityPanel.AddItem(links_show_button) as PushButton;
            item19.LargeImage = icon16;

            const string pointCloud_show_name = "show_pointcloud";
            const string pointCloud_show_desc = "Show/Hide\n Point Clouds";
            PushButtonData pointCloud_show_button = Ribbon.CreatePushButtonData(pointCloud_show_name,
                                                                                pointCloud_show_desc,
                                                                                "Nina.Visibility.Hide");

            pointCloud_show_button.Image = icon14;

            //const string cad_show_name = "show_acad";
            //const string cad_show_desc = "Show\n ACAD Links";
            //PushButtonData cad_show_button = Ribbon.CreatePushButtonData(cad_show_name,
            //                                                            cad_show_desc,
            //                                                            "Nina.Visibility.Hide");

            //cad_show_button.Image = icon5;

            const string pointCloud_hideT_name = "hide_pointcloud";
            const string pointCloud_hideT_desc = "Hide Temporary\n Point Clouds";
            PushButtonData pointCloud_hideT_button = Ribbon.CreatePushButtonData(pointCloud_hideT_name,
                                                                                pointCloud_hideT_desc,
                                                                                "Nina.Visibility.HideTemporary");

            pointCloud_hideT_button.Image = icon15;

            IList<RibbonItem> changeModeGroup = visibilityPanel.AddStackedItems(pointCloud_show_button,
                                                                                pointCloud_hideT_button,
                                                                                ChangeModeGroup
                                                                                );

            PulldownButton changeModeGrougPullDownButton = changeModeGroup[2] as PulldownButton;


            PushButton item1 = changeModeGrougPullDownButton.AddPushButton(pointcloud_elevation_button) as PushButton;
            item1.LargeImage = icon3;

            PushButton item2 = changeModeGrougPullDownButton.AddPushButton(pointcloud_fixedColor_button) as PushButton;
            item2.LargeImage = icon5;

            PushButton item3 = changeModeGrougPullDownButton.AddPushButton(pointcloud_intensity_button) as PushButton;
            item3.LargeImage = icon4;

            PushButton item4 = changeModeGrougPullDownButton.AddPushButton(pointcloud_noOverride_button) as PushButton;
            item4.LargeImage = icon6;

            PushButton item5 = changeModeGrougPullDownButton.AddPushButton(pointcloud_normals_button) as PushButton;
            item5.LargeImage = icon7;





            #endregion



            return Result.Succeeded;


        }
    }
}
