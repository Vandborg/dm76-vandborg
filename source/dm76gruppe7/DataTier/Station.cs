using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class Station
    {
        public int _id { get; set; }
        public Node _address { get; set; }
        List<Battery> _batteries = new List<Battery>();

        public Station()
        {
            _id = -1;
            _address = null;
        }

        public Station(Node address)
        {
            _id = -1;
            _address = address;
        }

        public Station(int id, Node address)
        {
            _id = id;
            _address = address;
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
