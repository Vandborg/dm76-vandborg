using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DBLayer
{
    public class DBLocation : DBConnection<Location>, IDBLocation
    {
        public List<Location> getAllLocations()
        {
            return miscWhere("");
        }

        public Location searchLocationID(int id)
        {
            String wClause = "ID=" + id;
            return singleWhere(wClause);
        }

        public bool updateLocation(Location Location)
        {
            string sClause = "SET Street='" + Location._street + "'";
            sClause += ", StreetNo='" + Location._streetNo + "'";
            sClause += ", ZipCode=" + Location._zipCode.ToString();
            return update(Location._id, sClause);
        }

        public bool createLocation(Location Location)
        {
            string values = "'" + Location._street + "'";
            values += ", '" + Location._streetNo + "'";
            values += ", " + Location._zipCode.ToString();
            return insert(values);
        }

        public bool deleteLocation(Location Location)
        {
            string wClause = "ID=" + Location._id;

            return delete(wClause);
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM Location";
            if (wClause.Count() > 0)
                query = query + " WHERE " + wClause;
            return query;
        }

        public override Location buildObj(SqlDataReader results)
        {
            Location addObj = new Location();
            try
            {
                addObj = new Location(Convert.ToInt32(results[0].ToString()),results[1].ToString(),results[2].ToString(),Convert.ToInt32(results[3].ToString()));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in building location Object: " + e.ToString());
            }

            return addObj;
        }

        public override string updateQuery(int id, string sClause)
        {
            string query = "UPDATE Location ";
            query += sClause;
            query += " WHERE ID=" + id.ToString();
            return query;
        }

        public override string insertQuery(string values)
        {
            String query = "INSERT INTO Location (Street, StreetNo, ZipCode) values (" + values + ")";
            Debug.WriteLine(query);
            return query;
        }

        public override string deleteQuery(string wClause)
        {
            String query = "DELETE FROM Location WHERE ";
            query += wClause;
            return query;
        }
    }
}
