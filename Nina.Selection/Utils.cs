using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text.RegularExpressions;
using Nina.Selection.Model;
using Settings = Nina.Common.Settings;

namespace Nina.Selection
{
    public class Utils
    {
        public static string PadNumbers(string input)
        {
            return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }
        public static string TransformValueIfNecessary(Document doc, double _value)
        {
            double newValue = _value;

            // It can be IMPERIAL or METRIC
            DisplayUnit currentUnit = doc.DisplayUnitSystem;
            if (currentUnit.ToString() == "METRIC") newValue = _value / 3.281;
            return Math.Round(newValue, 2).ToString();
        }
        public static void ElementSwitch(UIDocument uiDoc, Document doc, bool order)
        {

            #region Selection Stuff

            //Get Selected Elements IDs.
            ICollection<ElementId> selectedIds = uiDoc.Selection.GetElementIds();

            #endregion

            Element element = doc.GetElement(selectedIds.FirstOrDefault());
            ElementId categoryId = element.Category.Id;


            ElementId elementtypeid = element.GetTypeId();
            List<ElementId> elementTypes = element.GetValidTypes().ToList();


            List<ElementTypeSelector> etype = new List<ElementTypeSelector>();
            foreach (ElementId eid in elementTypes)
            {
                ElementTypeSelector e = new ElementTypeSelector();
                ElementType el = doc.GetElement(eid) as ElementType;
                e.elementtype = el;
                e.family = el.FamilyName;
                e.type = el.Name;
                e.key = e.family + "-" + e.type;
                etype.Add(e);
            }

            IList<ElementTypeSelector> elementTypesOrdered = etype.OrderBy(x => PadNumbers(x.key)).ToList();
            int index = 0;
            int n = 0;
            
            //up
            if (order)
            {
                foreach (ElementTypeSelector et in elementTypesOrdered)
                {
                    if (et.elementtype.Id == elementtypeid)
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
                foreach (ElementTypeSelector et in elementTypesOrdered)
                {
                    if (et.elementtype.Id == elementtypeid)
                    {
                        index = n + 1;
                        if (index >= elementTypesOrdered.Count())
                            index = 0;
                    }

                    n++;
                }
            }


            ElementId newSelectedId = elementTypesOrdered.ToList()[index].elementtype.Id;
            ElementType selectedElementType = doc.GetElement(newSelectedId) as ElementType;

            using (Transaction t = new Transaction(doc, "ElementType Switch"))
            {
                t.Start();
                element.ChangeTypeId(selectedElementType.Id);
                t.Commit();
            }
        }
        public static void WallSwitch(UIDocument uiDoc, Document doc, bool order)
        {

            #region Selection Stuff

            //Get Selected Elements IDs.
            ICollection<ElementId> selectedIds = uiDoc.Selection.GetElementIds();

            #endregion

            Element element = doc.GetElement(selectedIds.FirstOrDefault());
            if (!element.Category.Name.Contains("Wall"))
                return;


            ElementId elementtypeid = element.GetTypeId();
            List<ElementId> wallTypeId = element.GetValidTypes().ToList();
            List<WallType> walls = wallTypeId.Select(x => ((WallType)doc.GetElement(x))).ToList();

            List<WallFamilyType> wallTypeList = new List<WallFamilyType>();
            foreach (WallType wallType in walls)
            {
                WallFamilyType w = new WallFamilyType();
                w.walltype = wallType;
                w.family = wallType.FamilyName;
                w.type = wallType.Name;
                w.key = w.family + "-" + w.type;

                wallTypeList.Add(w);
            }

            IList<WallFamilyType> elementTypesOrdered = wallTypeList.OrderBy(x => PadNumbers(x.key)).ToList();

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

            using (Transaction t = new Transaction(doc, "Walltype Switch"))
            {
                t.Start();
                wall.WallType = selectedElementType as WallType;
                t.Commit();
            }
        }
        public static void SelectWall(UIDocument uiDoc, Document doc, double measure)
        {

            bool exist = WallTypeExist(doc, measure);
            if (!exist && Settings.Preferences.CreateWallType) CreateWall(uiDoc, doc, measure);

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
                if (i == 0 || dist < min)
                {
                    min = dist;
                    wallType = wt;
                }
            }

            uiDoc.PostRequestForElementTypePlacement(wallType);
        }
        public static void CreateWall(UIDocument uiDoc, Document doc, double measure)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ElementClassFilter filter = new ElementClassFilter(typeof(WallType));
            collector.WherePasses(filter);

            List<WallType> types = collector.Cast<WallType>().ToList();
            WallType selectedWallType = types.Where(t => t.FamilyName == Settings.Preferences.WallTypeSelected).FirstOrDefault();
            if (selectedWallType == null) selectedWallType = types.Where(t => t.FamilyName.Contains("Basic")).FirstOrDefault();

            string name = Settings.Preferences.WallTypePrefix;
            string m = Utils.TransformValueIfNecessary(doc, measure);
            string newWallTypeName = name + m;
            using (Transaction t = new Transaction(doc, "Create WallType"))
            {
                t.Start();

                WallType newWallType = selectedWallType.Duplicate(newWallTypeName) as WallType;
                CompoundStructure compoundStructure = newWallType.GetCompoundStructure();
                int layerIndex = compoundStructure.GetFirstCoreLayerIndex();
                IList<CompoundStructureLayer> csLayers = compoundStructure.GetLayers();
                foreach (CompoundStructureLayer csl in csLayers)
                {
                    if (csl.Function.ToString() == "Structure")
                    {
                        if (csl.Width == newWallType.Width) compoundStructure.SetLayerWidth(layerIndex, measure);
                        else compoundStructure.SetLayerWidth(layerIndex, measure - (newWallType.Width - csl.Width));
                    }
                }
                newWallType.SetCompoundStructure(compoundStructure);
                t.Commit();
            }

        }
        public static bool WallTypeExist(Document doc, double measure)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ElementClassFilter filter = new ElementClassFilter(typeof(WallType));
            collector.WherePasses(filter);

            List<WallType> types = collector.Cast<WallType>().ToList();
            double tolerance = Settings.Preferences.Tolerance;

#if R2017 || R2018 || R2019 || R2020
            double a = UnitUtils.Convert(tolerance, DisplayUnitType.DUT_METERS, DisplayUnitType.DUT_DECIMAL_FEET);
#endif

#if R2021 || R2022
                double a = UnitUtils.Convert(tolerance, UnitTypeId.Meters, UnitTypeId.Feet);
#endif

            bool exist = types.Any(w => (w.Width - tolerance) <= measure && (w.Width + tolerance) >= measure);
            return exist;
        }
    }
}