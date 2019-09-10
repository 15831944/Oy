using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Oy.CAD2006.CommandMethod;
using Autodesk.AutoCAD.Geometry;
using AutoCADCommands;
using System.Linq;
using System.Collections.Generic;

[assembly: CommandClass(typeof(CommandMethod))]
namespace Oy.CAD2006.CommandMethod
{
    public class CommandMethod
    {
        [CommandMethod("TT")]
        public void OpenMainForm() => Application.ShowModalDialog(Application.MainWindow, new GUI.MainForm());



        [CommandMethod("test")]
        public static void Test()
        {
            ObjectId[] objectId = Interaction.GetSelection("\n选择多段线", "LWPOLYLINE");//选择多段线
            if (objectId.Length == 0) return;//一个都没选的情况下退出操作
            objectId.QForEach<Polyline>(polyline =>
            {
                int length = (int)polyline.EndParam;


                for (int i = 0; i <= length; i++)
                {

                    Line l1 = NoDraw.Line(polyline.GetPreviousPointAtParam(i), polyline.GetPointAtParam(i));
                    Line l2 = NoDraw.Line( polyline.GetPointAtParam(i),polyline.GetNextPointAtParam(i));
                    // Checks if lines intersect
                    Plane plane;
                    Line3d line1 = new Line3d(l1.StartPoint, l1.EndPoint);
                    Line3d line2 = new Line3d(l2.StartPoint, l2.EndPoint);
                    if (!line1.IsCoplanarWith(line2, out plane) || line1.IsParallelTo(line2))
                        return;

                    // Calculates the bisector
                    Point3d inters = line1.IntersectWith(line2)[0];
                    Vector3d vec1 = line1.Direction;
                    Vector3d vec2 = line2.Direction;
                    Vector3d bisectDir = (vec1 - vec2) / 2.0;
                    var angle = bisectDir.GetAngleTo(Vector3d.XAxis);

                    Xline xline = new Xline();
                    xline.UnitDir = bisectDir.GetNormal();
                    xline.BasePoint = inters;
                    Draw.Text((i+1).ToString(),2, xline.GetPointAtDist(1));
                    Draw.Circle(polyline.GetPointAtParam(i),0.5);
                }
            });
        }



        [CommandMethod("Bisect")]
        public void Bisector()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            PromptEntityOptions peo = new PromptEntityOptions("\nSelect the first line: ");
            peo.SetRejectMessage("Selected object is not a line !");
            peo.AddAllowedClass(typeof(Line), true);
            PromptEntityResult per = ed.GetEntity(peo);
            if (per.Status != PromptStatus.OK) return;
            Point3d p1 = per.PickedPoint.TransformBy(ed.CurrentUserCoordinateSystem);
            ObjectId id1 = per.ObjectId;
            peo.Message = "\nSelect the second line: ";
            per = ed.GetEntity(peo);
            if (per.Status != PromptStatus.OK) return;
            Point3d p2 = per.PickedPoint.TransformBy(ed.CurrentUserCoordinateSystem);
            ObjectId id2 = per.ObjectId;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                Line l1 = (Line)tr.GetObject(id1, OpenMode.ForRead);
                Line l2 = (Line)tr.GetObject(id2, OpenMode.ForRead);

                // Checks if lines intersect
                Plane plane;
                Line3d line1 = new Line3d(l1.StartPoint, l1.EndPoint);
                Line3d line2 = new Line3d(l2.StartPoint, l2.EndPoint);
                if (!line1.IsCoplanarWith(line2, out plane) || line1.IsParallelTo(line2))
                    return;

                // Calculates the bisector
                Point3d inters = line1.IntersectWith(line2)[0];
                Vector3d vec1 = line1.Direction;
                Vector3d vec2 = line2.Direction;
                // Corrects the vectors direction according to picked points
                if (vec1.DotProduct(inters.GetVectorTo(p1)) < 0)
                    vec1 = vec1.Negate();
                if (vec2.DotProduct(inters.GetVectorTo(p2)) < 0)
                    vec2 = vec2.Negate();
                Vector3d bisectDir = (vec1 + vec2) / 2.0;

                // Draws the bisector (XLine)
                Xline xline = new Xline();
                xline.UnitDir = bisectDir.GetNormal();
                xline.BasePoint = inters;
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
                btr.AppendEntity(xline);
                tr.AddNewlyCreatedDBObject(xline, true);
                tr.Commit();
            }
        }



    }
}