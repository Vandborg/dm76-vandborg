using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DBLayer
{
    public class DBCustomer : DBConnection<Customer>, IDBCustomer
    {
        public List<Customer> getAllCustomers()
        {
            return miscWhere("");
        }

        public Customer searchCustomerID(int id)
        {
            String wClause = "ID="+id;
            return singleWhere(wClause);
        }

        public bool updateCustomer(Customer Customer)
        {
            string sClause = "SET Name='"+Customer._name+"'";
            sClause += ", Email='"+Customer._email+"'";
            return update(Customer._id, sClause);
        }

        public bool createCustomer(Customer Customer)
        {
            string values = "'" + Customer._name + "'";
            values += ", '" + Customer._email + "'";
            return insert(values);
        }

        public bool deleteCustomer(Customer Customer)
        {
            string wClause = "ID=" + Customer._id;

            return delete(wClause);
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM Customer";
            if (wClause.Count() > 0)
                query = query + " WHERE " + wClause;
            return query;
        }

        public override Customer buildObj(SqlDataReader results)
        {
            Customer addObj = new Customer();
            try
            {
                addObj = new Customer(Convert.ToInt32(results[0].ToString()),results[1].ToString(),results[2].ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in building customer Object: " + e.ToString());
            }

            return addObj;
        }

        public override string updateQuery(int id, string sClause)
        {
            string query = "UPDATE Customer ";
            query += sClause;
            query += " WHERE ID=" + id.ToString();
            return query;
        }

        public override string insertQuery(string values)
        {
            String query = "INSERT INTO Customer (Name, Email) values (" + values + ")";
            Debug.WriteLine(query);
            return query;
        }

        public override string deleteQuery(string wClause)
        {
            String query = "DELETE FROM Customer WHERE ";
            query += wClause;
            return query;
        }
    }
}
