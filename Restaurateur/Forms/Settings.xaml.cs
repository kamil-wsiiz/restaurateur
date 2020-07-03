using Restaurateur.DAO;
using Restaurateur.Models;
using System.Windows;
using System.Windows.Controls;

namespace Restaurateur.Forms
{
    /// <summary>
    /// Klasa obsługująca formularz dodawania i edycji stolików
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string idValue = InputId.Text;
            int id = int.Parse(idValue);
            string name = InputName.Text;
            string mode = (sender as Button).Tag.ToString();

            if (mode == TableModel.UPDATE && TableDao.LoadById(id) != null)
            {
                MessageBox.Show("Ten numer stolika jest już zajęty", "Dodawanie stolika");
                return;
            }

            TableModel model = new TableModel
            {
                Id = id,
                Name = name
            };

            if (mode == TableModel.INSERT)
            {
                TableDao.Insert(model);
                MessageBox.Show("Stolik został dodany", "Dodawanie stolika");
            }
            else if (mode == TableModel.UPDATE)
            {
                TableDao.Update(model);
                MessageBox.Show("Zmiany zostały zapisane", "Edycja stolika");
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
            UserControl uc = new Restaurateur.Settings();
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}
