﻿using Dip.Classes;
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
    /// Логика взаимодействия для ProductPageUser.xaml
    /// </summary>
    public partial class ProductPageUser : Page
    {
        public ProductPageUser()
        {
            InitializeComponent();
            LvProductUser.ItemsSource = AppData.Context.Product.ToList();
        }
    }
}
