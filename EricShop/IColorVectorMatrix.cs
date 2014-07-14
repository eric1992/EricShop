using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EricShop
{
    public interface IColorVectorMatrix
    {
        int Width();
        int Height();
        ColorVector GetPixel(int x, int y);
        ColorVector GetPixel(Point point);
        void SetPixel(int x, int y, ColorVector color);
        void SetPixel(Point pixel, ColorVector color);
        List<ColorVector> GetSubSet(List<Point> pixels);
        void SetSubSet(Dictionary<Point, ColorVector> pairs);
        IColorVectorMatrix Clone();
        IColorVectorMatrix CloneEmpty();
    }
}
