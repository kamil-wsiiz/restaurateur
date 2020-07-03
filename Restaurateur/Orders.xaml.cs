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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            OrderDao.Delete((long)(sender as Button).Tag);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            OrdersDataGrid.ItemsSource = OrderDao.LoadAll();
        }

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