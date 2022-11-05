using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Squirrel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        UpdateManager manager;
        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            manager = await UpdateManager
               .GitHubUpdateManager(@"https://github.com/vinayakkolhe/wpf-application-with-Squirrel-and-GitHub");
            
            VersionTxt.Text = manager.CurrentlyInstalledVersion().ToString();
        }


        private async void CheckUpdate_Click(object sender, RoutedEventArgs e)
        {
            var updateInfo = await manager.CheckForUpdate();

            if (updateInfo.ReleasesToApply.Count > 0)
            {
                Update.IsEnabled = true;
            }
            else
            {
                Update.IsEnabled = false;
            }
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            await manager.UpdateApp();

            MessageBox.Show("Updated succesfuly!");
        }
    }
}
