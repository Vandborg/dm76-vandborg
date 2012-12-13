using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using DataTier;

namespace DBLayer
{
    public class DBNeighbors : DBConnection<Node>, IDBNeighbors
    {

        public List<Node> getAllNeighbors(Node FromNode)
        {
            return miscWhere("FromNodeID="+FromNode.Id.ToString());
        }

        public List<int> getAllCosts(Node FromNode)
        {
            throw new NotImplementedException();
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

        public override Node buildObj(SqlDataReader results)
        {
            //Create something with DBNodes
            throw new NotImplementedException();
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
