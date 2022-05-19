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
    /// Логика взаимодействия для WindowDemo.xaml
    /// </summary>
    public partial class WindowDemo : Window
    {
        public WindowDemo()
        {
            InitializeComponent();
            BusFleetManagerSystemDBEntities db = new BusFleetManagerSystemDBEntities();

            var docs = from d in db.Drivers
                       select new
                       {
                           DriverName = d.Firstname,
                           DriverSurname = d.Surname,
                           DriverLastName = d.Lastname,
                           DriverPassportSeries = d.PassportSeries,
                           DriverPassportNumber = d.PassportNumber,
                           DriverRegistration = d.Registration,
                           DriverDriverClass = d.DriverClass,
                           DriverWorkExperience = d.WorkExperience,
                           DriverSalary = d.Salary
                       };

            foreach (var item in docs)
            {
                Console.WriteLine(item.DriverName);
                Console.WriteLine(item.DriverSurname);
                Console.WriteLine(item.DriverLastName);
                Console.WriteLine(item.DriverPassportSeries);
                Console.WriteLine(item.DriverPassportNumber);
                Console.WriteLine(item.DriverRegistration);
                Console.WriteLine(item.DriverDriverClass);
                Console.WriteLine(item.DriverWorkExperience);
                Console.WriteLine(item.DriverSalary);
            }

            this.gridDrivers.ItemsSource = docs.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BusFleetManagerSystemDBEntities db = new BusFleetManagerSystemDBEntities();

            Driver driversObject = new Driver()
            {
                Firstname = txtName.Text,
                Surname = txtSurname.Text,
                Lastname = txtLastname.Text,
                PassportSeries = int.Parse(txtPassportSeries.Text),
                PassportNumber = int.Parse(txtPassportNumber.Text),
                Registration = txtRegistration.Text,
                DriverClass = int.Parse(txtDriverClass.Text),
                WorkExperience = int.Parse(txtWorkExperience.Text),
                Salary = int.Parse(txtSalary.Text)
            };
            db.Drivers.Add(driversObject);
            db.SaveChanges();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            BusFleetManagerSystemDBEntities db = new BusFleetManagerSystemDBEntities();

            this.gridDrivers.ItemsSource = db.Drivers.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            BusFleetManagerSystemDBEntities db = new BusFleetManagerSystemDBEntities();

            db.SaveChanges();
        }

        private int updatingDriverId = 0;
        private void gridDrivers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridDrivers.SelectedIndex >= 0)
            {
                if (this.gridDrivers.SelectedItems.Count >= 0)
                {
                    if (this.gridDrivers.SelectedItems[0].GetType() == typeof(Driver))
                    {
                        Driver d = (Driver)this.gridDrivers.SelectedItems[0];
                        this.txtNameUpdate.Text = d.Firstname;
                        this.txtSurnameUpdate.Text = d.Surname;
                        this.txtLastnameUpdate.Text = d.Lastname;
                        this.txtPassportSeriesUpdate.Text = d.PassportSeries.ToString();
                        this.txtPassportNumberUpdate.Text = d.PassportNumber.ToString();
                        this.txtRegistrationUpdate.Text = d.Registration;
                        this.txtDriverClassUpdate.Text = d.DriverClass.ToString();
                        this.txtWorkExperienceUpdate.Text = d.WorkExperience.ToString();
                        this.txtSalaryUpdate.Text = d.Salary.ToString();

                        this.updatingDriverId = d.DriverId;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            BusFleetManagerSystemDBEntities db = new BusFleetManagerSystemDBEntities();

            var r = from d in db.Drivers
                    where d.DriverId == this.updatingDriverId
                    select d;

            Driver obj = r.SingleOrDefault();

            if (obj != null)
            {
                obj.Firstname = this.txtNameUpdate.Text;
                obj.Surname = this.txtSurnameUpdate.Text;
                obj.Lastname = this.txtLastnameUpdate.Text;
                obj.PassportSeries = int.Parse(this.txtPassportSeries.Text);
                obj.PassportNumber = int.Parse(this.txtPassportNumberUpdate.Text);
                obj.Registration = this.txtRegistrationUpdate.Text;
                obj.DriverClass = int.Parse(this.txtDriverClassUpdate.Text);
                obj.WorkExperience = int.Parse(this.txtWorkExperienceUpdate.Text);
                obj.Salary = int.Parse(this.txtSalaryUpdate.Text);
            }
            db.SaveChanges();
        }
    }
}
