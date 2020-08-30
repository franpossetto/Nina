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
    public class SelectAllAnnotationElements : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                Document doc = commandData.Application.ActiveUIDocument.Document;
                UIDocument uidoc = commandData.Application.ActiveUIDocument;

                Nina.Revit.Selection.All(doc, uidoc, CategoryType.Annotation);

                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception e)
            {
                TaskDialog.Show("R", e.ToString());
                return Autodesk.Revit.UI.Result.Failed;
            }

        }
    }
}


