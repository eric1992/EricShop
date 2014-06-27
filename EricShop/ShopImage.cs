using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
