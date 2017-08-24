using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOffice.Classes
{
    public class FilterMethod<T>
    {
        public FilterMethod(string name, Func<T, T, bool> filter)
        {
            Name = name;
            Filter = filter;
        }
        public string Name { get; }
        public Func<T, T, bool> Filter { get; }
        public override string ToString()
        {
            return Name;
        }
    }
}
