using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Nina.Commands.Creation.Batch;

namespace Nina.Creation.Batch
{
    [Transaction(TransactionMode.Manual)]
    public class WallTypes : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                Document doc = commandData.Application.ActiveUIDocument.Document;
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                WallTypeBatchCreation wallTypeBatchCreation = new WallTypeBatchCreation();
                wallTypeBatchCreation.ShowDialog();

                Nina.Revit.FamilyType.WallTypeBatchCreation(doc, 8);
                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch
            {
                message = "Unexpected Exception thrown.";
                return Autodesk.Revit.UI.Result.Failed;
            }

        }
    }
}

