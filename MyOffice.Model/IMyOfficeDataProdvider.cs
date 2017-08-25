using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOffice.Model
{
    public interface IMyOfficeDataProdvider
    {
        IEnumerable<Product> Products { get; }
    }
}
