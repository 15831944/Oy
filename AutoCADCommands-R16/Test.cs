using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace AutoCADCommands
{
    /// <summary>
    /// test and samples
    /// </summary>
    public class CodePackTest
    {

        #region Commands that you can offer directly in your application


        /// <summary>
        /// Remove duplicated vertices on polyline
        /// </summary>
        [CommandMethod("PolyClean", CommandFlags.UsePickSet)]
        public static void PolyClean()
        {
            ObjectId[] ids = Interaction.GetSelection("\nSelect polyline", "LWPOLYLINE");
            int m = 0;
            int n = 0;
            ids.QForEach<Polyline>(poly =>
            {
                int count = Algorithms.PolyClean_RemoveDuplicatedVertex(poly);
                if (count > 0)
                {
                    m++;
                    n += count;
                }
            });
            Interaction.WriteLine("{1} vertex removed from {0} polyline.", m, n);
        }

        private static double _polyClean2Epsilon = 1;

        /// <summary>
        /// Remove vertices close to others on polyline
        /// </summary>
        [CommandMethod("PolyClean2", CommandFlags.UsePickSet)]
        public static void PolyClean2()
        {
            double epsilon = Interaction.GetValue("\nEpsilon", _polyClean2Epsilon);
            if (double.IsNaN(epsilon))
            {
                return;
            }
            _polyClean2Epsilon = epsilon;

            ObjectId[] ids = Interaction.GetSelection("\nSelect polyline", "LWPOLYLINE");
            int m = 0;
            int n = 0;
            ids.QForEach<Polyline>(poly =>
            {
                int count = Algorithms.PolyClean_ReducePoints(poly, epsilon);
                if (count > 0)
                {
                    m++;
                    n += count;
                }
            });
            Interaction.WriteLine("{1} vertex removed from {0} polyline.", m, n);
        }

        /// <summary>
        /// Fit arc segs of polyline with line segs
        /// </summary>
        [CommandMethod("PolyClean3", CommandFlags.UsePickSet)]
        public static void PolyClean3()
        {
            double value = Interaction.GetValue("\nNumber of segs to fit an arc, 0 for smart determination", 0);
            if (double.IsNaN(value))
            {
                return;
            }
            int n = (int)value;

            ObjectId[] ids = Interaction.GetSelection("\nSelect polyline", "LWPOLYLINE");
            var entsToAdd = new List<Polyline>();
            ids.QForEach<Polyline>(poly =>
            {
                var pts = poly.GetPolylineFitPoints(n);
                var poly1 = NoDraw.Pline(pts);
                poly1.Layer = poly.Layer;
                try
                {
                    poly1.ConstantWidth = poly.ConstantWidth;
                }
                catch
                {
                }
                poly1.XData = poly.XData;
                poly.Erase();
                entsToAdd.Add(poly1);
            });
            entsToAdd.ToArray().AddToCurrentSpace();
            Interaction.WriteLine("{0} handled.", entsToAdd.Count);
        }

        /// <summary>
        /// Regulate polyline direction
        /// </summary>
        [CommandMethod("PolyClean4", CommandFlags.UsePickSet)]
        public static void PolyClean4()
        {
            double value = Interaction.GetValue("\nDirection：1-R to L；2-B to T；3-L to R；4-T to B");
            if (double.IsNaN(value))
            {
                return;
            }
            int n = (int)value;
            if (!new int[] { 1, 2, 3, 4 }.Contains(n))
            {
                return;
            }
            Algorithms.Direction dir = (Algorithms.Direction)n;

            ObjectId[] ids = Interaction.GetSelection("\nSelect polyline", "LWPOLYLINE");
            int m = 0;
            ids.QForEach<Polyline>(poly =>
            {
                m += Algorithms.PolyClean_SetTopoDirection(poly, dir);
            });
            Interaction.WriteLine("{0} handled.", m);
        }

        /// <summary>
        /// Remove unnecessary colinear vertices on polyline
        /// </summary>
        [CommandMethod("PolyClean5", CommandFlags.UsePickSet)]
        public static void PolyClean5()
        {
            Interaction.WriteLine("Not implemented yet");
            ObjectId[] ids = Interaction.GetSelection("\nSelect polyline", "LWPOLYLINE");
            ids.QForEach<Polyline>(poly =>
            {
                Algorithms.PolyClean_RemoveColinearPoints(poly);
            });
        }


        private static double _polyTrimExtendEpsilon = 20;



        /// <summary>
        /// Save selection for later load.
        /// </summary>
        [CommandMethod("SaveSelection", CommandFlags.UsePickSet)]
        public static void SaveSelection()
        {
            var ids = Interaction.GetPickSet();
            if (ids.Length == 0)
            {
                Interaction.WriteLine("No entity selected.");
                return;
            }
            string name = Interaction.GetString("\nSelection name");
            if (name == null)
            {
                return;
            }
            if (CustomDictionary.GetValue("Selections", name) != string.Empty)
            {
                Interaction.WriteLine("Selection with the same name already exists.");
                return;
            }
            var handles = ids.QSelect(x => x.Handle.Value.ToString()).ToArray();
            string dictValue = string.Join("|", handles);
            CustomDictionary.SetValue("Selections", name, dictValue);
        }



        /// <summary>
        /// Convert Text to MText
        /// </summary>
        [CommandMethod("DT2MT", CommandFlags.UsePickSet)]
        public static void DT2MT() // newly 20130815
        {
            var ids = Interaction.GetSelection("\nSelect Text", "TEXT");
            var dts = ids.QOpenForRead<DBText>().Select(dt =>
            {
                var mt = NoDraw.MText(dt.TextString, dt.Height, dt.Position, dt.Rotation, false);
                mt.Layer = dt.Layer;
                return mt;
            }).ToArray();
            ids.QForEach(x => x.Erase());
            dts.AddToCurrentSpace();
        }

        /// <summary>
        /// Show a rectangle indicating the extents of selected entities.
        /// </summary>
        [CommandMethod("ShowExtents", CommandFlags.UsePickSet)]
        public static void ShowExtents() // newly 20130815
        {
            var ids = Interaction.GetSelection("\nSelect entity");
            var extents = ids.GetExtents();
            var rectId = Draw.Rectang(extents.MinPoint, extents.MaxPoint);
            Interaction.GetString("\nPress ENTER to exit");
            rectId.QOpenForWrite(x => x.Erase());
        }

        /// <summary>
        /// Find entity by handle value
        /// </summary>
        [CommandMethod("ShowObject")]
        public static void ShowObject()
        {
            ObjectId[] ids = QuickSelection.SelectAll().ToArray();
            double handle1 = Interaction.GetValue("Handle of entity");
            if (double.IsNaN(handle1))
            {
                return;
            }
            long handle2 = Convert.ToInt64(handle1);
            var id = HostApplicationServices.WorkingDatabase.GetObjectId(false, new Handle(handle2), 0);
            var col = new ObjectId[] { id };
            Interaction.HighlightObjects(col);
            Interaction.ZoomObjects(col);
        }

        /// <summary>
        /// Show the shortest line to link given point to existing lines, polylines, or arcs.
        /// </summary>
        [CommandMethod("PolyLanding")]
        public static void PolyLanding()
        {
            ObjectId[] ids = QuickSelection.SelectAll("*LINE,ARC").ToArray();
            List<ObjectId> landingLineIds = new List<ObjectId>();
            while (true)
            {
                Point3d p = Interaction.GetPoint("\nSpecify a point");
                if (p.IsNull())
                {
                    break;
                }
                Point3d[] landings = ids.QSelect(x => (x as Curve).GetClosestPointTo(p, false)).ToArray();
                double minDist = landings.Min(x => x.DistanceTo(p));
                Point3d landing = landings.First(x => x.DistanceTo(p) == minDist);
                Interaction.WriteLine("Shortest landing distance of point ({0:0.00},{1:0.00}) is {2:0.00}。", p.X, p.Y, minDist);
                ObjectId landingLineId = Draw.Line(p, landing);
                landingLineIds.Add(landingLineId);
            }
            landingLineIds.QForEach(x => x.Erase());
        }

        /// <summary>
        /// Show vertics info of polyline.
        /// </summary>
        [CommandMethod("PolylineInfo")]
        public static void PolylineInfo() // mod by WY 20130202
        {
            ObjectId id = Interaction.GetEntity("\nSpecify a polyline", typeof(Polyline));
            if (id == ObjectId.Null)
            {
                return;
            }
            Polyline poly = id.QOpenForRead<Polyline>();
            for (int i = 0; i <= poly.EndParam; i++)
            {
                Interaction.WriteLine("[Point {0}] coord: {1}; bulge: {2}", i, poly.GetPointAtParameter(i), poly.GetBulgeAt(i));
            }
            List<ObjectId> txtIds = new List<ObjectId>();
            double height = poly.GeomExtents.MaxPoint.DistanceTo(poly.GeomExtents.MinPoint) / 50.0;
            for (int i = 0; i < poly.NumberOfVertices; i++)
            {
                txtIds.Add(Draw.MText(i.ToString(), height, poly.GetPointAtParameter(i), 0, true));
            }
            Interaction.GetString("\nPress ENTER to exit");
            txtIds.QForEach(x => x.Erase());
        }




        #endregion

        #region Commands purely for showing API usage

        [CommandMethod("TestBasicDrawing")]
        public void TestBasicDrawing()
        {
            
        }

        [CommandMethod("TestTransform")]
        public void TestTransform()
        {

        }

        [CommandMethod("TestBlock")]
        public void TestBlock()
        {
            var bId = Draw.Block(QuickSelection.SelectAll(), "test");
        }

        [CommandMethod("TestCustomDictionary")]
        public void TestCustomDictionary()
        {
            CustomDictionary.SetValue("dict1", "A", "apple");
            CustomDictionary.SetValue("dict1", "B", "orange");
            CustomDictionary.SetValue("dict1", "A", "banana");
            CustomDictionary.SetValue("dict2", "A", "peach");
            foreach (var dict in CustomDictionary.GetDictionaryNames())
            {
                Interaction.WriteLine(dict);
            }
            Interaction.WriteLine(CustomDictionary.GetValue("dict1", "A"));
        }

        [CommandMethod("TestDimension")]
        public void TestDimension()
        {
            Point3d a = Interaction.GetPoint("\nPoint 1");
            Point3d b = Interaction.GetPoint("\nPoint 2");
            Point3d c = Interaction.GetPoint("\nPoint of label");
            Draw.Dimlin(a, b, c);
        }

        public void TestZoom()
        {
            Interaction.ZoomExtents();
        }

        [CommandMethod("TestWipe")]
        public void TestWipe()
        {
            ObjectId id = Interaction.GetEntity("\nEntity");
            Draw.Wipeout(id);
        }

        [CommandMethod("TestRegion")]
        public void TestRegion()
        {
            ObjectId id = Interaction.GetEntity("\nEntity");
            Draw.Region(id);
            Point3d point = Interaction.GetPoint("\nPick one point");
            Draw.Boundary(point, BoundaryType.Region);
        }

        [CommandMethod("TestOffset")]
        public void TestOffset()
        {
            ObjectId id = Interaction.GetEntity("\nPolyline");
            Polyline poly = id.QOpenForRead<Polyline>();
            double value = Interaction.GetValue("\nOffset");
            poly.OffsetPoly(Enumerable.Range(0, poly.NumberOfVertices).Select(x => value).ToArray()).AddToModelSpace();
        }

        [CommandMethod("TestSelection")]
        public void TestSelection()
        {
            Point3d point = Interaction.GetPoint("\nPoint");
            double value = Interaction.GetDistance("\nSize");
            Vector3d size = new Vector3d(value, value, 0);
            ObjectId[] ids = Interaction.GetWindowSelection(point - size, point + size);
            Interaction.WriteLine("{0} entities selected.", ids.Count());
        }




        [CommandMethod("TestQOpen")]
        public void TestQOpen()
        {
            ObjectId[] ids = QuickSelection.SelectAll("LWPOLYLINE").QWhere(x => x.GetCode() == "parcel").ToArray();
            ids.QForEach<Polyline>(x =>
            {
                x.ConstantWidth = 2;
                x.ColorIndex = 0;
            });
        }

        [CommandMethod("TestSetLayer")]
        public void TestSetLayer()
        {
            ObjectId lineId = Draw.Line(Point3d.Origin, Point3d.Origin + Vector3d.XAxis);
            lineId.SetLayer("aaa");
        }

        [CommandMethod("TestGroup")]
        public void TestGroup()
        {
            ObjectId[] ids = Interaction.GetSelection("\nSelect entities");
            ids.Group();
            DBDictionary groupDict = HostApplicationServices.WorkingDatabase.GroupDictionaryId.QOpenForRead<DBDictionary>();
            Interaction.WriteLine("{0} groups", groupDict.Count);
        }



        [CommandMethod("TestHatch")]
        public void TestHatch()
        {
            Draw.Hatch(new Point3d[] { new Point3d(0, 0, 0), new Point3d(100, 0, 0), new Point3d(0, 100, 0) });
        }

        [CommandMethod("TestHatch2")]
        public void TestHatch2()
        {
            ObjectId[] ids = Interaction.GetSelection("\nSelect entities");
            Draw.Hatch(ids);
        }

        [CommandMethod("TestArc")]
        public void TestArc()
        {
            Point3d point1 = Interaction.GetPoint("\nStart");
            Draw.Circle(point1, 5);
            Point3d point2 = Interaction.GetPoint("\nMid");
            Draw.Circle(point2, 5);
            Point3d point3 = Interaction.GetPoint("\nEnd");
            Draw.Circle(point3, 5);
            Draw.Arc3P(point1, point2, point3);
        }

        [CommandMethod("TestArc2")]
        public void TestArc2()
        {
            Point3d start = Interaction.GetPoint("\nStart");
            Draw.Circle(start, 5);
            Point3d center = Interaction.GetPoint("\nCenter");
            Draw.Circle(center, 5);
            double angle = Interaction.GetValue("\nAngle");
            Draw.ArcSCA(start, center, angle);
        }

        [CommandMethod("TestEllipse")]
        public void TestEllipse()
        {
            Point3d center = Interaction.GetPoint("\nCenter");
            Draw.Circle(center, 5);
            Point3d endX = Interaction.GetPoint("\nEnd of one axis");
            Draw.Circle(endX, 5);
            double radiusY = Interaction.GetValue("\nRadius of another axis");
            Draw.Ellipse(center, endX, radiusY);
        }

        [CommandMethod("TestSpline")]
        public void TestSpline()
        {
            List<Point3d> points = new List<Point3d>();
            while (true)
            {
                Point3d point = Interaction.GetPoint("\nSpecify a point");
                if (point.IsNull())
                {
                    break;
                }
                points.Add(point);
                Draw.Circle(point, 5);
            }
            Draw.SplineCV(points.ToArray(), true);
        }

        [CommandMethod("TestPolygon")]
        public void TestPolygon()
        {
            int n;
            while (true)
            {
                double d = Interaction.GetValue("\nNumber of edges");
                if (double.IsNaN(d))
                {
                    return;
                }
                n = (int)d;
                if (n > 2)
                {
                    break;
                }
            }
            Point3d center = Interaction.GetPoint("\nCenter");
            Draw.Circle(center, 5);
            Point3d end = Interaction.GetPoint("\nOne vertex");
            Draw.Circle(end, 5);
            Draw.Polygon(n, center, end);
        }

        [CommandMethod("ViewSpline")]
        public void ViewSpline()
        {
            var id = Interaction.GetEntity("\nSelect a spline", typeof(Spline));
            var spline = id.QOpenForRead<Spline>();
            var knots = spline.NurbsData.GetKnots();
            var knotPoints = knots.Cast<double>().Select(k => spline.GetPointAtParam(k)).ToList();
            knotPoints.ForEach(p => Draw.Circle(p, 5));
        }

        [CommandMethod("TestText")]
        public void TestText()
        {
            Modify.TextStyle("Tahoma", 100, 5 * Math.PI / 180, 0.8);
            Draw.Text("FontAbc", 100, Point3d.Origin, 0, true);
        }


        //[CommandMethod("PythonConsole")]
        //public void PythonConsole()
        //{
        //    PyConsole pcw = new PyConsole();
        //    pcw.Show();
        //}

        [CommandMethod("TestLayout")]
        public void TestLayout()
        {
            var layout = Layouts.Create("TestLayout").QOpenForRead<Layout>();
            LayoutManager.Current.CurrentLayout = "TestLayout";
            var vps = layout.GetViewports();
            if (vps.Count > 1)
            {
                var vpId = vps[1];
                Layouts.SetViewport(vpId, 100, 100, new Point3d(80, 80, 0), Point3d.Origin, 1000);
            }
        }

        [CommandMethod("TestMeasure")]
        public void TestMeasure()
        {
            var id = Interaction.GetEntity("\nSelect curve");
            var cv = id.QOpenForRead<Curve>();
            double length = Interaction.GetValue("\nInterval");
            Draw.Measure(cv, length, new DBPoint());
        }

        [CommandMethod("TestDivide")]
        public void TestDivide()
        {
            var id = Interaction.GetEntity("\nSelect curve");
            var cv = id.QOpenForRead<Curve>();
            int num = (int)Interaction.GetValue("\nNumbers");
            Draw.Divide(cv, num, new DBPoint());
        }

        [CommandMethod("TestBoundary")]
        public void TestBoundary()
        {
            Point3d point = Interaction.GetPoint("\nPick one point");
            Draw.Boundary(point, BoundaryType.Polyline);
        }

        [CommandMethod("TestHatch3")]
        public void TestHatch3()
        {
            Point3d seed = Interaction.GetPoint("\nPick one point");
            Draw.Hatch("SOLID", seed);
        }

        [CommandMethod("TestHatch4")]
        public void TestHatch4()
        {
            ObjectId[] ids = Interaction.GetSelection("\nSelect entities");
            var ents = ids.QSelect(x => x).ToArray();
            Draw.Hatch("SOLID", ents);
        }

        [CommandMethod("TestPolygonMesh")]
        public void TestPolygonMesh()
        {
            int m = 100;
            int n = 100;
            Func<double, double, double> f = (x, y) => 10 * Math.Cos((x * x + y * y) / 1000);

            List<Point3d> points = new List<Point3d>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double x = 10 * i + 10;
                    double y = 10 * j + 10;
                    double z = f(x, y);
                    points.Add(new Point3d(x, y, z));
                }
            }

            Draw.PolygonMesh(points, m, n);
        }

        [CommandMethod("TestAddAttribute")]
        public void TestAddAttribute()
        {
            var iId = Draw.Insert("test", Point3d.Origin);
            iId.QOpenForWrite<BlockReference>(br =>
            {
                br.SetBlockAttribute("Test", "0", Point3d.Origin);
            });
        }

        [CommandMethod("TestKeywords")]
        public void TestKeywords()
        {
            string[] keys = { "A", "B", "C", "D" };
            var key = Interaction.GetKewords("\nChoose an option", keys, 3);
            Interaction.WriteLine("You chose {0}.", key);
        }

        #endregion
    }
}
