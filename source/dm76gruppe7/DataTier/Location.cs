using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataTier
{
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
    }
}
