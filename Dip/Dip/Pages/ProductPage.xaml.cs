using Dip.Classes;
using Dip.Models;
using Dip.Windows;
using IronBarCode;
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

namespace Dip.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            LvProduct.ItemsSource = AppData.Context.Product.ToList();
            List<TypeProduct> productCategories = AppData.Context.TypeProduct.ToList();
            productCategories.Insert(0, new TypeProduct() { TypeName = "Все категории" });
            CbFilter.ItemsSource = productCategories;
            CbGrouping.ItemsSource = new List<string>() { "По возрастанию", "По убыванию" };
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateLvData();
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLvData();
        }

        private void CbGrouping_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLvData();
        }
        private void UpdateLvData()
        {
            var products = AppData.Context.Product.ToList();
            if (CbFilter.SelectedIndex != 0)
            products = products.Where(p => p.TypeProduct.id == (CbFilter.SelectedItem as TypeProduct).id).ToList();
            if (!string.IsNullOrWhiteSpace(TbSearch.Text))
                products = products.Where(p => p.Name.ToLower().Trim().Contains(TbSearch.Text.ToLower().Trim())).ToList();
            switch (CbGrouping.SelectedIndex)
            {
                case 0:
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                    case 1:
                    products = products.OrderBy(p => p.Price).Reverse().ToList();
                    break;
            }
            LvProduct.ItemsSource = products;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPrWindow window = new AddPrWindow(new Product());
            if (window.ShowDialog() == true) 
                LvProduct.ItemsSource = AppData.Context.Product.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddPrWindow window = new AddPrWindow((sender as Button).DataContext as Product);
            if (window.ShowDialog() == true)
                LvProduct.ItemsSource = AppData.Context.Product.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.Context.Product.Remove((sender as Button).DataContext as Product);
                AppData.Context.SaveChanges();
            }
            LvProduct.ItemsSource = AppData.Context.Product.ToList();
        }

        private void BtnShowQr_Click(object sender, RoutedEventArgs e)
        {
            ShowQrWindow window = new ShowQrWindow((sender as Button).DataContext as Product);
            window.ShowDialog();
        }
    }
}
