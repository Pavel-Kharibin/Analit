using System.Windows;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}