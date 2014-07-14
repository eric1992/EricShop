using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EricShop
{
    public class ColorVector
    {
        private Color _color;

        public ColorVector()
        {
            _color = new Color();
        }

        public ColorVector(Color input)
        {
            _color = input;
        }

        public Color Color
        {
            get { return _color; }
            private set { _color = value; }
        }

        public static ColorVector operator +(ColorVector x, ColorVector y)
        {
            int summedA = x.Color.A + y.Color.A;
            int summedR = x.Color.R + y.Color.R;
            int summedG = x.Color.G + y.Color.G;
            int summedB = x.Color.B + y.Color.B;
            return new ColorVector(Color.FromArgb(summedA, summedR, summedG, summedB));
        }

        public static ColorVector operator -(ColorVector x, ColorVector y)
        {
            int difAlpha = Math.Abs(x._color.A - y._color.A);
            int difRed = Math.Abs(x._color.R - y._color.R);
            int difGreen = Math.Abs(x._color.G - y._color.G);
            int difBlue = Math.Abs(x._color.B - y._color.B);
            return new ColorVector(Color.FromArgb(difAlpha, difRed, difGreen, difBlue));
        }

        public static ColorVector operator *(double c, ColorVector x)
        {
            var scaledRed = (int) Math.Round(c * (double)x.Color.R);
            var scaledGreen = (int) Math.Round(c * (double)x.Color.G);
            var scaledBlue = (int) Math.Round(c * (double)x.Color.B);
            return new ColorVector(Color.FromArgb(x.Color.A, scaledRed, scaledGreen, scaledBlue));
        }

        public double Norm()
        {
            return Math.Sqrt(Math.Pow(_color.R, 2) + Math.Pow(_color.G, 2) + Math.Pow(_color.B, 2));
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (ColorVector))
                return false;
            var cast = (ColorVector) obj;
            return cast._color.Equals(_color);
        }
    }
}
