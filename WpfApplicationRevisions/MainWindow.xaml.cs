using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplicationRevisions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Test de dataBinding en créant une perosnne avec un nom
        public Person CurrentPerson { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            CurrentPerson = new Person { Name = "Alice" };
            DataContext = CurrentPerson; // Création du DataContext

            pnlMainGrid.MouseDown += new MouseButtonEventHandler(pnlMainGrid_MouseDown);


            /* Use of CultureInfo for date, time and number formating */
            tryCultureInfo();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE"); //Forces everything to be as the chosen culture, except if precised otherwise
        }

        private void tryCultureInfo()
        {
            double largeNumber = 123456789.42;
            CultureInfo us = new CultureInfo("en-US");

            largeNumberValue.Content = largeNumber.ToString("N2",us); 


        }

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString(),"Event Called");
            pnlMainGrid.Background = Brushes.ForestGreen;
        }

        private void pnlMainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //cbxResources.Items.Add(pnlMainGrid.FindResource("strHello").ToString());
            pnlMainGrid.Background = Brushes.Red;
        }

        private void OpenWindow_Click(object sender, RoutedEventArgs e)
        {
            LanguageSelection window = new LanguageSelection();

            window.Show();
            this.Hide();
        }

        protected void OnClose_MainWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Application.Current.Shutdown();
        }
    }

}