using Dip.Classes;
using Dip.Models;
using IronBarCode;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Shapes;

namespace Dip.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShowQrWindow.xaml
    /// </summary>
    public partial class ShowQrWindow : Window
    {
        public ShowQrWindow(Product product)
        {
            InitializeComponent();
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(product.code, QRCodeGenerator.ECCLevel.Q);
            QRCode dt = new QRCode(data);
            Bitmap qrcodeimage = dt.GetGraphic(50);
            ImgQr.Source = BitmapToImageSource(qrcodeimage);
            this.DataContext = product;

        }
        private ImageSource BitmapToImageSource(Bitmap bitmap)
        {
            using(MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
                  
            }
        }
        
    }
}
