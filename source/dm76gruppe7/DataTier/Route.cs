using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataTier
{
    [KnownType(typeof(Node))]
    [KnownType(typeof(Customer))]
    [KnownType(typeof(PartRoute))]
    [DataContract(IsReference = true)]
    public class Route
    {
        [DataMember]
        public int _id { get; private set; }
        [DataMember]
        public DateTime _startDate { get; set; }
        [DataMember]
        public DateTime _endDate { get; set; }
        [DataMember]
        public Location _startAddress { get; set; }
        [DataMember]
        public Location _endAddress { get; set; }
        [DataMember]
        public Customer _customer { get; set; }

        List<PartRoute> _partRoutes = new List<PartRoute>();

        public Route()
        {
            _id = -1;
            _startDate = DateTime.MinValue;
            _endDate = DateTime.MinValue;
            _startAddress = null;
            _endAddress = null;
            _customer = null;
        }

        public Route(DateTime startDate, DateTime endDate, Location startAddress, Location endAddress, Customer customer)
        {
            _id = -1;
            _startDate = startDate;
            _endDate = endDate;
            _startAddress = startAddress;
            _endAddress = endAddress;
            _customer = customer;
        }

        public Route(int id, DateTime startDate, DateTime endDate, Location startAddress, Location endAddress, Customer customer)
        {
            _id = id;
            _startDate = startDate;
            _endDate = endDate;
            _startAddress = startAddress;
            _endAddress = endAddress;
            _customer = customer;
        }

        [DataMember]
        public List<PartRoute> PartRoute
        {
            get { return _partRoutes; }
        }

        public void AddPartRoute(PartRoute partRoute)
        {
            _partRoutes.Add(partRoute);
        }

        public void RemovePartRoute(PartRoute partRoute)
        {
            _partRoutes.Remove(partRoute);
        }
    }
}
