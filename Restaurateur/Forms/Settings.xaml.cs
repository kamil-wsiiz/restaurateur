﻿using Restaurateur.DAO;
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

        /// <summary>
        ///  Wysłanie formularza
        /// </summary>
        /// <param name="sender">Obiekt wywołujący zdarzenie</param>
        /// <param name="e">Obiekt zawierający parametry zdarzenia</param>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // Pobranie modelu z formularza
            TableModel model = DataContext as TableModel;

            if (model.Mode == TableModel.UPDATE && TableDao.LoadById(model.Id) != null)
            {
                MessageBox.Show("Ten numer stolika jest już zajęty", "Dodawanie stolika");
                return;
            }

            if (model.Mode == TableModel.INSERT)
            {
                TableDao.Insert(model);
                MessageBox.Show("Stolik został dodany", "Dodawanie stolika");
            }
            else if (model.Mode == TableModel.UPDATE)
            {
                TableDao.Update(model);
                MessageBox.Show("Zmiany zostały zapisane", "Edycja stolika");
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
            UserControl uc = new Restaurateur.Settings();
            window.GridMain.Children.Clear();
            window.GridMain.Children.Add(uc);
        }
    }
}
