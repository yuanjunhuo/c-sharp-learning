using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace InkDrawExample.MyInks
{
    class InkViedoStroke : Stroke
    {
        private InkViedoDynamic ink;
        private string inktext;
        public InkViedoStroke(InkViedoDynamic ink,StylusPointCollection stylusPoints)
            : base(stylusPoints)
        {
            this.ink = ink;
            this.inktext = ink.inktext;
        }
        protected override void DrawCore(DrawingContext drawingContext, DrawingAttributes drawingAttributes)
        {
            MediaPlayer mp = InkViedoDynamic.CreatVideoPlayer(inktext);
            Point pt1 = (Point)StylusPoints.First();
            ink.Draw(pt1, mp, drawingContext, StylusPoints);
            
        }
    }
}
