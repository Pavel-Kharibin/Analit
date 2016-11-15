using System.Windows;
using Microsoft.Practices.Unity;

namespace Analit.App
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ShutdownMode = ShutdownMode.OnMainWindowClose;

            var container = Bootstrapper.Initialise();
            var mainWindow = container.Resolve<MainWindow>();

            mainWindow.Show();
        }
    }
}