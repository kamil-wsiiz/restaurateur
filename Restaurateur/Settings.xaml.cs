using System.Windows;
using System.Windows.Controls;
using Restaurateur.DAO;
using Restaurateur.Models;

namespace Restaurateur
{
    /// <summary>
    /// Klasa obsługująca widok ustawień
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
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
            TableDao.Delete((long)(sender as Button).Tag);
            RefreshGrid();
        }

        /// <summary>
        /// Odświeżanie danych
        /// </summary>
        private void RefreshGrid()
        {
            TablesDataGrid.ItemsSource = TableDao.LoadAll();
        }

        /// <summary>
        /// Obsługa przycisku dodawania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            UserControl uc = new Forms.Settings
            {
                DataContext = new TableModel()
            };
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }

        /// <summary>
        /// Obsługa przycisku edycji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            UserControl uc = new Forms.Settings();
            TableModel model = TableDao.LoadById((long)(sender as Button).Tag);
            model.Mode = "update";
            uc.DataContext = model;
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}
