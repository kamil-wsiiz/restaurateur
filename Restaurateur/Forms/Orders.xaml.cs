using Restaurateur.DAO;
using Restaurateur.Models;
using System.Windows;
using System.Windows.Controls;

namespace Restaurateur.Forms
{
    /// <summary>
    /// Klasa obsługująca formularz dodawania i edycji zamówień
    /// </summary>
    public partial class Orders : UserControl
    {
        public Orders()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Wysłanie formularza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // Pobranie modelu z formularza
            OrderModel model = DataContext as OrderModel;

            // Sprawdzenie czy produkt jest w magazynie
            WarehouseModel product = WarehouseDao.LoadById(model.ProductId);
            if (product.Amount < model.Amount)
            {
                MessageBox.Show("Niewystarczająca ilość produktu na magazynie", "Błąd");
                return;
            }

            if (model.Mode == OrderModel.INSERT)
            {
                OrderDao.Insert(model);
                MessageBox.Show("Zamówienie zostało dodane", "Dodawanie zamówienia");
            }
            else if (model.Mode == OrderModel.UPDATE)
            {
                // Przywrócenie poprzedniej ilości do magazynu
                product.Amount += OrderDao.LoadById(model.Id).Amount;
                OrderDao.Update(model);
                MessageBox.Show("Zmiany zostały zapisane", "Edycja zamówienia");
            }

            // Usunięcie produktu z magazynu
            product.Amount -= model.Amount;
            WarehouseDao.Update(product);

            Back();
        }

        /// <summary>
        /// Anulowanie fomularza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            UserControl uc = new Restaurateur.Orders();
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}
