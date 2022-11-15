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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Reverse(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            AuthorizationSEntities db = new AuthorizationSEntities();
            
            if(tbLogin.Text != "" && tbPassword.Text !="" && tbName.Text !="" && tbRole.Text !="")
            {
                var user = new User
                {
                    Name = tbName.Text,
                    RoleName = tbRole.Text
                };
                var userLogin = new UserLogin
                {
                    Login = tbLogin.Text,
                    Password = tbPassword.Text,
                };
                user.UserLogin.Add(userLogin);
                db.User.Add(user);
                db.UserLogin.Add(userLogin);
                db.SaveChanges();
                MessageBox.Show("Registration succes!");
            }
        }
    }
}
