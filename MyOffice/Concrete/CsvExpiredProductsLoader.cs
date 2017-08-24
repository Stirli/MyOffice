using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOffice.Abstract;

namespace MyOffice.Classes
{
    public class CsvExpiredProductsLoader : ExpiredProductsLoader<CsvDataEnumerator<CsvPathFinder>>
    {
    }
}
