using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericModel
{
    public class CsvDataProvider
    {
        public CsvDataProvider(Func<string> getSource, Func<IEnumerable<string>> enumLines)
        {
            var path = getSource();
            Source = path ?? throw new Exception("Источник не был выбран");
            var strs = enumLines();
            Data = strs.Select(str => str.Split(';'));
        }

        public IEnumerable<object[]> Data { get; }
        protected string Source;
    }
}
