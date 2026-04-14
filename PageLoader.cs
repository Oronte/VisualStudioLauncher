using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VisualStudioLauncher
{
    public class PageLoader
    {
        public static void ChangeFrame(Type _pageType) => ((MainWindow)Application.Current.MainWindow).frame.Navigate(Activator.CreateInstance(_pageType));
    }
}
