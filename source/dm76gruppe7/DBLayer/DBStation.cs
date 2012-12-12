using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using DataTier;

namespace DBLayer
{
    public class DBStation : DBConnection<Station>, IDBStation
    {
        public List<Station> getAllStations()
        {
            return miscWhere("");
        }

        public Station searchStationID(int id)
        {
            String wClause = "ID = " + id + " ";
            return singleWhere(wClause);
        }

        public bool updateStation(Station Station)
        {
            string sClause = "SET Street='" + Station._street + "'";
            sClause += ", StreetNo='" + Station._streetNo + "'";
            sClause += ", ZipCode=" + Station._zipCode.ToString();
            return update(Station._id, sClause);
        }

        public bool createStation(Station Station)
        {
            string values = "'" + Station._street + "'";
            values += ", '" + Station._streetNo + "'";
            values += ", " + Station._zipCode.ToString();
            return insert(values);
        }

        public bool deleteStation(Station Station)
        {
            string wClause = "ID=" + Station._id;

            return delete(wClause);
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM Station";
            if (wClause.Count() > 0)
                query = query + " WHERE " + wClause;
            return query;
        }

        public override Station buildObj(SqlDataReader results)
        {
            Station addObj = new Station();
            try
            {
                addObj = new Station(Convert.ToInt32(results[0].ToString()),results[1].ToString(),results[2].ToString(),Convert.ToInt32(results[3].ToString()));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in building station Object: " + e.ToString());
            }

            return addObj;
        }

        public override string updateQuery(int id, string sClause)
        {
            string query = "UPDATE Station ";
            query += sClause;
            query += " WHERE ID=" + id.ToString();
            return query;
        }

        public override string insertQuery(string values)
        {
            String query = "INSERT INTO Station (Street, StreetNo, ZipCode) values (" + values + ")";
            Debug.WriteLine(query);
            return query;
        }

        public override string deleteQuery(string wClause)
        {
            String query = "DELETE FROM Station WHERE ";
            query += wClause;
            return query;
        }
    }
}
