using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyOffice.Annotations;

namespace MyOffice.MVVM
{
    public class ItemBinding
    {
        private readonly object _item;

        private ItemBinding(Object item)
        {
            _item = item;
        }

        public object this[string index]
        {
            get => GetPropValue(index);
            set
            {
                
            }
        }
        private PropertyInfo FindProperty([NotNull]string name)
        {
            return _item.GetType().GetProperties().FirstOrDefault(p => p.Name == name);
        }

        private object GetPropValue(string propName)
        {
            return FindProperty(propName).GetValue(_item);
        }

    }
}
