using System.Windows;
using System.Windows.Controls;
using Restaurateur.DAO;
using Restaurateur.Models;

namespace Restaurateur
{
    /// <summary>
    /// Klasa obsługująca widok magazynu
    /// </summary>
    public partial class Warehouse : UserControl
    {
        public Warehouse()
        {
            InitializeComponent();

            RefreshGrid();
        }

        /// <summary>
        /// Obsługa przycisku usuwania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            WarehouseDao.Delete((long)(sender as Button).Tag);
            RefreshGrid();
        }

        /// <summary>
        /// Odświeżanie danych
        /// </summary>
        private void RefreshGrid()
        {
            WarehouseDataGrid.ItemsSource = WarehouseDao.LoadAll();
        }

        /// <summary>
        /// Obsługa dodawania danych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            UserControl uc = new Forms.Warehouse
            {
                DataContext = new WarehouseModel()
            };
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }

        /// <summary>
        /// Obsługa edycji danych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            UserControl uc = new Forms.Warehouse();
            WarehouseModel model = WarehouseDao.LoadById((long)(sender as Button).Tag);
            model.Mode = "update";
            uc.DataContext = model;
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}
