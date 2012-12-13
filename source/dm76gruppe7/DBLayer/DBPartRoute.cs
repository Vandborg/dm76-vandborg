using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DBLayer
{
    public class DBPartRoute : DBConnection<PartRoute>, IDBPartRoute
    {

        public List<PartRoute> getAllPartRoutes()
        {
            throw new NotImplementedException();
        }

        public PartRoute searchPartRouteID(int id)
        {
            throw new NotImplementedException();
        }

        public bool updatePartRoute(PartRoute PartRoute)
        {
            throw new NotImplementedException();
        }

        public bool createPartRoute(PartRoute PartRoute)
        {
            throw new NotImplementedException();
        }

        public bool deletePartRoute(PartRoute PartRoute)
        {
            throw new NotImplementedException();
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM PartRoute pr, Route r, Battery b, Station s, Location l, Location ll";
            query += " WHERE pr.RouteID = r.ID AND pr.BatteryID = b.ID AND b.StationID = s.ID AND r.StartAddress = l.ID AND r.EndAddress = ll.ID";
            if (wClause.Count() > 0)
                query = query + " AND " + wClause;
            return query;
        }

        public override PartRoute buildObj(SqlDataReader results)
        {
            throw new NotImplementedException();
        }

        public override string updateQuery(int id, string sClause)
        {
            throw new NotImplementedException();
        }

        public override string insertQuery(string values)
        {
            throw new NotImplementedException();
        }

        public override string deleteQuery(string wClause)
        {
            throw new NotImplementedException();
        }
    }
}
