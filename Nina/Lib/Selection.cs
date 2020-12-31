using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Nina.Revit
{
    public class Selection
    {
        public static void All(Document doc, UIDocument uidoc, CategoryType categoryType)
        {
            IList<Element> elements = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType().ToElements();

            IEnumerable<Element> modelElements = elements.Where(e => e.Category != null && e.Category.CategoryType == categoryType);

            List<ElementId> modelElementsId = modelElements.Select(x => x.Id).ToList();
            uidoc.Selection.SetElementIds(modelElementsId);
        }
    }
}
