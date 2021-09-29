using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using Nina.Ribbon;
using Nina.Tabs;

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
            AddinsPanel.Build(application);

            const string RIBBON_TAB = "Nina";
            Utils.CreateRibbonTab(application, RIBBON_TAB);
            NinaPanel.Build(application, RIBBON_TAB);
            SelectionPanel.Build(application, RIBBON_TAB);
            Views.Build(application, RIBBON_TAB);
            PointCloudPanel.Build(application, RIBBON_TAB);
            LinksPanel.Build(application, RIBBON_TAB);



            return Result.Succeeded;


        }
    }
}