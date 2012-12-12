using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using DataTier;

namespace DBLayer
{
    public class DBRoute : DBConnection<Route>, IDBRoute
    {
        public List<Route> getAllRoutes()
        {
            return miscWhere("");
        }

        public Route searchRouteID(int id)
        {
            String wClause = "r.ID = " + id + " ";
            return singleWhere(wClause);
        }

        public bool updateRoute(Route Route)
        {
            string sClause = "SET CustomerID=" + Convert.ToInt32(Route._customer._id).ToString();
            sClause += ", StartDate='" + Route._startDate.ToString();
            sClause += "', EndDate="+Route._endDate.ToString();
            sClause += "', StartAddress="+Route._startAddress._id.ToString();
            sClause += ", EndAddress="+Route._endAddress._id.ToString();

            return update(Route._id, sClause);
        }

        public bool createRoute(Route Route)
        {
            string values = Route._customer._id.ToString();
            values += ", '"+Route._startDate.ToString()+"', '";
            values += Route._endDate.ToString() + "', ";
            values += Route._startAddress._id.ToString() + ", ";
            values += Route._endAddress._id.ToString();
            
            return insert(values);
        }

        public bool deleteRoute(Route Route)
        {
            string wClause = "ID=" + Route._id;

            return delete(wClause);
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM Route r, Customer c, Location l, Location ll";
            query += " WHERE r.CustomerID = c.ID AND r.StartAddress=l.ID AND r.EndAddress=ll.ID";
            if (wClause.Count() > 0)
                query = query + " AND " + wClause;
            return query;
        }

        public override Route buildObj(SqlDataReader results)
        {
            Route addObj = new Route();
            try
            {
                addObj = new Route(Convert.ToInt32(results[0].ToString()),Convert.ToDateTime(results[2].ToString()),Convert.ToDateTime(results[3].ToString()),
                                    new Location(Convert.ToInt32(results[9].ToString()),results[10].ToString(),results[11].ToString(),Convert.ToInt32(results[12].ToString())),
                                    new Location(Convert.ToInt32(results[13].ToString()), results[14].ToString(), results[15].ToString(), Convert.ToInt32(results[16].ToString())),
                                    new Customer(Convert.ToInt32(results[6].ToString()),results[7].ToString(),results[8].ToString()));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in building Route Object: " + e.ToString());
            }

            return addObj;
        }

        public override string updateQuery(int id, string sClause)
        {
            string query = "UPDATE Route ";
            query += sClause;
            query += " WHERE ID=" + id.ToString();
            return query;
        }

        public override string insertQuery(string values)
        {
            String query = "INSERT INTO Route (CustomerID, StartDate, EndDate, StartAddress, EndAddress) values (" + values + ")";
            return query;
        }

        public override string deleteQuery(string wClause)
        {
            String query = "DELETE FROM Route WHERE ";
            query += wClause;
            return query;
        }
    }
}
