using Restaurateur.DAO;
using Restaurateur.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Restaurateur.Forms
{
    /// <summary>
    /// Klasa obsługująca formularz dodawania i edycji rezerwacji
    /// </summary>
    public partial class Reservations : UserControl
    {
        public Reservations()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string idValue = InputId.Text;
            int id = int.Parse(idValue);
            string mode = (sender as Button).Tag.ToString();

            ReservationModel model = new ReservationModel
            {
                Id = id,
                FirstName = InputFirstName.Text,
                LastName = InputLastName.Text,
                StartDate = (DateTime)InputStartDate.SelectedDate,
                EndDate = (DateTime)InputEndDate.SelectedDate,
                TableId = (InputTableId.SelectedItem as TableModel).Id
            };

            if (mode == ReservationModel.INSERT)
            {
                ReservationDao.Insert(model);
                MessageBox.Show("Rezerwacja została dodana", "Dodawanie rezerwacji");
            }
            else if (mode == ReservationModel.UPDATE)
            {
                ReservationDao.Update(model);
                MessageBox.Show("Zmiany zostały zapisane", "Edytowanie rezerwacji");
            }

            Back();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }

        private void Back()
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            UserControl uc = new Restaurateur.Reservations();
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}
