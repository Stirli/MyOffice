using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyOffice.Annotations;

namespace MyOffice.Model
{
    public class ExpiredProduct : INotifyPropertyChanged,IEquatable<ExpiredProduct>
    {
        private string _code="";
        private string _name="";
        private DateTime _expireDate;

        public ExpiredProduct()
        {
        }
        public ExpiredProduct(string code, string name, DateTime expireDate)
        {
            Code = code;
            Name = name;
            ExpireDate = expireDate;
        }
        public string Code
        {
            get { return _code; }
            set
            {
                if (value == _code) return;
                _code = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set
            {
                if (value.Equals(_expireDate)) return;
                _expireDate = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Equals(ExpiredProduct other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_code, other._code) && string.Equals(_name, other._name) && _expireDate.Equals(other._expireDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ExpiredProduct) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_code != null ? _code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _expireDate.GetHashCode();
                return hashCode;
            }
        }
    }
}
