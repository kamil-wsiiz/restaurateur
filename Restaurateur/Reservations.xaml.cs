using Restaurateur.DAO;
using Restaurateur.Models;
using System.Windows;
using System.Windows.Controls;

namespace Restaurateur
{
    /// <summary>
    /// Klasa obsługująca widok rezerwacji
    /// </summary>
    public partial class Reservations : UserControl
    {
        public Reservations()
        {
            InitializeComponent();

            RefreshGrid();
        }

        /// <summary>
        /// Obsługa przycisku usuwania
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ReservationDao.Delete((long)(sender as Button).Tag);
            RefreshGrid();
        }

        /// <summary>
        /// Odświezanie danych
        /// </summary>
        private void RefreshGrid()
        {
            ReservationsDataGrid.ItemsSource = ReservationDao.LoadAll();
        }

        /// <summary>
        /// Obsługa przycisku dodawania
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            UserControl uc = new Forms.Reservations
            {
                DataContext = new ReservationModel()
            };
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }

        /// <summary>
        /// Obsluga przycisku edycji
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            UserControl uc = new Forms.Reservations();
            ReservationModel model = ReservationDao.LoadById((long)(sender as Button).Tag);
            model.Mode = "update";
            uc.DataContext = model;
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}