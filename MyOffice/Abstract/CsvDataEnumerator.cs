using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MyOffice.Classes;
using MyOffice.Exceptions;
using MyOffice.Interfaces;

namespace MyOffice.Abstract
{
    public class CsvDataEnumerator<TPathFinder> : IDataEnumerator where TPathFinder : IPathFinder, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object[]> EnumerateData()
        {
            var path = new TPathFinder().GetPath();
            if (path == null)
            {
                throw new UserCanceledTaskException("Файл не был выбран");
            }

            var strs = File.ReadLines(path, Encoding.Default);
            return strs.Select(str => str.Split(';'));
        }
    }
}
