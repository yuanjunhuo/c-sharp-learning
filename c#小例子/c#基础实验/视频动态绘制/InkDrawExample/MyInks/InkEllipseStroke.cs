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
    class InkEllipseStroke:  Stroke
    {
        public InkEllipseStroke(StylusPointCollection stylusPoints)
            :base(stylusPoints)
        {            
        }
        protected override void DrawCore(DrawingContext drawingContext, DrawingAttributes drawingAttributes)
        {
            Brush mybrush = new SolidColorBrush(Colors.OrangeRed);
            Point firstPoint = (Point)this.StylusPoints.First();
            Point lastPoint = (Point)this.StylusPoints.Last();
            double radiusX = (lastPoint.X - firstPoint.X) / 2.0;
            double radiusY = (lastPoint.Y - firstPoint.Y) / 2.0;
            Point center = new Point((lastPoint.X + firstPoint.X) / 2.0, (lastPoint.Y + firstPoint.Y) / 2.0);
            drawingContext.DrawEllipse(mybrush, null, center, radiusX, radiusY);            
        }

    }
}
