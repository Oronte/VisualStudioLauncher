using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioLauncher
{
    public class TemplatePageViewModel
    {
        ObservableCollection<Template> RecentsTemplate { get; set; } = new ObservableCollection<Template>();
    }
}
