using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            HomeModel homeModel = new HomeModel();
            MainWindow window = new MainWindow(){
                DataContext = homeModel
            };
            window.Show();
            base.OnStartup(e);
        }
    }
}
