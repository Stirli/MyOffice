using System.Collections.Generic;

namespace MyOffice.Interfaces
{
    public interface IDataEnumerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Rows with columns as object. First row is headers</returns>
        IEnumerable<object[]> EnumerateData();
    }
}
