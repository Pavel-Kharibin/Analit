using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Analit.App.Models;
using Analit.Common.Models;
using Analit.Service.Contract;

namespace Analit.App
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly IAnalitService _service;

        public MainWindow(IAnalitService service)
        {
            InitializeComponent();

            _service = service;
        }

        private MainWindowViewModel Model => (MainWindowViewModel) DataContext;

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BtnMakeOrder.IsEnabled = false;

            var model = new MainWindowViewModel();

            var products = await _service.ProductsGetAllAsync();

            model.Products = new ObservableCollection<Product>(products);

            model.PropertyChanged += (o, args) =>
            {
                switch (args.PropertyName)
                {
                    case nameof(Model.Cash):
                    case nameof(Model.TotalSum):
                        BtnMakeOrder.IsEnabled = Model.Cash >= Model.TotalSum && Model.ProductPositions.Count != 0;
                        break;
                }
            };
            model.ProductPositions.CollectionChanged += (o, args) =>
            {
                BtnMakeOrder.IsEnabled = Model.Cash >= Model.TotalSum && Model.ProductPositions.Count != 0;
            };

        DataContext = model;
        }

        private void BtnAddPosition_Click(object sender, RoutedEventArgs e)
        {
            ProductPosition position;
            if (Model.ProductPositions.Any(p => p.Product.Id == Model.SelectedProduct.Id))
            {
                position = Model.ProductPositions.First(p => p.Product.Id == Model.SelectedProduct.Id);
                position.Count += Convert.ToInt32(TxtProductsCount.Text);
                Model.OnPropertyChanged(nameof(Model.TotalSum));
                Model.OnPropertyChanged(nameof(Model.Change));
            }
            else
            {
                position = new ProductPosition
                {
                    Product = Model.SelectedProduct,
                    Count = Convert.ToInt32(TxtProductsCount.Text)
                };
                Model.ProductPositions.Insert(0, position);
            }

            Model.SelectedProductPosition = position;
        }

        private async void BtnMakeOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = new Order();

            foreach (var position in Model.ProductPositions)
            {
                order.OrderProducts.Add(
                    new OrderProduct
                    {
                        ProductId = position.Product.Id,
                        Count = position.Count
                    }
                );
            }

            await _service.OrderAddAsync(order);

            Model.Reset();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TxtProductsCount.Text = 1.ToString();
        }

        private void TxtProductsCount_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckTextInt(e.Text);
        }

        private void TxtProductsCount_OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof (string)))
            {
                var text = (string) e.DataObject.GetData(typeof (string));
                if (!CheckTextInt(text)) e.CancelCommand();
            }
            else e.CancelCommand();
        }

        private void TxtCash_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CheckTextInt(e.Text);
        }

        private void TxtCash_OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }

        private bool CheckTextInt(string text)
        {
            var regex = new Regex("^[0-9]+");
            return regex.IsMatch(text) && Convert.ToInt32(TxtProductsCount.Text + text) > 0;
        }
        
        //private bool CheckTextDecimal(string text)
        //{
        //    var regex = new Regex("^[0-9]*([.,])?([0-9]{1,2})?");
        //    return regex.IsMatch(Model.Cash + text);
        //}
    }
}