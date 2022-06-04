using BusFleetManagerSystem.DataAccess;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace BusFleetManagerSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Window
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void MenuDarkModeButton_Click(object sender, RoutedEventArgs e)
            => ModifyTheme(DarkModeToggleButton.IsChecked == true);

        private static void ModifyTheme(bool isDarkTheme)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(isDarkTheme ? Theme.Dark : Theme.Light);
            paletteHelper.SetTheme(theme);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length < 3)
            {
                textBoxLogin.ToolTip = "Логин введен не корректно!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if(pass.Length < 3)
            {
                passBox.ToolTip = "Пароль введен не корректно!";
                passBox.Background = Brushes.DarkRed;
            } else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (BusFleetManagerSystemDBEntities db = new BusFleetManagerSystemDBEntities())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Password == pass).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Вы вошли!");

                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                }
                    
                else
                    MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnSelectedItemChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
