using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace driveCom
{
    /// <summary>
    /// Interaction logic for Car_list.xaml
    /// </summary>
    public partial class Car_list : Window
    {
        

        public Car_list()
        {
            InitializeComponent();
            DataContext = CarData.Cars;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
       

        private void textSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Homebutton_click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();

        }

        private void Search_Button(object sender, RoutedEventArgs e)
        {
            
        }

        private void news(object sender, RoutedEventArgs e)
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

