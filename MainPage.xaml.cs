using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace VisualStudioLauncher
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new RecentProjectsViewModel();
        }

        void NavigateToTemplates(object sender, RoutedEventArgs e) => PageLoader.ChangeFrame(typeof(TemplatePage));

        void OpenLocalProject(object sender, EventArgs e)
        {
            OpenFileDialog _openFileDialog = new OpenFileDialog
            {
                Filter = "Solution Visual Studio (*.sln)|*.sln",
                DefaultExt = ".sln"
            };
            bool? result = _openFileDialog.ShowDialog();

            if (result == true)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _openFileDialog.FileName,
                    UseShellExecute = true
                });
            }
        }
    }
}
