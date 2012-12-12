using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace DBLayer
{
    public interface IDBRoute
    {
        List<Route> getAllRoutes();
        Route searchRouteID(int id);
        Boolean updateRoute(Route Route);
        Boolean createRoute(Route Route);
        Boolean deleteRoute(Route Route);
    }
}
