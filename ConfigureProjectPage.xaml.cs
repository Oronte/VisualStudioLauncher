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
    /// Interaction logic for ConfigureProjectPage.xaml
    /// </summary>
    public partial class ConfigureProjectPage : Page
    {
        public ConfigureProjectPage()
        {
            InitializeComponent();
        }

        void SearchProjectLocation(object sender, EventArgs e)
        {
            OpenFolderDialog _openFolder = new OpenFolderDialog();
            bool? result = _openFolder.ShowDialog();

            if (result == true)
                location.Text = _openFolder.FolderName;
        }

        void CreateProject(object sender, EventArgs e)
        {
            string _projectName = projectName.Text;
            string _location = location.Text;
            TemplatePageViewModel _vm = (TemplatePageViewModel)DataContext;
            if(_vm == null)
            {
                Console.WriteLine("OOOOH il est null");
                return;
            }
            SolutionCreator.CreateProject(_vm.SelectedTemplate.vstemplatePath, _location, _projectName);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PageLoader.ChangeFrame(typeof(TemplatePage));
        }
    }
}
