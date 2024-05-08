using Dip.Classes;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text != "" & TbPass.Text != "")
            {
                var currentUser = AppData.Context.User.ToList().Where(p => p.Login == TbLogin.Text).FirstOrDefault();
                if (currentUser != null)
                {
                    if (currentUser.Password == TbPass.Text)
                    {
                        if(currentUser.RoleId == 1)
                            AppData.MainFrame.Navigate(new ProductPageUser());

                        else
                        AppData.MainFrame.Navigate(new ProductPage());
                    }
                    else
                    {
                        MessageBox.Show("Пароль указан неверно");
                    }

                }
                else
                {
                    MessageBox.Show("Пользователя не существует");
                }

            }
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения");
            }
          
           
        }

        private void TbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
