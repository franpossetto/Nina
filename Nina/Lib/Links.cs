using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.PointClouds;

namespace Nina.Revit
{
    public class Links
    {
        public static void Hide(Document doc)
        {
            Categories categories = doc.Settings.Categories;
            BuiltInCategory revitLinkCategory = BuiltInCategory.OST_RvtLinks;
            Category linkCategory = categories.get_Item(BuiltInCategory.OST_RvtLinks);
            View activeView = doc.ActiveView;

            bool hide = activeView.GetCategoryHidden(linkCategory.Id) ? false : true;
            PointCloudOverrides pc_ovverides = activeView.GetPointCloudOverrides();

            using (Transaction t = new Transaction(doc, "Point Clouds were hidden"))
            {
                try
                {
                    t.Start();
                    activeView.SetCategoryHidden(linkCategory.Id, hide);
                    t.Commit();
                }
                catch (Exception e)
                {
                    TaskDialog.Show("Exception", e.StackTrace);
                }
            }
        }
    }
}
