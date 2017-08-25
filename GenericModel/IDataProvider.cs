using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericModel
{
    public interface IDataProvider
    {
        IEnumerable<object[]> Data { get; }
    }
}
