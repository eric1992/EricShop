using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EricShop
{
    class ColorVector
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

        public static ColorVector operator -(ColorVector x, ColorVector y)
        {
            int difAlpha = Math.Abs(x._color.A - y._color.A);
            int difRed = Math.Abs(x._color.R - y._color.R);
            int difGreen = Math.Abs(x._color.G - y._color.G);
            int difBlue = Math.Abs(x._color.B - y._color.B);
            return new ColorVector(Color.FromArgb(difAlpha, difRed, difGreen, difBlue));
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
