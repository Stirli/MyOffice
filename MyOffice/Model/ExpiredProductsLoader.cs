using System;
using System.Collections.Generic;
using System.Linq;
using MyOffice.Classes;
using MyOffice.Interfaces;
using MyOffice.Model;

namespace MyOffice.Abstract
{
    public class ExpiredProductsLoader<TDataLoader> : IExpiredProductsLoader where TDataLoader : IDataEnumerator, new()
    {
        public IEnumerable<ExpiredProduct> EnumerateProducts()
        {
            var dl = new TDataLoader();

            IEnumerable<object[]> data;
                data = dl.EnumerateData();
            
            return data.Skip(1).Select(obj =>
            {
                DateTime dateTime; DateTime.TryParse(obj[2].ToString(), out dateTime);
                var tup = new ExpiredProduct(obj[0].ToString(), obj[1].ToString(), dateTime);
                return tup;
            });
        }
    }
}
