using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class Station : Location
    {
        public int _id { get; set; }
        
        List<Battery> _batteries = new List<Battery>();

        public Station()
        {
            _id = -1;
            _street = null;
            _streetNo = null;
            _zipCode = -1;
        }

        public Station(string street, string streetNo, int zipCode)
        {
            _id = -1;
            _street = street;
            _streetNo = streetNo;
            _zipCode = zipCode;
        }

        public Station(int id, string street, string streetNo, int zipCode)
        {
            _id = id;
            _street = street;
            _streetNo = streetNo;
            _zipCode = zipCode;
        }

        public void AddBattery(Battery battery)
        {
            _batteries.Add(battery);
        }

        public void RemoveBattery(int id)
        {
            Battery result = _batteries.Find(
                        delegate(Battery battery)
                        {
                            return battery._id == id;
                        });
            _batteries.Remove(result);
        }

        public void RemoveBattery(Battery battery)
        {
            _batteries.Remove(battery);
        }
    }
}
