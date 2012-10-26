using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class Route
    {
        int _id;
        DateTime _startDate;
        DateTime _endDate;
        Node _startAddress;
        Node _endAddress;
        Customer _customer;
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

        public Route(DateTime startDate, DateTime endDate, Node startAddress, Node endAddress, Customer customer)
        {
            _id = -1;
            _startDate = startDate;
            _endDate = endDate;
            _startAddress = startAddress;
            _endAddress = endAddress;
            _customer = customer;
        }

        public Route(int id, DateTime startDate, DateTime endDate, Node startAddress, Node endAddress, Customer customer)
        {
            _id = id;
            _startDate = startDate;
            _endDate = endDate;
            _startAddress = startAddress;
            _endAddress = endAddress;
            _customer = customer;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public Node StartAddress
        {
            get { return _startAddress; }
            set { _startAddress = value; }
        }

        public Node EndAddress
        {
            get { return _endAddress; }
            set { _endAddress = value; }
        }

        public Customer Customer
        {
            get { return _customer; }
            private set { _customer = value; }
        }

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
