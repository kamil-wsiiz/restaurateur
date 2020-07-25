using System.Windows;
using System.Windows.Controls;

namespace Restaurateur
{
    /// <summary>
    /// Klasa obsługująca domyślne okno aplikacji, w tym menu
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Aktualna kontrolka
        /// </summary>
        UserControl uc = null;

        /// <summary>
        /// Konstruktor wywołujący domyślne ustawienia menu
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Otwieranie menu
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Zamykanie menu
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Obsługa menu
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem item = (ListViewItem)((ListView)sender).SelectedItem;

            if (item != null) {
                item.Focus();

                GridMain.Children.Clear();

                switch (item.Name)
                {
                    case "ItemReservations":
                        uc = new Reservations();
                        GridMain.Children.Add(uc);
                        break;

                    case "ItemOrders":
                        uc = new Orders();
                        GridMain.Children.Add(uc);
                        break;

                    case "ItemWarehouse":
                        uc = new Warehouse();
                        GridMain.Children.Add(uc);
                        break;

                    case "ItemSettings":
                        uc = new Settings();
                        GridMain.Children.Add(uc);
                        break;

                    default:
                        break;
                }
            }
            }


    }
}
