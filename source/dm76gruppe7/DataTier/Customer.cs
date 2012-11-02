using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataTier
{
    [KnownType(typeof(Route))]
    [KnownType(typeof(Car))]
    [DataContract(IsReference = true)]
    public class Customer
    {
        [DataMember]
        public int _id { get; set; }
        [DataMember]
        public string _name { get; set; }
        [DataMember]
        public string _email { get; set; }

        List<Route> _routes = new List<Route>();
        List<Car> _cars = new List<Car>();

        public Customer()
        {
            _id = -1;
            _name = null;
            _email = null;
        }

        public Customer(string name, string email)
        {
            _id = -1;
            _name = name;
            _email = email;
        }

        public Customer(int id, string name, string email)
        {
            _id = id;
            _name = name;
            _email = email;
        }

        [DataMember]
        public List<Route> Routes
        {
            get { return _routes; }
        }

        [DataMember]
        public List<Car> Cars
        {
            get { return _cars; }
        }

        public void AddRoute(Route route)
        {
            _routes.Add(route);
        }

        public void RemoveRoute(int id)
        {
            Route result = _routes.Find(
                        delegate(Route route)
                        {
                            return route._id == id;
                        });
            _routes.Remove(result);
        }

        public void RemoveRoute(Route route)
        {
            _routes.Remove(route);
        }

        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public void RemoveCar(int id)
        {
            Car result = _cars.Find(
                        delegate(Car car)
                        {
                            return car._id == id;
                        });
            _cars.Remove(result);
        }

        public void RemoveCar(Car car)
        {
            _cars.Remove(car);
        }
    }
}
