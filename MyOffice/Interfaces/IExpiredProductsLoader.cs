using System.Collections.Generic;
using MyOffice.Model;

namespace MyOffice.Interfaces
{
    public interface IExpiredProductsLoader
    {
        IEnumerable<ExpiredProduct> EnumerateProducts();
    }
}
