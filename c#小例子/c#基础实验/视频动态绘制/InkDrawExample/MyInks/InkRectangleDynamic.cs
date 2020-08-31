using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;
using System.Windows.Media;
namespace InkDrawExample.MyInks
{
    class InkRectangleDynamic : DynamicRenderer
    {
        public Point firstPoint;
        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            base.OnStylusDown(rawStylusInput);
            firstPoint = (Point)rawStylusInput.GetStylusPoints().First();
        }
        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            base.OnStylusMove(rawStylusInput);
            StylusPointCollection stylusPoints = rawStylusInput.GetStylusPoints();
            this.Reset(Stylus.CurrentStylusDevice, stylusPoints);
        }
        protected override void OnDraw(DrawingContext drawingContext, StylusPointCollection stylusPoints, Geometry geometry, Brush fillBrush)
        {
            Brush mybrush = new SolidColorBrush(Colors.Pink);
            Point lastPoint = (Point)stylusPoints.Last();
            Vector v = Point.Subtract(lastPoint, firstPoint);
            Rect rect = new Rect(firstPoint, v);
            drawingContext.DrawRectangle(mybrush, null, rect);
        }
    }
}
