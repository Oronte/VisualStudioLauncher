using EnvDTE;
using EnvDTE90;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace VisualStudioLauncher
{
    public class TemplateManifest
    {
        public List<Template> Templates { get; set; }
    }

    public class TemplatePageViewModel : ViewModelBase
    {

        public ObservableCollection<Template> RecentsTemplate { get; set; } = new ObservableCollection<Template>();
        Template selectedTemplate = null;

        public Template SelectedTemplate
        {
            get { return selectedTemplate; }
            set
            {
                selectedTemplate = value;
                OnPropertyChanged();
            }
        }

        public TemplatePageViewModel()
        {
            InitRecentsTemplates();
        }

        void InitRecentsTemplates()
        {
            string json = File.ReadAllText(@"../../../Resources/Json/RecentsTemplate.json");
            TemplateManifest _alltemplates = JsonSerializer.Deserialize<TemplateManifest>(json);
            if (_alltemplates.Templates == null)
            {
                Console.WriteLine("OOOH il est null");
                return;
            }
            foreach (Template item in _alltemplates.Templates)
            {
                item.Icon = new BitmapImage(new Uri("pack://application:,,,/" + item.IconString, UriKind.Absolute));
            }
            RecentsTemplate = new ObservableCollection<Template>(_alltemplates.Templates);
        }
    }
}
