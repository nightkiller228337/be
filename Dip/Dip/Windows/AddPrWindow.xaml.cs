using Dip.Classes;
using Dip.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using IronBarCode;

namespace Dip.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPrWindow.xaml
    /// </summary>
    public partial class AddPrWindow : Window
    {
        public AddPrWindow(Product product)
        {
            InitializeComponent();
            CbCountry.ItemsSource = AppData.Context.Country.ToList();
            CbManuf.ItemsSource = AppData.Context.Manufacturer.ToList();
            CbStorage.ItemsSource = AppData.Context.Storage.ToList();
            CbType.ItemsSource = AppData.Context.TypeProduct.ToList();
            this.DataContext = product;
            ImgDef.DataContext = product.Image;
        }

        private void TbName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var product = this.DataContext as Product;
            string errors = "";
            if (string.IsNullOrWhiteSpace(product.Name))
                errors += "Вы не ввели имя";
            if (string.IsNullOrWhiteSpace(Convert.ToString(product.QuantityInTotal)))
                errors += "Вы не ввели количество";
            if (string.IsNullOrWhiteSpace(product.Article))
                errors += "Вы не ввели артикул";
            if (string.IsNullOrWhiteSpace(Convert.ToString(product.Price)))
                errors += "Вы не ввели количество";

            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show(errors);
            }
            else
            {
                product.Image = ImgDef.DataContext as byte[];
                if (product.id == 0)
                {
                    Guid guid = Guid.NewGuid();
                    product.code = guid.ToString();
                    AppData.Context.Product.Add(product);

                }
                product.Manufacturer = AppData.Context.Manufacturer.Where(manuf => manuf.id == (CbManuf.SelectedIndex + 1)).FirstOrDefault();
                product.Country = AppData.Context.Country.Where(country => country.id == (CbCountry.SelectedIndex + 1)).FirstOrDefault();
                product.TypeProduct = AppData.Context.TypeProduct.Where(type => type.id == (CbType.SelectedIndex + 1)).FirstOrDefault();

                AppData.Context.SaveChanges();
                this.DialogResult = true;

            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files |*.png;*.jpg";
            if (ofd.ShowDialog() == true)
            {
                ImgDef.DataContext = File.ReadAllBytes(ofd.FileName);
            }
        }
    }
}
