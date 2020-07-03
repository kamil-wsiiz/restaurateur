using Restaurateur.DAO;
using Restaurateur.Models;
using System.Windows;
using System.Windows.Controls;

namespace Restaurateur.Forms
{
    /// <summary>
    /// Klasa obsługująca formularz magazynu
    /// </summary>
    public partial class Warehouse : UserControl
    {
        public Warehouse()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            WarehouseModel model = DataContext as WarehouseModel;

            if (model.Mode == TableModel.INSERT)
            {
                WarehouseDao.Insert(model);
                MessageBox.Show("Produkt został dodany", "Dodawanie produktu");
            }
            else if (model.Mode == TableModel.UPDATE)
            {
                WarehouseDao.Update(model);
                MessageBox.Show("Zmiany zostały zapisane", "Edycja produktu");
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
            UserControl uc = new Restaurateur.Warehouse();
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}
