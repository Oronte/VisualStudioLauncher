using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace VisualStudioLauncher
{
    public class Template //POCO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string IconString { get; set; }
        public BitmapImage Icon { get; set; }
        public string vstemplatePath { get; set; }
    }
}
