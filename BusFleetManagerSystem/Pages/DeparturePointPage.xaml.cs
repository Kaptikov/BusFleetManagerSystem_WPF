using BusFleetManagerSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для DeparturePointPage.xaml
    /// </summary>
    public partial class DeparturePointPage : Page
    {
        public DeparturePointPage()
        {
            InitializeComponent();
            //var allRoutes = BusFleetManagerSystemDBEntities.GetContext().StartpointName.ToList();
            DGridDeparturePoints.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().BusRoutes.ToList();
            ComboType.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().BusRoutes.ToList();
            UpdateRoute();
        }

        public ICollectionView EmpoyeesCollectionView { get; }

        public void UpdateRoute()
        {
            var currentRoutes = BusFleetManagerSystemDBEntities.GetContext().BusRoutes.ToList();

            /*if (ComboType.SelectedIndex > 0)
                currentRoutes = currentRoutes.Where(p => p.BusRouteId.ToString().Contains(ComboType.SelectedItem as DeparturePoint).ToList());*/

            currentRoutes = currentRoutes.Where(p => p.StartpointName.ToLower().Contains(txtBoxSearch.Text.ToLower())).ToList();

            //listDeparturePoint.ItemsSource = currentRoutes.OrderBy(p => p.StartpointName).ToList();
            DGridDeparturePoints.ItemsSource = currentRoutes.OrderBy(p => p.StartpointName).ToList();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRoute();
        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateRoute();
        }
    }
}
