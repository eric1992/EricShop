using System.Drawing;

namespace EricShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var Image = new ShopImage(new Bitmap(args[0]));
            var Operator = new WeightedAverageMap(){PointWeights = {{new Point(-2, 0), .1}, {new Point(-1, 0), .2}, {new Point(0, 0), .3}, {new Point(1,0), .2}, {new Point(2,0), .1} }};
            var Mapped = (ShopImage) (Operator.Operate(Image));
            Mapped.Bitmap.Save("Diffed.png");
        }
    }
}
