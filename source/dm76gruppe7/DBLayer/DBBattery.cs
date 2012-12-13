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
            String wClause = "WHERE b.ID = " + id + " ";
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

        public bool deleteBattery(Battery battery)
        {
            string wClause = "ID="+battery._id;

            return delete(wClause);
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM Battery b LEFT JOIN Station s";
            query += " ON b.StationID=s.ID ";
            if (wClause.Count() > 0)
                query += wClause;
            Debug.WriteLine(query);
            return query;
        }

        public override Battery buildObj(SqlDataReader results)
        {
            Battery addObj = new Battery();
            try
            {
                addObj._id = Convert.ToInt32(results[0].ToString());
                addObj._status = (Battery.Status)Convert.ToInt32(results[1].ToString());
                if(results[2].ToString()=="null")
                {
                    addObj._station = null;
                }
                else
                {
                    addObj._station = new Station(Convert.ToInt32(results[3].ToString()), 
                                                results[4].ToString(), results[5].ToString(), 
                                                Convert.ToInt32(results[6].ToString()));
                }
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
            String query = "INSERT INTO Battery (Status, StationID) values ("+values+")";
            return query;
        }

        public override string deleteQuery(string wClause)
        {
            String query = "DELETE FROM Battery WHERE ";
            query += wClause;
            return query;
        }
    }
}
