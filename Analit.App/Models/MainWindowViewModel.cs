using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Analit.App.Annotations;
using Analit.Common.Models;
using Microsoft.Practices.ObjectBuilder2;

namespace Analit.App.Models
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private decimal _cash;
        private Product _selectedProduct;
        private ProductPosition _selectedProductPosition;

        public MainWindowViewModel()
        {
            ProductPositions = new ObservableCollection<ProductPosition>();
            ProductPositions.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(TotalSum));
                OnPropertyChanged(nameof(Change));
            };
        }

        public ObservableCollection<ProductPosition> ProductPositions { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        public Product SelectedProduct
        {
            get { return _selectedProduct ?? Products.FirstOrDefault(); }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ProductPosition SelectedProductPosition
        {
            get { return _selectedProductPosition ?? ProductPositions.FirstOrDefault(); }
            set
            {
                _selectedProductPosition = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalSum
        {
            get
            {
                decimal sum = 0;
                ProductPositions.ForEach(p => sum += p.Sum);

                return sum;
            }
        }

        public decimal Cash
        {
            get { return _cash; }
            set
            {
                _cash = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Change));
            }
        }

        public decimal Change => TotalSum > Cash ? 0 : Cash - TotalSum;
        public event PropertyChangedEventHandler PropertyChanged;

        public void Reset()
        {
            ProductPositions.Clear();
            SelectedProduct = Products.FirstOrDefault();
            Cash = 0;
        }

        [NotifyPropertyChangedInvocator]
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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
                OnPropertyChanged(nameof(Sum));
            }
        }

        public decimal Sum => _count*Product.Price;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}