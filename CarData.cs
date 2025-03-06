using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace driveCom
{
    public class Car
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string Year { get; set; }
        public string Price { get; set; }
        public string Mileage { get; set; }
        public string ImageSource { get; set; }
    }

    public static class CarData
    {
       
        public static ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();
    }

}
