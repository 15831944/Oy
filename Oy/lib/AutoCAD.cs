using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

namespace Oy.CAD2006.lib
{
    class AutoCAD
    {
        //在模型空间中显示一行文字
         protected internal static void Greating()
        {
            // Get the current document and database, and start a transaction
            Autodesk.AutoCAD.ApplicationServices.Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // Starts a new transaction with the Transaction Manager
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Block table record for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                             OpenMode.ForRead) as BlockTable;

                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                OpenMode.ForWrite) as BlockTableRecord;

                /* Creates a new MText object and assigns it a location,
                text value and text style */
                MText objText = new MText();

                // Set the default properties for the MText object
                objText.SetDatabaseDefaults();

                // Specify the insertion point of the MText object
                objText.Location = new Autodesk.AutoCAD.Geometry.Point3d(2, 2, 0);

                // Set the text string for the MText object
                objText.Contents = "Greetings22222222, Welcome to the AutoCAD .NET Developer's Guide";

                // Set the text style for the MText object
                objText.TextStyle = acCurDb.Textstyle;

                // Appends the new MText object to model space
                acBlkTblRec.AppendEntity(objText);

                // Appends to new MText object to the active transaction
                acTrans.AddNewlyCreatedDBObject(objText, true);

                // Saves the changes to the database and closes the transaction
                acTrans.Commit();
            }
        }
    }
}
