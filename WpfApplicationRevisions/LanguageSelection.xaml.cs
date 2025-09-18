using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Windows;
using System.Windows.Controls;

namespace WpfApplicationRevisions
{
    /// <summary>
    /// Logique d'interaction pour LanguageSelection.xaml
    /// </summary>
    public partial class LanguageSelection : Window
    {
        public LanguageSelection()
        {
            InitializeComponent();
        }



        private void SwitchLanguageButton_Click(object sender, RoutedEventArgs e)
        {

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo((sender as Button).Tag.ToString());

            Refresh();
        }

        private void Refresh()
        {
            lblDate.Content = DateTime.Now.ToString();

            lblNumber.Content = (123456789.42d).ToString("N2");
            }


        protected void OnClose(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
            //Do whatever you want here.

            MainWindow window = new MainWindow();
            window.Show();
        }

    }
}
