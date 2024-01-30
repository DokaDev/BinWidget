using GalaSoft.MvvmLight;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

namespace WidgetApp.ViewModel {
    public class WidgetMainViewModel : ViewModelBase {
        [DllImport("BinCore.dll")]
        private static extern bool IsRecycleBinEmpty();

        [DllImport("BinCore.dll")]
        private static extern void GetRecycleBinStatus(ref Int64 itemCount, ref Int64 totalSize);

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

        //public WidgetMainViewModel() {
        //    Bitmap bitmap = new("empty4.png");
        //    ImageSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        //}
    }
}