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
            const string RIBBON_TAB = "BBr";
            Ribbon.CreateRibbonTab(application, RIBBON_TAB);

            /// <summary>
            /// Create a new Panel on Ribbon Tab.
            /// </summary>

            const string RIBBON_PANEL = "Scan to BIM";
            RibbonPanel ribbonPanel = Ribbon.CreateRibbonPanel(application, RIBBON_PANEL, RIBBON_TAB);

            /// <summary>
            /// Create new Buttons on Panel.
            /// </summary>
            /// 
            const string pointcloud_hide_name = "pointcloud_hide";
            const string pointcloud_hide_desc = "Hide Point Cloud";

            const string pointcloud_unhide_name = "pointcloud_unhide";
            const string pointcloud_unhide_desc = "Show Point Cloud";

            const string pointcloud_normals_name = "pointcloud_normals";
            const string pointcloud_normals_desc = "Set Normals";

            PushButtonData pointcloud_hide_button = Ribbon.CreatePushButtonData(pointcloud_hide_name, pointcloud_hide_desc, "Nina.Hide");
            PushButtonData pointcloud_unhide_button = Ribbon.CreatePushButtonData(pointcloud_unhide_name, pointcloud_unhide_desc, "Nina.Unhide");
            PushButtonData pointcloud_normals_button = Ribbon.CreatePushButtonData(pointcloud_normals_name, pointcloud_normals_desc, "Nina.ChangeColorMode");




            //PushButton hide_pushButton = ribbonPanel.AddItem(pointcloud_hide_button) as PushButton;
            System.Drawing.Bitmap ico1 = Properties.Resources.dark;
            System.Windows.Media.Imaging.BitmapSource icon1 = Ribbon.Icon(ico1);
            pointcloud_hide_button.Image = icon1;

            //PushButton unhide_pushButton = ribbonPanel.AddItem(pointcloud_unhide_button) as PushButton;
            System.Drawing.Bitmap ico2 = Properties.Resources.green;
            System.Windows.Media.Imaging.BitmapSource icon2 = Ribbon.Icon(ico2);
            pointcloud_unhide_button.Image = icon2;

            System.Drawing.Bitmap ico3 = Properties.Resources.purple;
            System.Windows.Media.Imaging.BitmapSource icon3 = Ribbon.Icon(ico3);
            pointcloud_normals_button.Image = icon3;

            ribbonPanel.AddStackedItems(pointcloud_hide_button, pointcloud_unhide_button, pointcloud_normals_button);


            return Result.Succeeded;


        }
    }
}
