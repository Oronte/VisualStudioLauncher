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
                location.Placeholder = _openFolder.FolderName;
        }

        void CreateProject(object sender, EventArgs e)
        {
            string _projectName = projectName.Placeholder;
            string _location = location.Placeholder;
        }
    }
}
