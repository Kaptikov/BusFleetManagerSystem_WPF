using BusFleetManagerSystem.DataAccess;
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

namespace BusFleetManagerSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для DriverPage.xaml
    /// </summary>
    public partial class DriverPage : Page
    {
        public DriverPage()
        {
            InitializeComponent();
            DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }

        private void BtnEdit_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
