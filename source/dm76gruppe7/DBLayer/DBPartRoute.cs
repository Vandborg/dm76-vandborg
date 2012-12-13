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
            return miscWhere("");
        }

        public PartRoute searchPartRouteID(int id)
        {
            String wClause = "WHERE pr.ID = " + id + " ";
            return singleWhere(wClause);
        }

        public bool updatePartRoute(PartRoute PartRoute)
        {
            string sClause = "SET PickUptime='" + PartRoute._pickUpTime.ToString("yyyy-MM-dd HH:mm:ss");
            sClause += "', BatteryID=" + PartRoute._battery._id.ToString();
            sClause += ", RouteID=" + PartRoute._route._id.ToString();
            return update(PartRoute._id, sClause);
        }

        public bool createPartRoute(PartRoute PartRoute)
        {
            string values = "'"+ PartRoute._pickUpTime.ToString("yyyy-MM-dd HH:mm:ss");
            values += "', "+PartRoute._battery._id.ToString()+", ";
            values += PartRoute._route._id.ToString();

            return insert(values);
        }

        public bool deletePartRoute(PartRoute PartRoute)
        {
            string wClause = "ID=" + PartRoute._id;

            return delete(wClause);
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM PartRoute pr, Route r, Battery b, Station s, Location l, Location ll, Customer c";
            query += " WHERE pr.RouteID = r.ID AND pr.BatteryID = b.ID AND b.StationID = s.ID AND r.StartAddress = l.ID AND r.EndAddress = ll.ID AND r.CustomerID = c.ID";
            if (wClause.Count() > 0)
                query = query + " AND " + wClause;
            return query;
        }

        public override PartRoute buildObj(SqlDataReader results)
        {
            PartRoute addObj = new PartRoute();
            try
            {
                addObj = new PartRoute(Convert.ToInt32(results[0].ToString()),Convert.ToDateTime(results[1].ToString()),
                                        new Battery(Convert.ToInt32(results[10].ToString()),(Battery.Status)Convert.ToInt32(results[11].ToString()),
                                                    new Station(Convert.ToInt32(results[13].ToString()),results[14].ToString(),results[15].ToString(),Convert.ToInt32(results[16].ToString()))),
                                        new Route(Convert.ToInt32(results[4].ToString()),Convert.ToDateTime(results[6].ToString()),Convert.ToDateTime(results[7].ToString()),
                                                    new Location(Convert.ToInt32(results[17].ToString()),results[18].ToString(),results[19].ToString(),Convert.ToInt32(results[20].ToString())),
                                                    new Location(Convert.ToInt32(results[21].ToString()),results[22].ToString(),results[23].ToString(),Convert.ToInt32(results[24].ToString())),
                                                    new Customer(Convert.ToInt32(results[25].ToString()),results[26].ToString(),results[27].ToString())));

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in building Route Object: " + e.ToString());
            }

            return addObj;
        }

        public override string updateQuery(int id, string sClause)
        {
            string query = "UPDATE PartRoute ";
            query += sClause;
            query += " WHERE ID=" + id.ToString();
            Debug.WriteLine(query);
            return query;
        }

        public override string insertQuery(string values)
        {
            String query = "INSERT INTO PartRoute (PickUptime, BatteryID, RouteID) values (" + values + ")";
            Debug.WriteLine(query);
            return query;
        }

        public override string deleteQuery(string wClause)
        {
            String query = "DELETE FROM PartRoute WHERE ";
            query += wClause;
            return query;
        }
    }
}
