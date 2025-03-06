using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for AddNewCar.xaml
    /// </summary>
    public partial class AddNewCar : Window
    {
        public AddNewCar()
        {
            InitializeComponent();
        }

        public Car? GetCarDetailsIfValid()
        {
            if (string.IsNullOrWhiteSpace(txtCarName.Text) ||
                string.IsNullOrWhiteSpace(txtYear.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtMileage.Text) ||
                string.IsNullOrWhiteSpace(txtImageSource.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

            return new Car
            {
                CarName = txtCarName.Text,
                Year = txtYear.Text,
                Price = txtPrice.Text,
                Mileage = txtMileage.Text,
                ImageSource = txtImageSource.Text
            };
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Car? newCar = GetCarDetailsIfValid(); 

            if (newCar != null) 
            {
                
                CarData.Cars.Add(newCar);

                MessageBox.Show("Car added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true; 

                
              
            }
            else
            {
                DialogResult = false; 
            }

        }

        private void txtImageSource_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

