using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;

namespace Nina.Revit
{
    public static class Validations
    {
        public static bool CheckRevitVersion(Application app, string version)
        {
            //Check Revit Version
            if (!app.VersionName.Contains(version))
            {
                using (TaskDialog taskDialog = new TaskDialog("Cannot Continue"))
                {
                    taskDialog.TitleAutoPrefix = false;
                    taskDialog.MainInstruction = "Incompatible Version of Revit";
                    taskDialog.MainContent = "Main Content";
                    taskDialog.Show();
                }
                return false;
            }
            else
                return true;
        }
    }
}
