using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataTier
{
    [KnownType(typeof(Customer))]
    [KnownType(typeof(Battery))]
    [DataContract(IsReference=true)]
    public class Car
    {
        [DataMember]
        public int _id { get; set; }
        [DataMember]
        public string _licensPlate { get; private set; }
        [DataMember]
        public int _range { get; set; } //this in in meters
        [DataMember]
        public Customer _customer { get; private set; }
        [DataMember]
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
