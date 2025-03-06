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
    /// Interaction logic for Customer_Details.xaml
    /// </summary>
    public partial class Customer_Details : Window
    {
        public Customer_Details()
        {
            InitializeComponent();
        }
        public customerData? GetCustomerDetailsIfValid()
        {
            if (string.IsNullOrWhiteSpace(txtCname.Text) ||
                string.IsNullOrWhiteSpace(txtMno.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtcom.Text) 
                )
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

            return new customerData
            {
                customerName = txtCname.Text,
                mobileNo = txtMno.Text,
                Email = txtEmail.Text,
                comments = txtcom.Text
            };
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            customerData? newCustomer = GetCustomerDetailsIfValid();

            if (newCustomer != null)
            {

               

                MessageBox.Show("Your data added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;



            }
            else
            {
                DialogResult = false;
            }
        }
    }
}
