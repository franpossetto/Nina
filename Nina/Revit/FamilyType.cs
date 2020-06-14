using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace Nina
{
    public class FamilyType
    {
        public static void SelectWall(UIDocument uiDoc, Document doc, double measure)
        {
            ElementClassFilter filter = new ElementClassFilter(typeof(WallType));
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.WherePasses(filter);

            IList<Element> elements = collector.ToElements();
            WallType wallType = null;
            double min = 0;
            //Get Family Type door from ribbon
            for (int i = 0; i < elements.Count(); i++)
            {
                WallType wt = elements[i] as WallType;
                double w = wt.Width;
                double dist = Math.Abs(w - measure);
                if(i == 0 || dist < min)
                {
                    min = dist;
                    wallType = wt;
                }
            }

            //WallType elementType = collector.Where(e => e.LookupParameter("Width").AsDouble() == measure).FirstOrDefault() as WallType;


            uiDoc.PostRequestForElementTypePlacement(wallType);
        }

        public static void CreateWall(UIDocument uiDoc, Document doc, double measure)
        {
            //Create wall interface

            //naming convention
            //properties
            //copy from

            //Select it.

        }

        public static void WallSwitch(UIDocument uiDoc, Document doc, bool order)
        {


            #region Selection Stuff

            //Get Selected Elements IDs.
            ICollection<ElementId> selectedIds = uiDoc.Selection.GetElementIds();

            #endregion

            Element element = doc.GetElement(selectedIds.FirstOrDefault());
            ElementId categoryId = element.Category.Id;

            //ICollection<ElementId> elementTypesId = new FilteredElementCollector(doc).OfCategoryId(categoryId).WhereElementIsElementType().ToElementIds();

            ICollection<ElementId> elementIds = new FilteredElementCollector(doc).OfCategoryId(categoryId).WhereElementIsElementType().ToElementIds();
            IList<ElementId> elementTypesId = elementIds.OrderBy(x => doc.GetElement(x).Name).ToList();


            Wall wall = element as Wall;
            WallType elementType = wall.WallType ;
            ElementId elementTypeId = elementType.Id;


            int index = 0;
            int n = 0;
            //up
            if (order)
            {
                foreach (ElementId eid in elementTypesId)
                {
                    if (eid == elementTypeId)
                    {
                        index = n - 1;
                        if (index == -1)
                            index = elementTypesId.Count() - 1;
                    }

                    n++;
                }
            } else
            {
                foreach (ElementId eid in elementTypesId)
                {
                    if (eid == elementTypeId)
                    {
                        index = n + 1;
                        if (index >= elementTypesId.Count())
                            index = 0;
                    }

                    n++;
                }
            }
            


            ElementId newSelectedId = elementTypesId.ToList()[index];
            ElementType selectedElementType = doc.GetElement(newSelectedId) as ElementType;


            ElementId selectedElementTypeId = elementTypesId.Where(x => x == elementTypeId).FirstOrDefault();
            //WallType elementType = collector.Where(e => e.LookupParameter("Width").AsDouble() == measure).FirstOrDefault() as WallType;

            //Element ElementE= doc.GetElement(newSelectedId);

            using (Transaction t = new Transaction(doc, "Transaction Name"))
            {
                t.Start();
                // DO something
                wall.WallType = selectedElementType as WallType;
                t.Commit();
            }

            
            //uiDoc.PostRequestForElementTypePlacement(selectedElementType);
        }

    }
}
