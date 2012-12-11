using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using DataTier;

namespace DBLayer
{
    public class DBBattery : DBConnection<Battery>, IDBBattery
    {       
        public List<Battery> getAllBatteries()
        {
            return miscWhere("");
        }

        public Battery searchBatteryID(int id)
        {
            String wClause = "b.ID = " + id + " ";
            return singleWhere(wClause);
        }

        public bool updateBattery(Battery battery)
        {
            string sClause = "SET Status="+Convert.ToInt32(battery._status).ToString();
            if(battery._station==null)
                sClause += ", StationID=null";
            else
                sClause += ", StationID=" + battery._station._id;

            return update(battery._id, sClause);
        }

        public bool createBattery(Battery battery)
        {
            string values = Convert.ToInt32(battery._status).ToString()+",";
            if (battery._station == null)
                values += "null";
            else
                values += battery._station._id.ToString();
            return insert(values);
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM Battery b, Station s, Location l";
            query += " WHERE b.ID = s.ID AND s.ID = l.ID";
            if (wClause.Count() > 0)
                query = query + " AND " + wClause;
            return query;
        }

        public override Battery buildObj(SqlDataReader results)
        {
            Battery addObj = new Battery();
            try
            {
                addObj._id = Convert.ToInt32(results[0].ToString());
                addObj._status = (Battery.Status)Convert.ToInt32(results[1].ToString());
                addObj._station = new Station(Convert.ToInt32(results[2].ToString()), 
                                              results[6].ToString(), results[7].ToString(), 
                                              Convert.ToInt32(results[8].ToString()));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in building battery Object: " + e.ToString());
            }

            return addObj;
        }

        public override string updateQuery(int id, string sClause)
        {
            string query = "UPDATE Battery ";
            query += sClause;
            query += " WHERE ID="+id.ToString();
            return query;
        }

        public override string insertQuery(string values)
        {
            //String query = "INSERT INTO Battery (Status, StationID) values ("+values+")";
            String query = "INSERT INTO Battery (Status, StationID) values (1,1)";
            Debug.WriteLine(query);
            return query;
        }
    }
}
