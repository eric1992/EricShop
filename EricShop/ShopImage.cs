using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public ColorVector GetPixel(int x, int y)
        {
            return (x >= 0 && x < Width() && y >= 0 && y < Height()) ? new ColorVector(_bitmap.GetPixel(x, y)) : new ColorVector(Color.Black);
        }

        public ColorVector GetPixel(Point point)
        {
            return new ColorVector(_bitmap.GetPixel(point.X, point.Y));
        }

        public void SetPixel(int x, int y, ColorVector color)
        {
            _bitmap.SetPixel(x, y, color.Color);
        }

        public void SetPixel(Point pixel, ColorVector color)
        {
            _bitmap.SetPixel(pixel.X, pixel.Y, color.Color);
        }

        public List<ColorVector> GetSubSet(List<Point> pixels)
        {
            var pixelList = new List<ColorVector>(pixels.Capacity);
            pixelList.AddRange(pixels.Select(pixel => new ColorVector(GetPixel(pixel.X, pixel.Y).Color)));
            return pixelList;
        }

        public void SetSubSet(Dictionary<Point, ColorVector> pairs)
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
            return new ShopImage(new Bitmap(Width(), Height()));
        }
    }
}
