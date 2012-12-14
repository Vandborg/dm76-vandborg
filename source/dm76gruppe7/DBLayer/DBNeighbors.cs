using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using DataTier;

namespace DBLayer
{
    public class DBNeighbors : DBConnection<int>, IDBNeighbors
    {

        public List<List<int>> getAllNeighbors(Node FromNode)
        {
            List<List<int>> results = new List<List<int>>();
            string wClause = "FromNodeID=" + FromNode.Id.ToString();
            results.Add(miscWhere(wClause));
            results.Add(getAllCosts(wClause));
            return results;
        }

        //Hackish
        public List<int> getAllCosts(string wClause)
        {
            List<int> objResults = new List<int>();
            String query = buildQuery(wClause);
            try
            {
                connection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(query, connection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    int addObj = buildCost(myReader);
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

        public bool updateNeighbors(List<Node> Neighbors, List<int> Costs)
        {
            throw new NotImplementedException();
        }

        public bool createNeighbors(List<Node> Neighbors, List<int> Costs)
        {
            throw new NotImplementedException();
        }

        public bool deleteNeighbors(List<Node> Neighbors, List<int> Costs)
        {
            throw new NotImplementedException();
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM Neighbors";
            if (wClause.Count() > 0)
                query = query + " WHERE " + wClause;
            return query;
        }

        public override int buildObj(SqlDataReader results)
        {
            int addObj = new int();
            try
            {
                addObj = Convert.ToInt32(results[2].ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in \"building\" Neighbor int: " + e.ToString());
            }

            return addObj;
        }

        public int buildCost(SqlDataReader results)
        {
            int addObj = new int();
            try
            {
                addObj = Convert.ToInt32(results[3].ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in \"building\" Neighbor cost: " + e.ToString());
            }

            return addObj;
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
