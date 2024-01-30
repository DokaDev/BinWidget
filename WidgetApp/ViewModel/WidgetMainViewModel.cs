using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Interop;
using GalaSoft.MvvmLight;

namespace WidgetApp.ViewModel {
    public class WidgetMainViewModel : ViewModelBase {
        private BitmapSource _imageSource;
        public BitmapSource ImageSource {
            get => _imageSource;
            set {
                Set(ref _imageSource, value);
                UpdateWindowSize();
            }
        }

        private double _windowWidth;
        private double _windowHeight;
        public double WindowWidth {
            get => _windowWidth;
            set => Set(ref _windowWidth, value);
        }
        public double WindowHeight {
            get => _windowHeight;
            set => Set(ref _windowHeight, value);
        }

        private void UpdateWindowSize() {
            WindowWidth = _imageSource.PixelWidth;
            WindowHeight = _imageSource.PixelHeight;
        }

        public WidgetMainViewModel() {
            Bitmap bitmap = new("full4.png");
            ImageSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), nint.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            //ImageSource = dest;
        }
    }
}
