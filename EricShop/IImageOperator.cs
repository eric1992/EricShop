namespace EricShop
{
    public interface IImageOperator
    {
        IColorVectorMatrix Operate(IColorVectorMatrix input);
    }
}
