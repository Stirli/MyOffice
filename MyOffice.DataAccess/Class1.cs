using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericModel;
using MyOffice.Model;

namespace MyOffice.DataAccess
{
    public class MyOfficeDataProvider:IMyOfficeDataProdvider
    {
        public MyOfficeDataProvider()
        {
            new CsvDataProvider(GetSource, )
        }

        private string GetSource()
        {
            return 
        }

        public IEnumerable<Product> Products { get; }
    }
}
