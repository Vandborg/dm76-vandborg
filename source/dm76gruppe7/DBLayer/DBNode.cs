using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using DataTier;

namespace DBLayer
{
    public class DBNode : DBConnection<Node>, IDBNode
    {

        public List<Node> getAllNodes()
        {
            return miscWhere("");
        }

        public Node searchNodeID(int id)
        {
            String wClause = "n.ID = " + id + " ";
            return singleWhere(wClause);
        }

        public bool updateNode(Node Node)
        {
            string sClause = "";
            if(Node.Data.GetType()==typeof(Location))
            {
                sClause += "SET LocationID=" + Convert.ToInt32(Node.Data._id).ToString();
                sClause += ", StationID=null";
            }
            else
            {
                sClause += "SET StationID=" + Convert.ToInt32(Node.Data._id).ToString();
                sClause += ", LocationID=null";
            }

            return update(Node.Id, sClause);
        }

        public bool createNode(Node Node)
        {
            string values = "";
            if (Node.Data.GetType() == typeof(Location))
            {
                values += Node.Data._id.ToString();
                values += ", null";
            }
            else
            {
                values += "null, ";
                values += Node.Data._id.ToString();
            }            
            return insert(values);
        }

        public bool deleteNode(Node Node)
        {
            string wClause = "ID=" + Node.Id;

            return delete(wClause);
        }

        public override string buildQuery(string wClause)
        {
            String query = "SELECT * FROM Node n";
            query += " LEFT JOIN Station s ON n.StationID=s.ID";
            query += " LEFT JOIN Location l ON n.LocationID = l.ID";
            if (wClause.Count() > 0)
                query = query + " WHERE " + wClause;
            return query;
        }

        public override Node buildObj(SqlDataReader results)
        {
            Node addObj = new Node();
            try
            {
                if (results[1].ToString() == "null")
                {
                    addObj = new Node(Convert.ToInt32(results[0].ToString()),
                                        new Location(Convert.ToInt32(results[7].ToString()),results[8].ToString(),results[9].ToString(),Convert.ToInt32(results[10].ToString()))
                                     );
                }
                else
                {
                    addObj = new Node(Convert.ToInt32(results[0].ToString()),
                                        new Station(Convert.ToInt32(results[3].ToString()), results[4].ToString(), results[5].ToString(), Convert.ToInt32(results[6].ToString()))
                                     );
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in building Node Object: " + e.ToString());
            }

            return addObj;
        }

        public override string updateQuery(int id, string sClause)
        {
            string query = "UPDATE Node ";
            query += sClause;
            query += " WHERE ID=" + id.ToString();
            Debug.WriteLine(query);
            return query;
        }

        public override string insertQuery(string values)
        {
            String query = "INSERT INTO Node (LocationID, StationID) values (" + values + ")";
            Debug.WriteLine(query);
            return query;
        }

        public override string deleteQuery(string wClause)
        {
            String query = "DELETE FROM Node WHERE ";
            query += wClause;
            return query;
        }
    }
}
