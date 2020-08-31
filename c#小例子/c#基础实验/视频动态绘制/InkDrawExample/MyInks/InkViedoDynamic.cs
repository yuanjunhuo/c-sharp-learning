using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;
using System.Windows.Media;


namespace InkDrawExample.MyInks
{
    class InkViedoDynamic : DynamicRenderer
    {
        public string inktext = @"images\Video1.wmv";
        
        public InkViedoStroke InkStroke { private set; get; }
        private Point prevoiusPoint;
        private MediaPlayer p1;
        public void CreateNewStroke(InkCanvasStrokeCollectedEventArgs e)
        {
            InkStroke = new InkViedoStroke(this, e.Stroke.StylusPoints);
        }
        public static MediaPlayer CreatVideoPlayer(String uristring)
        {
            MediaPlayer p = new MediaPlayer();
            p.Open(new Uri(uristring, UriKind.Relative));
            p.IsMuted = true;
            p.MediaEnded += (s, e) => { p.Position = TimeSpan.Zero; };
            p.Play();
            return p;
        }
        public void Draw(Point first,MediaPlayer player,DrawingContext dc,StylusPointCollection points)
        {
            Point pt = (Point)points.Last();
            Vector v = Point.Subtract(pt, first);
            if (double.IsNegativeInfinity(first.X)) return;
            if(v.Length>6)
            {
                Rect rect = new Rect(first, v);
                dc.DrawVideo(player, rect);
            }
        }
        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            base.OnStylusDown(rawStylusInput);
            prevoiusPoint = (Point)rawStylusInput.GetStylusPoints().First();           
            p1 = CreatVideoPlayer(inktext);
        }
        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            p1.Stop();
            p1.Close();
            base.OnStylusUp(rawStylusInput);
        }
        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            StylusPointCollection styluspoint = rawStylusInput.GetStylusPoints();
            this.Reset(Stylus.CurrentStylusDevice, styluspoint);
            base.OnStylusMove(rawStylusInput);
        }
        protected override void OnDraw(DrawingContext drawingContext, StylusPointCollection stylusPoints, Geometry geometry, Brush fillBrush)
        {
            this.Draw(prevoiusPoint, p1, drawingContext,stylusPoints);
        }
    }
}
