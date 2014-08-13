using System.Collections.Generic;
using System.Drawing;

namespace EricShop
{
    public interface IColorVectorMatrix : IEnumerable<KeyValuePair<Point, ARGBColorVector>>
    {
        int Width();
        int Height();
        ARGBColorVector GetPixel(int x, int y);
        ARGBColorVector GetPixel(Point point);
        void SetPixel(int x, int y, ARGBColorVector argbColor);
        void SetPixel(Point pixel, ARGBColorVector argbColor);
        List<ARGBColorVector> GetSubSet(List<Point> pixels);
        void SetSubSet(Dictionary<Point, ARGBColorVector> pairs);
        IColorVectorMatrix Clone();
        IColorVectorMatrix CloneEmpty();
    }
}
