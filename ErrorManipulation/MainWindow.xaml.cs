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

namespace ErrorManipulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    


    private void Button_Click(object sender, RoutedEventArgs e)
        {
            String s = null;

            try
            {
                s.Trim();
            } catch (Exception ex) {
                MessageBox.Show("A controlled exception happend : " + ex.Message, "Exemption occured", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            s.Trim();
        }
    }


    public partial class App : Application
    {

        private void overthrowException(object sender , System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("A Non controlled exception happend : " + e.Exception.Message, "Exemption occured", MessageBoxButton.OK, MessageBoxImage.Error);

            e.Handled = true;
        }
    }
}