using Restaurateur.DAO;
using Restaurateur.Models;
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
        
        /// <summary>
        /// Wysłanie formularza
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // Pobranie modelu z formularza
            ReservationModel model = DataContext as ReservationModel;

            if (model.StartDate > model.EndDate)
            {
                MessageBox.Show("Nieprawidłowe ustawienie dat", "Błąd");
                return;
            }

            if (model.Mode == ReservationModel.INSERT)
            {
                ReservationDao.Insert(model);
                MessageBox.Show("Rezerwacja została dodana", "Dodawanie rezerwacji");
            }
            else if (model.Mode == ReservationModel.UPDATE)
            {
                ReservationDao.Update(model);
                MessageBox.Show("Zmiany zostały zapisane", "Edytowanie rezerwacji");
            }

            Back();
        }

        /// <summary>
        /// Anulowanie formularza
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }

        /// <summary>
        /// Powrót do poprzedniego okna
        /// </summary>
        private void Back()
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            UserControl uc = new Restaurateur.Reservations();
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}
