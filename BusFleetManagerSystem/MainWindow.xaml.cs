using BusFleetManagerSystem.DataAccess;
using BusFleetManagerSystem.Pages;
using BusFleetManagerSystem.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusFleetManagerSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void btnDriversWindow_Click(object sender, RoutedEventArgs e)
        {
            
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

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnSelectedItemChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void btnDriverPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DriverPage();
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MainPage();
        }

        private void btnBusPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new BusPage();
        }
        /*private void btnLogin_Click(object sender, RoutedEventArgs e)
{
string login = textBoxLogin.Text.Trim();
string pass = passBoxPass.Password.Trim();

if (login.Length < 5)
{
textBoxLogin.ToolTip = "Это поле введено не корректно!";
}
else if (pass.Length < 5)
{
passBoxPass.ToolTip = "Это поле введено не корректно!";
passBoxPass.Background = Brushes.DarkRed;
}
else
{
textBoxLogin.ToolTip = "";
textBoxLogin.Background = Brushes.Transparent;
passBoxPass.ToolTip = "";
passBoxPass.Background = Brushes.Transparent;
}
}*/
    }
}
