using Microsoft.Win32;
using System.Diagnostics;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageLoader.ChangeFrame(typeof(MainPage));
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Maximize(null, null);
                return;
            }

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        void Close(object sender, RoutedEventArgs e) => Close();
        void Minimize(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        void Maximize(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else 
                WindowState = WindowState.Maximized;
        }
    }
}