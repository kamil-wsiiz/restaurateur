using Restaurateur.DAO;
using Restaurateur.Models;
using System.Windows;
using System.Windows.Controls;

namespace Restaurateur.Forms
{
    /// <summary>
    /// Klasa obsługująca formularz dodawania i edycji rezerwacji
    /// </summary>
    public partial class Orders : UserControl
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            OrderModel model = DataContext as OrderModel;

            if (model.Mode == OrderModel.INSERT)
            {
                OrderDao.Insert(model);
                MessageBox.Show("Zamówienie zostało dodane", "Dodawanie zamówienia");
            }
            else if (model.Mode == OrderModel.UPDATE)
            {
                OrderDao.Update(model);
                MessageBox.Show("Zmiany zostały zapisane", "Edycja zamówienia");
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
            UserControl uc = new Restaurateur.Orders();
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}
