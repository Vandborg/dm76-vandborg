using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataTier
{
    [KnownType(typeof(PartRoute))]
    [KnownType(typeof(Station))]
    [KnownType(typeof(Car))]
    [DataContract(IsReference= true)]
    [Serializable]
    public class Battery
    {
        public enum Status { Charging=0,Charged=1,Reserved=2,Booked=3,InCar=4 }
        [DataMember]
        public int _id { get; set; }
        [DataMember]
        public Status _status { get; set; }
        [DataMember]
        public Station _station { get; set; }

        public Battery()
        {
            _id = -1;
            _station = null;
        }

        public Battery(Status status, Station station)
        {
            _id = -1;
            _status = status;
            _station = station;
        }

        public Battery(int id, Status status, Station station)
        {
            _id = id;
            _status = status;
            _station = station;
        }
    }
}
