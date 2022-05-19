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
using System.Windows.Shapes;

namespace BusFleetManagerSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для DriverWindow.xaml
    /// </summary>
    public partial class DriverWindow : Window
    {
        public DriverWindow()
        {
            InitializeComponent();
            DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditPage addEditPage = new AddEditPage();
            addEditPage.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
