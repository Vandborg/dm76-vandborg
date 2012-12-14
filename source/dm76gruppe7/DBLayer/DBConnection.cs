using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DBLayer
{
    abstract public class DBConnection<T>
    {
        public abstract string buildQuery(String wClause);
        public abstract T buildObj(SqlDataReader results);
        public abstract string updateQuery(int id, string sClause);
        public abstract string insertQuery(string values);
        public abstract string deleteQuery(string wClause);

        public SqlConnection connection = new SqlConnection("user id=dm76_7;" +
                                       "password=MaaGodt;server=balder.ucn.dk;" +
                                       "Trusted_Connection=no;" +
                                       "database=dm76_7; " +
                                       "connection timeout=30");

        public List<T> miscWhere(String wClause)
        {
            List<T> objResults = new List<T>();
            String query = buildQuery(wClause);
            try
            {
                connection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(query, connection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    T addObj = buildObj(myReader);
                    objResults.Add(addObj);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            return objResults;
        }

        public T singleWhere(String wClause)
        {
            T objResult = Activator.CreateInstance<T>();
            String query = buildQuery(wClause);
            
            try
            {
                connection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(query, connection);
                myReader = myCommand.ExecuteReader();
                if(myReader.Read())
                {
                   objResult = buildObj(myReader);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            return objResult;
        }

        public Boolean update(int id, string sClause)
        {
            String query = updateQuery(id, sClause);
            try
            {
                connection.Open();
                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }

            return true;
        }

        public Boolean insert(string values)
        {
            string query = insertQuery(values);
            try
            {
                connection.Open();
                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public Boolean delete(string wClause)
        {
            string query = deleteQuery(wClause);
            try
            {
                connection.Open();
                SqlCommand myCommand = new SqlCommand(query, connection);
                myCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
            return true;
        }
    }
}
