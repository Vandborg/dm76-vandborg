using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace DBLayer
{
    public interface IDBPartRoute
    {
        List<PartRoute> getAllPartRoutes();
        PartRoute searchPartRouteID(int id);
        Boolean updatePartRoute(PartRoute PartRoute);
        Boolean createPartRoute(PartRoute PartRoute);
        Boolean deletePartRoute(PartRoute PartRoute);
    }
}
