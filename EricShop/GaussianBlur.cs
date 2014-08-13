using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EricShop
{
    class WeightedAverageMap : IImageOperator
    {
        public Dictionary<Point, double> PointWeights;

        public WeightedAverageMap()
        {
            PointWeights = new Dictionary<Point, double>();
        }
        
        public IColorVectorMatrix Operate(IColorVectorMatrix input)
        {
            if (!PointWeights.Any())
            {
                return null;
            }
            var returnMatrix = input.CloneEmpty();
            foreach (var pointVector in returnMatrix)
            {
                var pointToSet = pointVector.Key;
                var vectorToSet = pointVector.Value;
                foreach (var pointWeight in PointWeights)
                {
                    var currentDisplacement = pointWeight.Key;
                    var currentWeightedPoint = pointWeight.Value * input.GetPixel(pointToSet.X + currentDisplacement.X, pointToSet.Y + currentDisplacement.Y);
                    vectorToSet += currentWeightedPoint;
                }
                returnMatrix.SetPixel(pointToSet, vectorToSet);
            }
            return returnMatrix;
        }
    }
}
