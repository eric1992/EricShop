using System;
using System.Drawing;

namespace EricShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var Image = new ShopImage(new Bitmap(args[0]));
            var Operator = new ScalarShift{Scale = 0};
            var Mapped = (ShopImage) (Operator.Operate(Image));
            Mapped.Bitmap.Save("Diffed.png");
        }
    }
}
