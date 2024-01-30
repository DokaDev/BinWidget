using System.Windows;
using WidgetApp.ViewModel;

namespace WidgetApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        WidgetMainViewModel _viewModel = new();
        public MainWindow() {
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}