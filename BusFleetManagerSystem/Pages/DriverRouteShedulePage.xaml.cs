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
    /// Логика взаимодействия для DriverRouteShedulePage.xaml
    /// </summary>
    public partial class DriverRouteShedulePage : Page
    {
        BusFleetManagerSystemDBEntities db = new BusFleetManagerSystemDBEntities();
        public DriverRouteShedulePage()
        {
            InitializeComponent();
            
            DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Schedules.ToList();
            DGridBusRoutes.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Buses.ToList();
        }

        private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }
    }
}
