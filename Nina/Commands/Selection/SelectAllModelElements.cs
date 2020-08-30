using System;
using System.Collections;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Collections.Generic;

namespace Nina.Selection
{
    [Transaction(TransactionMode.Manual)]
    public class SelectAllModelElements : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                Document doc = commandData.Application.ActiveUIDocument.Document;
                UIDocument uidoc = commandData.Application.ActiveUIDocument;


                IList<Element> _elements = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType().ToElements();



                IEnumerable<Element> modelElements = _elements.Where(e => e.Category != null && e.Category.CategoryType == CategoryType.Model);

                List<ElementId> modelElementsId = modelElements.Select(x => x.Id).ToList();

                //TaskDialog.Show("R", modelElementsId.ToString());
                uidoc.Selection.SetElementIds(modelElementsId);

                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch(Exception e)
            {
                TaskDialog.Show("R", e.ToString());
                return Autodesk.Revit.UI.Result.Failed;
            }

        }
    }
}

