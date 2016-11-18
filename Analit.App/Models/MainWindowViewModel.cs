using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Analit.Common.Models;

namespace Analit.App.Models
{
    public class MainWindowViewModel
    {
        public ObservableCollection<ProductPosition> ProductPositions { get; set; }
        public ObservableCollection<Product> Products { get; set; }
    }

    public sealed class ProductPosition : INotifyPropertyChanged
    {
        private int _count;

        public Product Product { get; set; }

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();
                //OnPropertyChanged("Sum");
            }
        }

        public decimal Sum => _count*Product.Price;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}