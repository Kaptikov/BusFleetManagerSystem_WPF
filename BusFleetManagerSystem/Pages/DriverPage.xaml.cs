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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusFleetManagerSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для DriverPage.xaml
    /// </summary>
    public partial class DriverPage : Page
    {
        private Driver _currentDriver = new Driver();
        /*public DriverPage(Driver selectedDriver)
        {
            InitializeComponent();

            if (selectedDriver != null)
            {
                _currentDriver = selectedDriver;
            }

            DataContext = _currentDriver;
            //DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
        }*/

        public DriverPage()
        {
            InitializeComponent();
            DataContext = _currentDriver;
            //DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var driversForRemoving = DGridDrivers.SelectedItems.Cast<Driver>().ToList();
            
            if (MessageBox.Show($"Вы точно хотите удалить следующие {driversForRemoving.Count()} элементов?", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BusFleetManagerSystemDBEntities.GetContext().Drivers.RemoveRange(driversForRemoving);
                    BusFleetManagerSystemDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
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
            /*if (string.IsNullOrWhiteSpace(_currentDriver.Firstname))
            {
                errors.AppendLine("Укажите имя!");
            }

            if (string.IsNullOrWhiteSpace(_currentDriver.Lastname))
            {
                errors.AppendLine("Укажите фамилию!");
            }

            if (string.IsNullOrWhiteSpace(_currentDriver.Registration))
            {
                errors.AppendLine("Укажите регистрацию!");
            }

            if (string.IsNullOrWhiteSpace(_currentDriver.Registration))
            {
                errors.AppendLine("Укажите оклад!");
            }

            if (_currentDriver.PassportSeries < 4)
            {
                errors.AppendLine("Некорректная серия паспорта");
            }

            if (_currentDriver.PassportNumber < 6 || _currentDriver.PassportNumber > 6)
            {
                errors.AppendLine("Некорректный номер паспорта");
            }

            if (_currentDriver.DriverClass < 1 || _currentDriver.DriverClass > 3)
            {
                errors.AppendLine("Некорректный класс водителя");
            }

            if (_currentDriver.WorkExperience < 5)
            {
                errors.AppendLine("Некорректный стаж работы");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentDriver.DriverId == 0)
            {
                BusFleetManagerSystemDBEntities.GetContext().Drivers.Add(_currentDriver);
            }*/
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
            if (string.IsNullOrWhiteSpace(_currentDriver.Firstname))
            {
                errors.AppendLine("Укажите имя!");
            }

            if (string.IsNullOrWhiteSpace(_currentDriver.Lastname))
            {
                errors.AppendLine("Укажите фамилию!");
            }

            if (string.IsNullOrWhiteSpace(_currentDriver.Registration))
            {
                errors.AppendLine("Укажите регистрацию!");
            }

            if (string.IsNullOrWhiteSpace(_currentDriver.Registration))
            {
                errors.AppendLine("Укажите оклад!");
            }
            /*
            if (_currentDriver.PassportSeries < 4 || )
            {
                errors.AppendLine("Некорректная серия паспорта");
            }

            if (_currentDriver.PassportNumber < 6 || _currentDriver.PassportNumber > 6)
            {
                errors.AppendLine("Некорректный номер паспорта");
            }*/

            if (_currentDriver.DriverClass < 1 || _currentDriver.DriverClass > 3)
            {
                errors.AppendLine("Некорректный класс водителя");
            }

            if (_currentDriver.WorkExperience < 5)
            {
                errors.AppendLine("Некорректный стаж работы");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentDriver.DriverId == 0)
            {
                BusFleetManagerSystemDBEntities.GetContext().Drivers.Add(_currentDriver);
            }
            try
            {
                BusFleetManagerSystemDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!");
                DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
                textBoxFirstname.Clear();
                textBoxSurname.Clear();
                textBoxLastname.Clear();
                textBoxPassportSeries.Clear();
                textBoxPassportNumber.Clear();
                textBoxRegistration.Clear();
                textBoxDriverClass.Clear();
                textBoxWorkExperience.Clear();
                textBoxSalary.Clear();
                //DialogHost.Close(DialogWindow.DialogContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusFleetManagerSystemDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Drivers.ToList();
            }
        }
    }
}
