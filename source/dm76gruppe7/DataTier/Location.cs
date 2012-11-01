using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public abstract class Location
    {
        public string _street { get; set; }
        public string _streetNo { get; set; }
        public int _zipCode { get; set; }

        public Location()
        {
            _street = null;
            _streetNo = null;
            _zipCode = -1;
        }

        public Location(string street, string streetNo, int zipCode)
        {
            _street = street;
            _streetNo = streetNo;
            _zipCode = zipCode;
        }

        public Location(int id, string street, string streetNo, int zipCode)
        {
            _street = street;
            _streetNo = streetNo;
            _zipCode = zipCode;
        }
    }
}
