using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;


namespace WindowsFormsApp.Presentation_Layer
{
    class GMapPoint : GMap.NET.WindowsForms.GMapMarker
    {
        private PointLatLng point_;
        private float size_;
        private float weight_;
        public PointLatLng Point
        {
            get
            {
                return point_;
            }
            set
            {
                point_ = value;
            }
        }
        public GMapPoint(PointLatLng p, int size, float weight)
            : base(p)
        {
            point_ = p;
            size_ = size;
            weight_ = weight;
        }

        public override void OnRender(Graphics g)
        {
            g.DrawEllipse(Pens.Black, LocalPosition.X, LocalPosition.Y, size_, size_);
            g.FillEllipse(new SolidBrush(Coloring.SetColors(weight_)), LocalPosition.X, LocalPosition.Y, size_, size_);
        }
    }
}
