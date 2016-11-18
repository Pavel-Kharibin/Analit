using System.Threading.Tasks;
using System.Windows;
using Analit.App.Models;
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

            DataContext = new MainWindowViewModel();

            _service = service;
        }

        private MainWindowViewModel Model => (MainWindowViewModel) DataContext;

        private async Task LoadProductsAsync()
        {
            var products = await _service.ProductsGetAllAsync();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadProductsAsync();
        }
    }
}