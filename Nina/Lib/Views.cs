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

        public static void OpenFromViewPort(Document doc, UIDocument uiDoc, ICollection<ElementId> viewPortIds)
        {
            foreach (ElementId id in viewPortIds)
            {
                try
                {
                    Viewport viewport = doc.GetElement(id) as Viewport;
                    ElementId viewId = viewport.ViewId;
                    View view = doc.GetElement(viewId) as View;
                    uiDoc.RequestViewChange(view);
                }
                catch
                {
                    // cannot do it.
                }
            }
        }

        public static void OpenActiveView(Document doc, UIDocument uiDoc, View activeView)
        {
            try
            {
                Element e = new FilteredElementCollector(doc).OfClass(typeof(View)).WhereElementIsNotElementType().ToElements().FirstOrDefault();
                View v = e as View;
                uiDoc.RequestViewChange(v);
                uiDoc.RequestViewChange(activeView);
            }
            catch
            {
                // cannot do it.
            }
        }
    }
}
