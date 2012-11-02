using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataTier
{
    [KnownType(typeof(Battery))]
    [KnownType(typeof(Route))]
    [DataContract(IsReference = true)]
    public class PartRoute
    {
        [DataMember]
        public int _id { get; set; }
        [DataMember]
        public DateTime _pickUpTime { get; set; }
        [DataMember]
        public Battery _battery { get; set; }
        [DataMember]
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
