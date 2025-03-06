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


namespace driveCom
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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Car_Click(object sender, RoutedEventArgs e)
        {

            Car_list carlist = new Car_list();
           

            carlist.Show();

            // Close the current window
            this.Close();

        }

        private void News(object sender, RoutedEventArgs e)
        {
            news news = new news();
            news.Show();
            this.Close();

        }

        private void admin_d(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();

        }
    }
}