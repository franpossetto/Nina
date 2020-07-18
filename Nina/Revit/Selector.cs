﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
namespace Nina.Revit
{
    public class Selector
    {
        public class WallFamilyType
        {
            public WallType walltype { get; set; }
            public string family { get; set; }
            public string type { get; set; }
            public string key { get; set; }
        }

        public static void ElementSwitch(UIDocument uiDoc, Document doc, bool order)
        {

            #region Selection Stuff

            //Get Selected Elements IDs.
            ICollection<ElementId> selectedIds = uiDoc.Selection.GetElementIds();

            #endregion

            Element element = doc.GetElement(selectedIds.FirstOrDefault());
            ElementId categoryId = element.Category.Id;

            //ICollection<ElementId> elementTypesId = new FilteredElementCollector(doc).OfCategoryId(categoryId).WhereElementIsElementType().ToElementIds();

            ICollection<WallType> walls = new FilteredElementCollector(doc)
                                                .OfCategoryId(categoryId).WhereElementIsElementType()
                                                .Cast<WallType>()
                                                .Where(w => w.Kind == WallKind.Basic)
                                                .ToList();

            List<WallFamilyType> wallTypeList = new List<WallFamilyType>();
            foreach(WallType wallType in walls)
            {
                WallFamilyType w = new WallFamilyType();
                w.walltype = wallType;
                w.family = wallType.FamilyName;
                w.type = wallType.Name;
                w.key = w.family+"-"+w.type;

                wallTypeList.Add(w);
            }

            //IList<ElementId> elementIds = walls.Select(x => x.Id).ToList();

            //IList<ElementId> elementTypesId = elementIds.OrderBy(x => doc.GetElement(x).Name).ToList();

            IList<WallFamilyType> elementTypesOrdered = wallTypeList.OrderBy(x => x.key).ToList();

            Wall wall = element as Wall;
            WallType elementType = wall.WallType;
            ElementId elementTypeId = elementType.Id;


            int index = 0;
            int n = 0;
            //up
            if (order)
            {
                foreach (WallFamilyType wft in elementTypesOrdered)
                {
                    if (wft.walltype.Id == elementTypeId)
                    {
                        index = n - 1;
                        if (index == -1)
                            index = elementTypesOrdered.Count() - 1;
                    }

                    n++;
                }
            }
            else
            {
                foreach (WallFamilyType wft in elementTypesOrdered)
                {
                    if (wft.walltype.Id == elementTypeId)
                    {
                        index = n + 1;
                        if (index >= elementTypesOrdered.Count())
                            index = 0;
                    }

                    n++;
                }
            }



            ElementId newSelectedId = elementTypesOrdered.ToList()[index].walltype.Id;
            ElementType selectedElementType = doc.GetElement(newSelectedId) as ElementType;


            //ElementId selectedElementTypeId = elementTypesId.Where(x => x == elementTypeId).FirstOrDefault();
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