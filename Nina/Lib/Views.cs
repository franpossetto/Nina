using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;

namespace Nina.Revit
{
    public static class Views
    {
        public static void Open(Document doc, UIDocument uiDoc, List<ElementId> viewIds)
        {
            foreach (ElementId id in viewIds)
            {
                try
                {
                    View view = doc.GetElement(id) as View;
                    uiDoc.RequestViewChange(view);
                } catch
                {
                    // cannot do it.
                }
            }
        }
    }
}
