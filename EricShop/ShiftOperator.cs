namespace EricShop
{
    class ShiftOperator : IImageOperator
    {
        public int ShiftX;
        public int ShiftY;


        public IColorVectorMatrix Operate(IColorVectorMatrix input)
        {
            var returnMatrix = input.CloneEmpty();
            for(int i = 0, mappedToX = ShiftX % input.Width(); i < input.Width(); i++, mappedToX = (mappedToX + 1) % input.Width())
                for (int j = 0, mappedToY = ShiftY % input.Height(); j < input.Height(); j++, mappedToY = (mappedToY + 1) % (input.Height() - 1))
                {
                    returnMatrix.SetPixel(mappedToX, mappedToY, input.GetPixel(i, j)); 
                }
            return returnMatrix;
        }
    }
}
