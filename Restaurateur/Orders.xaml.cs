using Restaurateur.DAO;
using Restaurateur.Models;
using System.Windows;
using System.Windows.Controls;

namespace Restaurateur
{
    /// <summary>
    /// Klasa obsługująca widok zamówień
    /// </summary>
    public partial class Orders : UserControl
    {
        public Orders()
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
            long id = (long)(sender as Button).Tag;
            OrderModel model = OrderDao.LoadById(id);
            WarehouseModel product = WarehouseDao.LoadById(model.ProductId);
            product.Amount += model.Amount; // Przywrócenie produktu do magazynu
            WarehouseDao.Update(product);
            OrderDao.Delete(id);

            RefreshGrid();
        }

        /// <summary>
        /// Odświezanie danych
        /// </summary>
        private void RefreshGrid()
        {
            OrdersDataGrid.ItemsSource = OrderDao.LoadAll();
        }

        /// <summary>
        /// Obsługa przycisku dodawania
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            UserControl uc = new Forms.Orders
            {
                DataContext = new OrderModel()
            };
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }

        /// <summary>
        /// Obsługa przycisku edycji
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            UserControl uc = new Forms.Orders();
            OrderModel model = OrderDao.LoadById((long)(sender as Button).Tag);
            model.Mode = "update";
            uc.DataContext = model;
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}