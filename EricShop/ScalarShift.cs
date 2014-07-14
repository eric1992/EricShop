using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EricShop
{
    public class ScalarShift : IImageOperator
    {
        private double _scale;
        public double Scale
        {
            get { return _scale; }
            set { _scale = value - Math.Floor(value); }
        }
        public IColorVectorMatrix Operate(IColorVectorMatrix input)
        {
            var returnMatrix = input.CloneEmpty();
            for(var i = 0; i < returnMatrix.Width(); i++)
                for (var j = 0; j < returnMatrix.Height(); j++)
                {
                    returnMatrix.SetPixel(i, j, _scale * input.GetPixel(i,j));
                }
            return returnMatrix;
        }
    }
}
