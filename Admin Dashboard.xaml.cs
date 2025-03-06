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
using System.Windows.Threading;

namespace driveCom
{
    /// <summary>
    /// Interaction logic for Admin_Dashboard.xaml
    /// </summary>
    public partial class Admin_Dashboard : Window
    {
        private DispatcherTimer timer;
       

        private int currentImageIndex = 0;
        private DispatcherTimer timer2;
        public Admin_Dashboard()
        {
            InitializeComponent();
            StartClock();
            LoadCarData();
            LoadCustomerData2();
            
        }
        private void StartClock()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Update every second
            timer.Tick += Timer_Tick;
            timer.Start();
        }
     


        private void Timer_Tick(object sender, EventArgs e)
        {
            txtDateTime.Text = DateTime.Now.ToString("HH:mm:ss                                dd-MM-yyyy");
        }
        private void LoadCarData()
        {
            using (var db = new AppDBContext())
            {
                var cars = db.Cars.ToList(); 
                CarDataGrid.ItemsSource = cars; 
            }
        }
        private void LoadCustomerData2()
        {
            using (var db = new AppDBcontext2())
            {
                var customer = db.customerDatas.ToList();
                customerGrid.ItemsSource = customer;
            }
        }

        private void Home(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();

        }

        private void Car_list(object sender, RoutedEventArgs e)
        {
            Car_list carlist = new Car_list();


            carlist.Show();

            // Close the current window
            this.Close();

        }

        private void news(object sender, RoutedEventArgs e)
        {
            news news = new news();
            news.Show();
            this.Close();

        }



        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewCar addNewCar = new AddNewCar();
           

            if (addNewCar.ShowDialog() == true) 
            {
                Car? newCar = addNewCar.GetCarDetailsIfValid(); 

                if (newCar != null) 
                {
                    using (var db = new AppDBContext())
                    {
                        db.Cars.Add(newCar);
                        db.SaveChanges();
                    }

                    LoadCarData(); 
                }
            }
        }
        private void UpdateCar()
        {
            if (CarDataGrid.SelectedItem is Car selectedCar)
            {
                AddNewCar updateCarWindow = new AddNewCar();

                
                updateCarWindow.txtCarName.Text = selectedCar.CarName;
                updateCarWindow.txtYear.Text = selectedCar.Year;
                updateCarWindow.txtPrice.Text = selectedCar.Price;
                updateCarWindow.txtMileage.Text = selectedCar.Mileage;
                updateCarWindow.txtImageSource.Text = selectedCar.ImageSource;

                if (updateCarWindow.ShowDialog() == true)
                {
                    Car? updatedCar = updateCarWindow.GetCarDetailsIfValid();

                    if (updatedCar != null)
                    {
                        using (var db = new AppDBContext())
                        {
                            var carToUpdate = db.Cars.FirstOrDefault(c => c.Id == selectedCar.Id);
                            if (carToUpdate != null)
                            {
                                
                                carToUpdate.CarName = updatedCar.CarName;
                                carToUpdate.Year = updatedCar.Year;
                                carToUpdate.Price = updatedCar.Price;
                                carToUpdate.Mileage = updatedCar.Mileage;
                                carToUpdate.ImageSource = updatedCar.ImageSource;

                                db.SaveChanges();
                            }
                        }

                        LoadCarData(); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a car to update.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void DeleteCar()
        {
            if (CarDataGrid.SelectedItem is Car selectedCar)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {selectedCar.CarName}?",
                    "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var db = new AppDBContext())
                    {
                        var carToDelete = db.Cars.FirstOrDefault(c => c.Id == selectedCar.Id);
                        if (carToDelete != null)
                        {
                            db.Cars.Remove(carToDelete);
                            db.SaveChanges();
                        }
                    }

                    LoadCarData(); 
                }
            }
            else
            {
                MessageBox.Show("Please select a car to delete.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void update(object sender, RoutedEventArgs e)
        {
            UpdateCar();
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            DeleteCar();
        }
    }
}