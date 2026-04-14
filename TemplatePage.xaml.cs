using EnvDTE;
using Microsoft.VisualStudio.TextManager.Interop;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VisualStudioLauncher
{
    /// <summary>
    /// Interaction logic for TemplatePage.xaml
    /// </summary>
    public partial class TemplatePage : Page
    {
        public TemplatePage()
        {
            InitializeComponent();
            TemplatePageViewModel _vm = new TemplatePageViewModel();
            DataContext = _vm;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var _page = Activator.CreateInstance(typeof(ConfigureProjectPage));
            ((Page)_page).DataContext = DataContext;
            ((MainWindow)Application.Current.MainWindow).frame.Navigate(_page);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PageLoader.ChangeFrame(typeof(MainPage));
        }
    }
}
