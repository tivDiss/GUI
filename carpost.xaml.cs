using System.Windows;
using System.Windows.Controls;

namespace driveCom
{
    public partial class carpost : UserControl
    {
        public carpost()
        {
            InitializeComponent();
        }

        // CarName Property
        public static readonly DependencyProperty CarNameProperty =
            DependencyProperty.Register("CarName", typeof(string), typeof(carpost), new PropertyMetadata("Car Name"));

        public string CarName
        {
            get { return (string)GetValue(CarNameProperty); }
            set { SetValue(CarNameProperty, value); }
        }

        // Year Property
        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(string), typeof(carpost), new PropertyMetadata("Year"));

        public string Year
        {
            get { return (string)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }

        // Price Property
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(string), typeof(carpost), new PropertyMetadata("Price"));

        public string Price
        {
            get { return (string)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
        //Mileage Property
        public static readonly DependencyProperty MileageProperty =
            DependencyProperty.Register("Mileage", typeof(string), typeof(carpost), new PropertyMetadata("Mileage"));
        public string Mileage
        {
            get { return (string)GetValue(MileageProperty); }
            set { SetValue(MileageProperty, value); }

        }


        // ImageSource Property
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(carpost), new PropertyMetadata("/Images/image_1.jpg"));

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        private void EnquireNow(object sender, RoutedEventArgs e)
        {
            Customer_Details customer = new Customer_Details();

            if (customer.ShowDialog() == true)
            {
                customerData? newCustomer = customer.GetCustomerDetailsIfValid();

                if (newCustomer != null)
                {
                    // Manually set the CarName before saving
                    newCustomer.CarName = CarName;  // Replace with the actual car name

                    using (var db = new AppDBcontext2())
                    {
                        db.customerDatas.Add(newCustomer);
                        db.SaveChanges();
                    }

                    MessageBox.Show("Customer details saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
