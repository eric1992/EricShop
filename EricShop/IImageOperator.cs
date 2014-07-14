using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EricShop
{
    public interface IImageOperator
    {
        IColorVectorMatrix Operate(IColorVectorMatrix input);
    }
}
