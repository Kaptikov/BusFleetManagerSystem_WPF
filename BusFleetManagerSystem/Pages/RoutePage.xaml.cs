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
    /// Логика взаимодействия для RoutePage.xaml
    /// </summary>
    public partial class RoutePage : Page
    {
        private BusRoute _currentBusRoute = new BusRoute();
        public RoutePage()
        {
            InitializeComponent();
            DataContext = _currentBusRoute;
            DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().BusRoutes.ToList();
            //ComboBoxBusNumber.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().Buses.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
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

                    DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().BusRoutes.ToList();
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

            if (string.IsNullOrWhiteSpace(_currentBusRoute.StartpointName))
            {
                errors.AppendLine("Укажите точку отправления!");
            }

            if (string.IsNullOrWhiteSpace(_currentBusRoute.EndpointName))
            {
                errors.AppendLine("Укажите точку приезда!");
            }

            /*if (_currentDriver.PassportSeries < 4 && _currentDriver.PassportSeries >= 5)
            {
                errors.AppendLine("Некорректная серия паспорта");
            }

            if (_currentDriver.PassportNumber < 6 && _currentDriver.PassportNumber >= 7)
            {
                errors.AppendLine("Некорректный номер паспорта");
            }*/


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentBusRoute.BusRouteId == 0)
            {
                BusRoute route = new BusRoute();
                route.RouteNumber = _currentBusRoute.RouteNumber;
                route.StartpointName = _currentBusRoute.StartpointName;
                route.EndpointName = _currentBusRoute.EndpointName;
                route.StartTime = _currentBusRoute.StartTime;
                route.EndTime = _currentBusRoute.EndTime;
                route.MovementInterval = _currentBusRoute.MovementInterval;
                route.RouteLength = _currentBusRoute.RouteLength;
                route.PointOfDeparture_DeparturePointId = _currentBusRoute.PointOfDeparture_DeparturePointId;

                BusFleetManagerSystemDBEntities.GetContext().BusRoutes.Add(route);
            }
            try
            {
                var db = BusFleetManagerSystemDBEntities.GetContext();
                BusFleetManagerSystemDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!");
                DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().BusRoutes.ToList();
                textBoxRouteNumber.Clear();
                textBoxStartpointName.Clear();
                textBoxEndpointName.Clear();
                textBoxStartTime.Clear();
                textBoxEndTime.Clear();
                textBoxMovementInterval.Clear();
                textBoxRouteLength.Clear();
                textBoxPointOfDeparture_DeparturePointId.Clear();
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

        private void Sample2_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
            => Debug.WriteLine($"SAMPLE 2: Closing dialog with parameter: {eventArgs.Parameter ?? string.Empty}");

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BusFleetManagerSystemDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridDrivers.ItemsSource = BusFleetManagerSystemDBEntities.GetContext().BusRoutes.ToList();
            }
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            var wordApp = new MSWord.Application();
            // MessageBox.Show("Word запущен!");
            // 2) покажем окно Word
            wordApp.Visible = true;

            // 3) добавим докумет!
            wordApp.Documents.Add();
            // wordApp.Documents.Add();
            // wordApp.Documents.Add();

            // 4) добавим текст
            // нужно выбрать документ
            MSWord.Document doc = wordApp.Documents[1];

            doc.Paragraphs.Add();
            MSWord.Paragraph paragraph = doc.Paragraphs[1];
            paragraph.Range.Text = $"Привет, сегодня {DateTime.Now}!";

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[2];
            paragraph.Range.Text = "Заголовок документа";
            // форматирование
            paragraph.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter;
            paragraph.Range.Font.Bold = 1;
            paragraph.Range.Font.Color = MSWord.WdColor.wdColorRed;

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[3];
            paragraph.Range.Text = "Таблица №1";
            paragraph.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphJustify;
            paragraph.Range.Font.Bold = 0;
            paragraph.Range.Font.Color = MSWord.WdColor.wdColorBlack;

            doc.Paragraphs.Add();
            paragraph = doc.Paragraphs[4];

            doc.Tables.Add(paragraph.Range, 6, 4, true);
            MSWord.Table table = doc.Tables[1];
            table.Borders.OutsideColor = MSWord.WdColor.wdColorRed;
            table.Borders.OutsideLineStyle = MSWord.WdLineStyle.wdLineStyleDouble;
            table.Borders.InsideLineStyle = MSWord.WdLineStyle.wdLineStyleDot;
            // данные в таблицу
            table.Cell(1, 1).Range.Text = "Наименование";
            table.Cell(1, 1).Range.Text = "Цена";
            table.Cell(1, 1).Range.Text = "Количество, шт";
            table.Cell(1, 1).Range.Text = "Стоимость";

            string[] names = { "Хлеб", "Колбаса", "Молоко", "Сыр" };
            int[] prices = { 50, 550, 65, 700 };
            int[] quantities = { 2, 3, 4, 5 };

            for (int i = 0; i < names.Length; i++)
            {
                table.Cell(2 + i, 1).Range.Text = names[i];
                table.Cell(2 + i, 2).Range.Text = prices[i].ToString("c");
                table.Cell(2 + i, 3).Range.Text = quantities[i].ToString("c");
                table.Cell(2 + i, 4).Range.Text = (prices[i] * quantities[i]).ToString("c");
            }
            table.Cell(6, 1).Range.Text = "Итого";
            table.Cell(6, 4).Range.Text = prices.Select((x, i) => x * quantities[i]).ToList().Sum().ToString("c");
            table.Cell(6, 1).Merge(table.Cell(6, 3));

            //wordApp.Visible = true;
            // автоматически сохраним документ
            doc.SaveAs2("d:\\my.doc", MSWord.WdSaveFormat.wdFormatDocument);
            doc.Close();
            wordApp.Quit();
            MessageBox.Show("документ готов");
        }
    }
}
