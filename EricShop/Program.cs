using System;
using System.Drawing;

namespace EricShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new ShopImage(args[0]);
            var search = new Searcher(test);
            search.FirstBorderSearch();
            var ret = search.GetDiffedPicture();
            ret.Save(args[0]+ "diffed.png");

        }
    }
}
