using System.Windows;
using System.Windows.Input;
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

            MouseLeftButtonDown += new MouseButtonEventHandler((s, e) => {
                DragMove();
            });
            KeyDown += new KeyEventHandler((s, e) => {

            });
        }
    }
}