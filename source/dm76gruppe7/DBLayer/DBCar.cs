using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using DataTier;

namespace DBLayer
{
    public class DBCar : DBConnection<Car>, IDBCar
    {

        public List<Car> getAllCars()
        {
            return miscWhere("");
        }

        public Car searchCarID(int id)
        {
            String wClause = "cr.ID = " + id + " ";
            return singleWhere(wClause);
        }

        public bool updateCar(Car Car)
        {
            string sClause = "SET LicensPlate='"+Car._licensPlate;
            sClause += "', Range="+Car._range.ToString();
            sClause += ", CustomerID=" + Car._customer._id.ToString();

            return update(Car._id,sClause);
        }

        public bool createCar(Car Car)
        {
            string values = "'"+Car._licensPlate+"'";
            values += ", "+Car._range.ToString();
            values += ", " + Car._customer._id.ToString();
            return insert(values);
        }

        public bool deleteCar(Car Car)
        {
            string wClause = "ID=" + Car._id;

            return delete(wClause);
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM Car cr, Customer cstmr";
            query += " WHERE cr.CustomerID = cstmr.ID";
            if (wClause.Count() > 0)
                query = query + " AND " + wClause;
            return query;
        }

        public override Car buildObj(SqlDataReader results)
        {
            Car addObj = new Car();
            try
            {
                addObj = new Car(Convert.ToInt32(results[0].ToString()), 
                                    results[1].ToString(),
                                    Convert.ToInt32(results[2].ToString()),
                                    new Customer(Convert.ToInt32(results[4].ToString()),
                                                    results[5].ToString(),
                                                    results[6].ToString()
                                                 )
                                );
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in building car Object: " + e.ToString());
            }

            return addObj;
        }

        public override string updateQuery(int id, string sClause)
        {
            string query = "UPDATE Car ";
            query += sClause;
            query += " WHERE ID=" + id.ToString();
            return query;
        }

        public override string insertQuery(string values)
        {
            String query = "INSERT INTO Car (LicensPlate, Range, CustomerID) values (" + values + ")";
            Debug.WriteLine(query);
            return query;
        }

        public override string deleteQuery(string wClause)
        {
            String query = "DELETE FROM Car WHERE ";
            query += wClause;
            return query;
        }
    }
}
