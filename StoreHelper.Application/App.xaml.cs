using System.Windows;

namespace StoreHelper.Application
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var loginWindow = new View.LoginWindow();
            loginWindow.DataContext = new Controller.LoginController();
            loginWindow.Show();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
