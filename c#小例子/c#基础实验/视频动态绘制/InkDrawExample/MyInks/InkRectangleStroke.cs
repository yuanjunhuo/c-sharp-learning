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
    class InkRectangleStroke:  Stroke
    {
        public InkRectangleStroke(StylusPointCollection stylusPoints)
            :base(stylusPoints)
        {            
        }
        protected override void DrawCore(DrawingContext drawingContext, DrawingAttributes drawingAttributes)
        {
            //Brush mybrush = new SolidColorBrush(Colors.Purple);
            //Point firstPoint = (Point)this.StylusPoints.First();
            //Point lastPoint = (Point)this.StylusPoints.Last();
            //Vector v = Point.Subtract(lastPoint, firstPoint);
            //Rect rect = new Rect(firstPoint, v);
            //drawingContext.DrawRectangle(mybrush, null, rect);
        }

    }
}
