using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class PartRoute
    {
        public int _id { get; set; }
        public DateTime _pickUpTime { get; set; }
        public Battery _battery { get; set; }
        public Route _route { get; private set; }

        public PartRoute()
        {
            _id = -1;
            _pickUpTime = DateTime.MinValue;
            _battery = null;
            _route = null;
        }

        public PartRoute(DateTime pickUpTime, Battery battery, Route route)
        {
            _id = -1;
            _pickUpTime = pickUpTime;
            _battery = battery;
            _route = route;
        }

        public PartRoute(int id, DateTime pickUpTime, Battery battery, Route route)
        {
            _id = id;
            _pickUpTime = pickUpTime;
            _battery = battery;
            _route = route;
        }
    }
}
