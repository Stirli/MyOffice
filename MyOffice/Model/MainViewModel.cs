using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Threading;
using Apex.MVVM;
using MyOffice.Classes;
using MyOffice.Interfaces;
using static System.DateTime;
using static System.String;
using static System.Threading.Tasks.Task;

namespace MyOffice.Model
{
    class MainViewModel : ViewModel
    {
        private bool _updating;
        private FilterMethod<DateTime> _dateFilterMethod;

        public MainViewModel()
        {
            OpenCommand = new Command(Open);
            ProductFilter = new ExpiredProduct();
            Rows = new ObservableCollection<ExpiredProduct>();

            ProductFilter.PropertyChanged += (sender, args) =>
            {
                var mcv = (CollectionView)CollectionViewSource.GetDefaultView(Rows);
                mcv.Refresh();
            };
            DateFilterMethods = new List<FilterMethod<DateTime>>
            {
                new FilterMethod<DateTime>("Меньше", (t1, t2) => t1 < t2),
                new FilterMethod<DateTime>("Больше", (t1, t2) => t1 > t2),
                new FilterMethod<DateTime>("Равно", (t1, t2) => t1 == t2)
            };
        }

        public ExpiredProduct ProductFilter { get; set; }

        public FilterMethod<DateTime> DateFilterMethod
        {
            get { return _dateFilterMethod; }
            set
            {
                if (Equals(value, _dateFilterMethod)) return;
                _dateFilterMethod = value;
                NotifyPropertyChanged(nameof(DateFilterMethod));
                var mcv = (CollectionView)CollectionViewSource.GetDefaultView(Rows);
                mcv.Refresh();
            }
        }

        public List<FilterMethod<DateTime>> DateFilterMethods { get; }
        private async void Open(object o)
        {
            Rows.Clear();
            Stopwatch w = new Stopwatch();
            var dl = o as IExpiredProductsLoader;
            if (dl == null) return;
            IEnumerable<ExpiredProduct> data;
            try
            {
                data = dl.EnumerateProducts();
            }
            catch (Exception e)
            {
                MessageBox.Show(App.Current.MainWindow, e.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var mcv = (CollectionView)CollectionViewSource.GetDefaultView(Rows);
            var enumTask = Run(() =>
            {
                int count = 0;
                w.Start();
                foreach (ExpiredProduct prod in data.Skip(1))
                {
                    mcv.Dispatcher.Invoke(new Action<ExpiredProduct>(Rows.Add), prod);
                    count++;
                }
                w.Stop();
                return count;
            });
            mcv.Filter = o1 =>
            {
                var prod = o1 as ExpiredProduct;
                bool res = true;
                if (prod == null) return false;

                if (!IsNullOrEmpty(ProductFilter.Code))
                {
                    res &= prod.Code.Contains(ProductFilter.Code);
                }
                if (!IsNullOrEmpty(ProductFilter.Name))
                {
                    res &= prod.Name.Contains(ProductFilter.Name);
                }
                if (!ProductFilter.ExpireDate.Equals(new DateTime()))
                {
                    res &= DateFilterMethod.Filter(prod.ExpireDate, ProductFilter.ExpireDate);
                }
                return res;
            };
            int i = await enumTask;
            MessageBox.Show($"{i} ops of {nameof(Open)} done in {w.Elapsed}.");
        }

        public bool Updating
        {
            get { return _updating; }
            set
            {
                if (value == _updating) return;
                _updating = value;
                NotifyPropertyChanged(nameof(Updating));
            }
        }

        public ObservableCollection<ExpiredProduct> Rows { get; set; }
        public Command OpenCommand { get; }
        public override bool IsValid => true;
    }
}
