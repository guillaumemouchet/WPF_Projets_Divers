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
using System.Windows.Threading;

namespace SimpleDigitalClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            startClock();
        }

        private void startClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private void tickevent(object? sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("HH:MM").ToUpper();
            lblDay.Content = DateTime.Now.ToString("dddd").ToUpper();
            lblDate.Content =DateTime.Now.ToString("MMM dd yyyy").ToUpper();
            lblSecond.Content = DateTime.Now.ToString("ss").ToUpper();

                    }
    }
}