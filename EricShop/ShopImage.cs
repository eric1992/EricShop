using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EricShop
{
    internal class ShopImage : IColorVectorMatrix
    {
        private readonly Bitmap _bitmap;

        public Bitmap Bitmap
        {
            get { return _bitmap; }
        }

        public ShopImage(String file)
        {
            try
            {
                _bitmap = new Bitmap(file);
            }
            catch (Exception)
            {
                Console.WriteLine("Image Not Found\n");
                _bitmap = new Bitmap(30, 30);
            }
        }

        public ShopImage(Bitmap input)
        {
            _bitmap = (Bitmap)input.Clone();
        }

        public ShopImage(IColorVectorMatrix inputMatrix)
        {
            _bitmap = new Bitmap(inputMatrix.Width(), inputMatrix.Height());
            for (var i = 0; i < inputMatrix.Width(); i++)
                for (var j = 0; j < inputMatrix.Height(); j++)
                    SetPixel(i, j, inputMatrix.GetPixel(i, j));
        }
        
        public int Width()
        {
            return _bitmap.Width;
        }

        public int Height()
        {
            return _bitmap.Height;
        }

        public ARGBColorVector GetPixel(int x, int y)
        {
            return (x >= 0 && x < Width() && y >= 0 && y < Height()) ? new ARGBColorVector(_bitmap.GetPixel(x, y)) : new ARGBColorVector(Color.FromArgb(0,0,0,0));
        }

        public ARGBColorVector GetPixel(Point point)
        {
            return new ARGBColorVector(_bitmap.GetPixel(point.X, point.Y));
        }

        public void SetPixel(int x, int y, ARGBColorVector argbColor)
        {
            _bitmap.SetPixel(x, y, argbColor.Color);
        }

        public void SetPixel(Point pixel, ARGBColorVector argbColor)
        {
            _bitmap.SetPixel(pixel.X, pixel.Y, argbColor.Color);
        }

        public List<ARGBColorVector> GetSubSet(List<Point> pixels)
        {
            var pixelList = new List<ARGBColorVector>(pixels.Capacity);
            pixelList.AddRange(pixels.Select(pixel => new ARGBColorVector(GetPixel(pixel.X, pixel.Y).Color)));
            return pixelList;
        }

        public void SetSubSet(Dictionary<Point, ARGBColorVector> pairs)
        {
            foreach (var pair in pairs)
            {
                SetPixel(pair.Key, pair.Value);
            }
        }

        public IColorVectorMatrix Clone()
        {
            return new ShopImage(_bitmap);
        }

        public IColorVectorMatrix CloneEmpty()
        {
            var emptyImage = new ShopImage(new Bitmap(Width(), Height()));
            var x = 0;
            var y = 0;
            var input = new ARGBColorVector(Color.FromArgb(0, 0, 0, 0));
            foreach (var pointVector in emptyImage)
            {
                emptyImage.SetPixel(x, y, input);
            }
            return emptyImage;
        }

        public IEnumerator<KeyValuePair<Point, ARGBColorVector>> GetEnumerator()
        {
            for (var i = 0; i < Width(); i++)
            {
                for (var j = 0; j < Height(); j ++)
                {
                    yield return new KeyValuePair<Point, ARGBColorVector>(new Point(i, j), GetPixel(i, j));
                }
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
