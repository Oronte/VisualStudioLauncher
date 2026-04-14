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

namespace VisualStudioLauncher
{
    /// <summary>
    /// Interaction logic for SearchBarWidget.xaml
    /// </summary>
    public partial class SearchBarWidget : UserControl
    {
        public SearchBarWidget()
        {
            InitializeComponent();
        }
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(
                "Placeholder",
                typeof(string),
                typeof(TemplateWidget),
                new PropertyMetadata("Enter text..."));
    }
}
