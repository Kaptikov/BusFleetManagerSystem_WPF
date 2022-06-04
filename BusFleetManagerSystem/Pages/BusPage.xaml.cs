using BusFleetManagerSystem.DataAccess;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для BusPage.xaml
    /// </summary>
    public partial class BusPage : Page
    {
        private Bus _currentBus = new Bus();
        private BusType _currentBusType = new BusType();
        //public string Bus { get { return Tag + " (" + Location.Name + ")"; } }
        public BusPage()
        {
            InitializeComponent();
            DataContext = _currentBus;
            DGridBuses.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Buses.ToList();
            //ComboBoxBusTypeIdUpdate.ItemSource = BusFleetManagerSystemDBEntities.GetContext().Buses.ToList();
            ComboBoxBusTypeId.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().BusTypes.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var busesForRemoving = DGridBuses.SelectedItems.Cast<Bus>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {busesForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BusFleetManagerSystemDBEntities.GetContext().Buses.RemoveRange(busesForRemoving);
                    BusFleetManagerSystemDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridBuses.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Buses.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
            try
            {
                BusFleetManagerSystemDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные обнавлены!");
                //DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
                /*textBoxFirstname.Clear();
                textBoxSurname.Clear();
                textBoxLastname.Clear();
                textBoxPassportSeries.Clear();
                textBoxPassportNumber.Clear();
                textBoxRegistration.Clear();
                textBoxDriverClass.Clear();
                textBoxWorkExperience.Clear();
                textBoxSalary.Clear();*/
                //DialogHost.Close(DialogWindow.DialogContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentBus.BusId == 0)
            {
                Bus bus = new Bus();
                bus.BusNumber = _currentBus.BusNumber;
                BusFleetManagerSystemDBEntities.GetContext().Buses.Add(bus);

                BusType type = new BusType();
                type.BusTypeId = _currentBusType.BusTypeId;
                BusFleetManagerSystemDBEntities.GetContext().BusTypes.Add(type);
            }
            try
            {
                var db = BusFleetManagerSystemDBEntities.GetContext();
                BusFleetManagerSystemDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!");
                DGridBuses.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Buses.ToList();
                //DGridBuses.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().BusTypes.ToList();
                textBoxBusNumber.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }

        private void Sample2_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
            => Debug.WriteLine($"SAMPLE 2: Closing dialog with parameter: {eventArgs.Parameter ?? string.Empty}");

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusFleetManagerSystemDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridBuses.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Buses.ToList();
            }
        }

    }
}
