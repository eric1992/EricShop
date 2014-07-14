using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EricShop
{
    class WeightedAverageMap : IImageOperator
    {
        private Dictionary<Point, double> _weightedValues;

        public WeightedAverageMap()
        {
            _weightedValues = new Dictionary<Point, double>();
        }
        
        public IColorVectorMatrix Operate(IColorVectorMatrix input)
        {
            var returnMatrix = input.CloneEmpty();
            for (var i = 0; i < input.Width(); i++)
            {
                for (var j = 0; j < input.Height(); j++)
                {
                    var weightedVector = new ColorVector();
                    weightedVector = _weightedValues.Aggregate(
                        weightedVector, (current, weightedValue) => current + (weightedValue.Value*input.GetPixel(i + weightedValue.Key.X, j + weightedValue.Key.Y)));
                    returnMatrix.SetPixel(i, j, weightedVector);
                }
            }
            return returnMatrix;
        }

        public void AddWeight(int x, int y, double weight)
        {
            var summed = 0.0;
            foreach (var current in _weightedValues.Values)
            {
                summed += current;

            }
        }
    }
}
