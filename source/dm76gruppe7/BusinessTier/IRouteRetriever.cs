using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
    interface IRouteRetriever
    {
        List<Route> AllRoutes();
        Route GetRoute(int id);
        List<Route> GetCustomerRoutes(Customer Customer);
    }
}
