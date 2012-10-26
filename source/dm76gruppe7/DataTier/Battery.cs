using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class Battery
    {
        public int _id { get; set; }
        public string _status { get; set; }
        public PartRoute _partRoute { get; set; }
        Object _belongs; //can be a car or a station.

        public Battery()
        {
            _id = -1;
            _status = null;
            _belongs = null;
            _partRoute = null;
        }

        public Battery(string status, Object belongs, PartRoute partRoute)
        {
            _id = -1;
            _status = status;

            if(belongs is Car || belongs is Station)
            {
                _belongs = belongs;
            }
            else
            {
                _belongs = null;
            }

            _partRoute = partRoute;
        }

        public Battery(int id, string status, Object belongs, PartRoute partRoute)
        {
            _id = -1;
            _status = status;

            if(belongs is Car || belongs is Station)
            {
                _belongs = belongs;
            }
            else
            {
                _belongs = null;
            }

            _partRoute = partRoute;
        }

        public Object Belongs
        {
            get { return _belongs; }
            set 
            { 
                if (value is Car || value is Station)
                {
                    _belongs = value;
                }
                else
                {
                    _belongs = null;
                }
            }
        }
    }
}
