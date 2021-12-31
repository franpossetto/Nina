﻿using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using System.Linq;

namespace Nina.Selection
{
    [Transaction(TransactionMode.Manual)]
    public class SwitchLocationLine : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Application app = uiApp.Application;
            Document doc = uiDoc.Document;

            try
            {


                Autodesk.Revit.UI.Selection.Selection selection = uiDoc.Selection;

                Element element = doc.GetElement(selection.GetElementIds().FirstOrDefault());
                if (element.GetType() == typeof(Wall)) 
                {
                    Wall wall = element as Wall;
                
                    using (Transaction t = new Transaction(doc, "Transaction Name"))
                    {
                        t.Start();
                        int k = wall.get_Parameter(BuiltInParameter.WALL_KEY_REF_PARAM).AsInteger();
                        if (k == 5) k = -1;
                        wall.get_Parameter(BuiltInParameter.WALL_KEY_REF_PARAM).Set((k+1));
                        t.Commit();
                    }
                }
            }

            catch (System.Exception exp)
            {
                return Autodesk.Revit.UI.Result.Failed;
            }

            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}
