using System;
using System.Drawing;

namespace EricShop
{
    public class ARGBColorVector
    {
        private Color _color;

        public ARGBColorVector()
        {
            _color = new Color();
        }

        public ARGBColorVector(Color input)
        {
            _color = input;
        }

        public Color Color
        {
            get { return _color; }
            private set { _color = value; }
        }

        public double Alpha
        {
            get { return ((double)_color.A) / 255; }
            set { _color = Color.FromArgb((int)(value * 255), _color.R, _color.G, _color.B); }
        }

        public int Red
        {
            get { return _color.R; }
            set { _color = Color.FromArgb(_color.A, value, _color.G, _color.B); }
        }

        public int Green
        {
            get { return _color.G; }
            set { _color = Color.FromArgb(_color.A, _color.R, value, _color.B); }
        }

        public int Blue
        {
            get { return _color.B; }
            set { _color = Color.FromArgb(_color.A, _color.R, _color.G, value); }
        }

        /// <summary>
        /// See wikipedia for formula used. http://en.wikipedia.org/wiki/Alpha_compositing, subsection alpha blending
        /// </summary>
        /// <param name="x">Base color</param>
        /// <param name="y">Overlay color</param>
        /// <returns></returns>
        public static ARGBColorVector operator +(ARGBColorVector x, ARGBColorVector y)
        {
            var outA = y.Alpha + x.Alpha*(1 - y.Alpha);
            var outR = 0;
            var outG = 0;
            var outB = 0;
            if (Math.Abs(outA) < .00001)
            {
                return new ARGBColorVector(Color.FromArgb((int) (outA * 255), outR, outG, outB));
            }
            outR = (int) ((y.Red*y.Alpha + x.Red*x.Alpha*(1 - y.Alpha))/outA);
            outG = (int) ((y.Green*y.Alpha + x.Green*x.Alpha*(1 - y.Alpha))/outA);
            outB = (int) ((y.Blue*y.Alpha + x.Blue*x.Alpha*(1 - y.Alpha))/outA);
            return new ARGBColorVector(Color.FromArgb((int) (outA * 255), outR, outG, outB));
        }

        public static ARGBColorVector operator -(ARGBColorVector x, ARGBColorVector y)
        {
            double difAlpha = Math.Abs(x.Alpha - y.Alpha);
            int difRed = Math.Abs(x.Red - y.Red);
            int difGreen = Math.Abs(x.Green - y.Green);
            int difBlue = Math.Abs(x.Blue - y.Blue);
            return new ARGBColorVector(Color.FromArgb((int) (difAlpha * 255), difRed, difGreen, difBlue));
        }

        public static ARGBColorVector operator *(double c, ARGBColorVector x)
        {
            var scaledAlpha = c * x.Alpha;
            var scaledRed = (int) Math.Round(c * (double)x.Red);
            var scaledGreen = (int) Math.Round(c * (double)x.Green);
            var scaledBlue = (int) Math.Round(c * (double)x.Blue);
            return new ARGBColorVector(Color.FromArgb((int) (scaledAlpha * 255), scaledRed, scaledGreen, scaledBlue));
        }

        public double Norm()
        {
            return Math.Sqrt(Math.Pow(_color.R, 2) + Math.Pow(_color.G, 2) + Math.Pow(_color.B, 2));
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof (ARGBColorVector))
                return false;
            var cast = (ARGBColorVector) obj;
            return cast._color.Equals(_color);
        }
    }
}
