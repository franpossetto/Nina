using System;
using System.IO;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Newtonsoft.Json;
using Nina.Ribbon;
using static System.Environment;
using Nina.Language;

namespace Nina.Common
{
    [Transaction(TransactionMode.Manual)]
    public class Logs : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            string path = $"{ GetFolderPath(SpecialFolder.CommonApplicationData) }/Autodesk/ApplicationPlugins/Nina.bundle/";


            List<ButtonInfo> bi = JsonConvert.DeserializeObject<List<ButtonInfo>>(File.ReadAllText(path + "en.json"));

            return Result.Succeeded;
        }
    }

   

}