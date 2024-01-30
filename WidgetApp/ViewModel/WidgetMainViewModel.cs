using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace WidgetApp.ViewModel {
    public class WidgetMainViewModel : INotifyPropertyChanged {
        private BitmapSource _imageSource;
        public BitmapSource ImageSource {
            get { return _imageSource; }
            set {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        private double _windowWidth;
        private double _windowHeight;
        public double WindowWidth {
            get { return _windowWidth; }
            set {
                _windowWidth = value;
                OnPropertyChanged(nameof(WindowWidth));
                UpdateWindowSize();
            }
        }
        public double WindowHeight {
            get { return _windowHeight; }
            set {
                _windowHeight = value;
                OnPropertyChanged(nameof(WindowHeight));
                UpdateWindowSize();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateWindowSize() {
            WindowWidth = _imageSource.PixelWidth;
            WindowHeight = _imageSource.PixelHeight;
        }
    }
}
