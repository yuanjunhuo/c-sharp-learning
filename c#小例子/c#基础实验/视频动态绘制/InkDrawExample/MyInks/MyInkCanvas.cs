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
    class MyInkCanvas : InkCanvas
    {
        public string selectShape;
        public InkViedoDynamic ink = new InkViedoDynamic();
        public MyInkCanvas()
        {
            DrawingAttributes inkDa = new DrawingAttributes
            {
                Color = Colors.Red,
                Height = 10,
                Width = 10,
                StylusTip = StylusTip.Rectangle
            };
            this.DefaultDrawingAttributes = inkDa;
            this.EditingMode = InkCanvasEditingMode.Ink;
        }
        protected override void OnStrokeCollected(InkCanvasStrokeCollectedEventArgs e)
        {
            switch (selectShape)
            {
                case "球形":
                    this.Strokes.Remove(e.Stroke);
                    InkEllipseStroke stroke1 = new InkEllipseStroke(e.Stroke.StylusPoints);
                    this.Strokes.Add(stroke1);
                    break;
                case "矩形":
                    this.Strokes.Remove(e.Stroke);
                    InkRectangleStroke stroke2 = new InkRectangleStroke(e.Stroke.StylusPoints);
                    this.Strokes.Add(stroke2);
                    break;
                case "视频":
                    this.Strokes.Remove(e.Stroke);
                    ink.CreateNewStroke(e);
                    this.Strokes.Add(ink.InkStroke);
                    InkCanvasStrokeCollectedEventArgs args = new InkCanvasStrokeCollectedEventArgs(ink.InkStroke);
                    base.OnStrokeCollected(args);
                    break;
            }
        }
        public void setDyanmic(DynamicRenderer d1)
        {
            this.DynamicRenderer = d1;
        }
    }
}
