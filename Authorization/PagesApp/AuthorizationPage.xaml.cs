using Authorization.AdoApp;
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

namespace Authorization.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void RegistrationNavigate(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void Authorization(object sender, RoutedEventArgs e)
        {
            AuthorizationSEntities db = new AuthorizationSEntities();
            if(tbLogin.Text != "" && tbPassword.Text != "")
            {
                var dataLogin = db.UserLogin.FirstOrDefault(x=> x.Login == tbLogin.Text && x.Password == tbPassword.Text);
                if(dataLogin != null)
                {
                    MessageBox.Show(dataLogin.User.Name);
                }
                else
                {
                    MessageBox.Show("Not have user with written login!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill login and password please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
