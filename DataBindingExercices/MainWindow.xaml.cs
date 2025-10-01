using DataBindingExercices.CustomControls;
using System.Collections.ObjectModel;
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

namespace DataBindingExercices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public ChienListBox Chiens = new ChienListBox();

        private CalculatorViewModel _viewModel;

        public ICommand Action { get; }
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new CalculatorViewModel();

            this.DataContext = _viewModel;
            //this.DataContext = Chiens.chien; EXO 3

            //MenuData.ItemsSource = new String[] { "_File", "_Edit", "_View", "_Window" }; Template Menu Data
            //MenuData.ItemsSource = Chiens.Chiens;  
        }


        private void Lire_Click(object sender, RoutedEventArgs e)
        {
            //Version pas propre car la Vue ne devrait pas devoir géré ça, surtout qu'elle n'a pas le result en soit
            MessageBox.Show(_viewModel.Number1 + " * " + _viewModel.Number2 + "= " + _viewModel.Number1* _viewModel.Number2, "Resultat static");
            /* Utilisé pour le Multibinding simplifié
            string n1 = Number1.Text;
            string n2 = Number2.Text;
            string resultat = Result.Text;
            */

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Voici les nouvelles valeurs du chien." + "\n" + "Le nom peut changer (TwoWay), mais sa race reste la même (OneWay)", Chiens.chien.Name + " " + Chiens.chien.Race);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dog_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
