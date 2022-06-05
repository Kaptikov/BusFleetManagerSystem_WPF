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
    /// Логика взаимодействия для BusDriverPage.xaml
    /// </summary>
    public partial class BusDriverPage : Page
    {
        private Bus _currentBus = new Bus();
        private Driver _currentDriver = new Driver();

        //public string Bus { get { return Tag + " (" + Location.Name + ")"; } }
        public BusDriverPage()
        {
            InitializeComponent();
            DataContext = _currentBus;
            DGridBusDriver.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
            //ComboBoxBusTypeIdUpdate.ItemSource = BusFleetManagerSystemDBEntities.GetContext().Buses.ToList();
            ComboBoxBusNumberUpdate.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
            //ComboBoxBusTypeId.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().BusTypes.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var driversForRemoving = DGridBusDriver.SelectedItems.Cast<Driver>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {driversForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BusFleetManagerSystemDBEntities.GetContext().Drivers.RemoveRange(driversForRemoving);
                    BusFleetManagerSystemDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridBusDriver.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
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
                //BusType type = new BusType();
                bus.BusNumber = _currentBus.BusNumber;
                BusFleetManagerSystemDBEntities.GetContext().Buses.Add(bus);

                Driver driver = new Driver();
                //BusType type = new BusType();
                //driver.BusNumber = _currentDriver.BusNumber;
                BusFleetManagerSystemDBEntities.GetContext().Drivers.Add(_currentDriver);

                //BusType type = new BusType();
                //type.BusTypeId = _currentBusType.BusTypeId;
                //BusFleetManagerSystemDBEntities.GetContext().Buses.Add(_currentBus);
            }
            try
            {
                var db = BusFleetManagerSystemDBEntities.GetContext();
                BusFleetManagerSystemDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!");
                DGridBusDriver.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
                //textBoxBusNumber.Clear();
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
                DGridBusDriver.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
            }
        }
    }
}
