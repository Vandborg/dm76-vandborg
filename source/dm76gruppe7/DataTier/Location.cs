using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataTier
{
    [KnownType(typeof(Battery))]
    [DataContract(IsReference = true)]
    [Serializable]
    public class Location
    {
        [DataMember]
        virtual public int _id { get; set; }
        [DataMember]
        public string _street { get; set; }
        [DataMember]
        public string _streetNo { get; set; }
        [DataMember]
        public int _zipCode { get; set; }
        [DataMember] //Design error, but too late in the proccess to do anything about it.
        List<Battery> _batteries = new List<Battery>();

        public Location()
        {
            _id = -1;
            _street = null;
            _streetNo = null;
            _zipCode = -1;
        }

        public Location(string street, string streetNo, int zipCode)
        {
            _id = -1;
            _street = street;
            _streetNo = streetNo;
            _zipCode = zipCode;
        }

        public Location(int id, string street, string streetNo, int zipCode)
        {
            _id = id;
            _street = street;
            _streetNo = streetNo;
            _zipCode = zipCode;
        }

        //Design error, but too late in the proccess to do anything about it.
        [DataMember]
        public List<Battery> Batteries
        {
            get { return _batteries; }
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
