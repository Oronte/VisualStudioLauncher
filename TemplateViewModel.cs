using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VisualStudioLauncher
{
    public class TemplateViewModel
    {
        public Template Model { get; }

        //public string Name => Model.Name;
        //public string Description => Model.Description;
        //public string Icon => Model.Icon;
        //public string Language => Model.Language;

        public ICommand OpenCommand { get; }

        public TemplateViewModel(Template model)
        {
            Model = model;

            //OpenCommand = new RelayCommand(Open);
        }

        private void Open()
        {
            // logique : ouvrir projet / template
        }
    }
}
