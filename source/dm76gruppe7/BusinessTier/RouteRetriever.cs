using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
    public class RouteRetriever : IRouteRetriever
    {
        List<Route> _routes = new List<Route>();
        
        public List<Route> AllRoutes()
        {
            return _routes;
        }

        public Route GetRoute(int id)
        {
            Route result = _routes.Find(
                        delegate(Route route)
                        {
                            return route.Id == id;
                        });
            return result;
        }

        public List<Route> GetCustomerRoutes(Customer Customer)
        {
            List<Route> results = _routes.FindAll(
                         delegate(Route route)
                         {
                             return route.Customer._id == Customer._id;
                         });
            return results;
                          
        }
    }
}
