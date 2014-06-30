using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EricShop
{
    class Searcher
    {
        private ShopImage image;
        public Queue<Point> DiffedPixels;
        private bool searchRan;

        public Searcher(ShopImage input)
        {
            image = input;
            DiffedPixels = new Queue<Point>();
            searchRan = false;
        }


        public void BasicSearch()
        {
            if(searchRan)
                return;
            for (int i = 0; i < image.Bitmap.Width - 1; i++)
            {
                for (int j = 0; j < image.Bitmap.Height - 1; j++)
                {
                    if ((image.GetPixel(i, j) - image.GetPixel(i + 1, j + 1)).Norm() > 10)
                        DiffedPixels.Enqueue(new Point(i, j));
                }
            }
            searchRan = true;
        }

        public void FirstBorderSearch()
        {
            int j = image.Bitmap.Height / 2;
            KeyValuePair<Direction, double> running;
            for (int i = 0; i < image.Bitmap.Width - 1; i++)
            {
                if ((running = image.MaxChangeDirection(i, j)).Value > 90)
                {
                    switch (running.Key)
                    {
                        case Direction.Left:
                            RecursiveBorderSearch(i - 1, j);
                            break;
                        case Direction.LeftAbove:
                            RecursiveBorderSearch(i - 1, j - 1);
                            break;
                        case Direction.Above:
                            RecursiveBorderSearch(i, j - 1);
                            break;
                        case Direction.RightAbove:
                            RecursiveBorderSearch(i + 1, j - 1);
                            break;
                        case Direction.Right:
                            RecursiveBorderSearch(i + 1, j);
                            break;
                        case Direction.RightBelow:
                            RecursiveBorderSearch(i + 1, j + 1);
                            break;
                        case Direction.Below:
                            RecursiveBorderSearch(i, j + 1);
                            break;
                        case Direction.LeftBelow:
                            RecursiveBorderSearch(i - 1, j + 1);
                            break;
                    }
                    return;
                }
            }
        }

        private void RecursiveBorderSearch(int i, int j)
        {
            KeyValuePair<Direction, double> next = image.MinChangeDirection(i, j);
            if (DiffedPixels.Count < 100)
            {
                DiffedPixels.Enqueue(new Point(i, j));
                switch (next.Key)
                {
                        case Direction.Left:
                            RecursiveBorderSearch(i - 1, j);
                            break;
                        case Direction.LeftAbove:
                            RecursiveBorderSearch(i - 1, j - 1);
                            break;
                        case Direction.Above:
                            RecursiveBorderSearch(i, j - 1);
                            break;
                        case Direction.RightAbove:
                            RecursiveBorderSearch(i + 1, j - 1);
                            break;
                        case Direction.Right:
                            RecursiveBorderSearch(i + 1, j);
                            break;
                        case Direction.RightBelow:
                            RecursiveBorderSearch(i + 1, j + 1);
                            break;
                        case Direction.Below:
                            RecursiveBorderSearch(i, j + 1);
                            break;
                        case Direction.LeftBelow:
                            RecursiveBorderSearch(i - 1, j + 1);
                        break;
                }
            }
            searchRan = true;
        }

        public Bitmap GetDiffedPicture()
        {
            if (!searchRan)
                return null;
            for (int i = 0; i < image.Bitmap.Width - 1; i++)
            {
                for (int j = 0; j < image.Bitmap.Height - 1; j++)
                {
                    image.Bitmap.SetPixel(i, j, Color.White);
                }
            }
            foreach (var diffedPixel in DiffedPixels)
            {
                image.Bitmap.SetPixel(diffedPixel.X, diffedPixel.Y, Color.Black);
            }
            return image.Bitmap;
        }
    }

}
