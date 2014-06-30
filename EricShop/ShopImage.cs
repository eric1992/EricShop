using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EricShop
{
    class ShopImage
    {
        private Bitmap _bitmap;
        public Bitmap Bitmap { get { return _bitmap; }}

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

        public ColorVector GetPixel(int x, int y)
        {
            return new ColorVector(_bitmap.GetPixel(x, y));
        }

        public KeyValuePair<Direction, double> MaxChangeDirection(int x, int y)
        {
            double maxChange = double.MinValue;
            double runningChange;
            Direction runningDirection = Direction.Left;
            if (HasLeftAbove(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x - 1, y - 1)).Norm()) > maxChange)
            {
                maxChange = runningChange;
                runningDirection = Direction.LeftAbove;
            }
            if (HasAbove(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x, y - 1)).Norm()) > maxChange)
            {
                maxChange = runningChange;
                runningDirection = Direction.Above;
            }
            if (HasRightAbove(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x + 1, y - 1)).Norm()) > maxChange)
            {
                maxChange = runningChange;
                runningDirection = Direction.RightAbove;
            }
            if (HasRight(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x + 1, y)).Norm()) > maxChange)
            {
                maxChange = runningChange;
                runningDirection = Direction.Right;
            }
            if (HasRightBelow(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x + 1, y - 1)).Norm()) > maxChange)
            {
                maxChange = runningChange;
                runningDirection = Direction.RightBelow;
            }
            if (HasBelow(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x, y - 1)).Norm()) > maxChange)
            {
                maxChange = runningChange;
                runningDirection = Direction.Below;
            }
            if (HasLeftBelow(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x - 1, y - 1)).Norm()) > maxChange)
            {
                maxChange = runningChange;
                runningDirection = Direction.LeftBelow;
            }
            if (HasLeft(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x - 1, y)).Norm()) > maxChange)
            {
                maxChange = runningChange;
                runningDirection = Direction.LeftAbove;
            }
            return new KeyValuePair<Direction, double>(runningDirection, maxChange);
        }

        public KeyValuePair<Direction, double> MinChangeDirection(int x, int y)
        {
            double minChange = double.MaxValue;
            double runningChange;
            Direction runningDirection = Direction.Left;
            if (HasLeftAbove(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x - 1, y - 1)).Norm()) < minChange)
            {
                minChange = runningChange;
                runningDirection = Direction.LeftAbove;
            }
            if (HasAbove(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x, y - 1)).Norm()) < minChange)
            {
                minChange = runningChange;
                runningDirection = Direction.Above;
            }
            if (HasRightAbove(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x + 1, y - 1)).Norm()) < minChange)
            {
                minChange = runningChange;
                runningDirection = Direction.RightAbove;
            }
            if (HasRight(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x + 1, y)).Norm()) < minChange)
            {
                minChange = runningChange;
                runningDirection = Direction.Right;
            }
            if (HasRightBelow(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x + 1, y - 1)).Norm()) < minChange)
            {
                minChange = runningChange;
                runningDirection = Direction.RightBelow;
            }
            if (HasBelow(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x, y - 1)).Norm()) < minChange)
            {
                minChange = runningChange;
                runningDirection = Direction.Below;
            }
            if (HasLeftBelow(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x - 1, y - 1)).Norm()) < minChange)
            {
                minChange = runningChange;
                runningDirection = Direction.LeftBelow;
            }
            if (HasLeft(x, y) && (runningChange = (GetPixel(x, y) - GetPixel(x - 1, y)).Norm()) < minChange)
            {
                minChange = runningChange;
                runningDirection = Direction.LeftAbove;
            }
            return new KeyValuePair<Direction, double>(runningDirection, minChange);
        }
        


        public bool HasLeft(int x, int y)
        {
            return x > 0;
        }
        public bool HasRight(int x, int y)
        {
            return x < _bitmap.Width - 1;
        }
        public bool HasAbove(int x, int y)
        {
            return y > 0;
        }
        public bool HasBelow(int x, int y)
        {
            return y < _bitmap.Height - 1;
        }

        public bool HasLeftAbove(int x, int y)
        {
            return HasLeft(x, y) && HasAbove(x, y);
        }

        public bool HasRightAbove(int x, int y)
        {
            return HasRight(x, y) && HasAbove(x, y);
        }

        public bool HasLeftBelow(int x, int y)
        {
            return HasLeft(x, y) && HasBelow(x, y);
        }

        public bool HasRightBelow(int x, int y)
        {
            return HasRight(x, y) && HasBelow(x, y);
        }
    }
}
