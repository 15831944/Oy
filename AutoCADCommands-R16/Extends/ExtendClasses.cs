using System;
using Autodesk.AutoCAD.Geometry;
using System.ComponentModel;
using Autodesk.AutoCAD.Runtime;

//TODO:有待完成内容,Commands.cs中有调用
namespace Autodesk.AutoCAD.DatabaseServices
{
    [TypeDescriptionProvider("Autodesk.AutoCAD.ComponentModel.TypeDescriptionProvider`1[[Autodesk.AutoCAD.DatabaseServices.Wipeout, acdbmgd]], acdbmgd")]
    [Wrapper("AcDbWipeout")]
    public class Wipeout : RasterImage
    {
        public Wipeout()
        {

        }
        //
        protected internal Wipeout(IntPtr unmanagedObjPtr, bool autoDelete)
        {

        }

        public bool HasFrame { get; set; }

        public void SetFrom(Point2dCollection points, Vector3d normal)
        {

        }
    }
}