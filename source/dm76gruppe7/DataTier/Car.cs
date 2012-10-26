using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class Car
    {
        public int _id { get; set; }
        public string _licensPlate { get; private set; }
        public int _range { get; set; } //this in in meters
        public Customer _customer { get; private set; }
        public Battery _battery { get; set; }

        public Car()
        {
            _id = -1;
            _licensPlate = null;
            _range = -1;
            _customer = null;
            _battery = null;
        }

        public Car(string licensPlate, int range, Customer customer, Battery battery)
        {
            _id = -1;
            _licensPlate = licensPlate;
            _range = range;
            _customer = customer;
            _battery = battery;
        }

        public Car(int id, string licensPlate, int range, Customer customer, Battery battery)
        {
            _id = id;
            _licensPlate = licensPlate;
            _range = range;
            _customer = customer;
            _battery = battery;
        }
    }
}
