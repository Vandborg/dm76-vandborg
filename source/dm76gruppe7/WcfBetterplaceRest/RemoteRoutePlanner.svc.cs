using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessTier;
using DataTier;
using System.Web.Script.Serialization;

namespace WcfBetterplaceRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class RemoteRoutePlanner : IRemoteRoutePlanner
    {
        static IRouteplanner rp = new RoutePlanner();
        
        public string shortestRoute(string start,string end)
        {
            List<string> resultAddresses = new List<string>();
            List<Node> result = rp.ShortestRoute(start, end);
            foreach(Node n in result)
            {
                string address = n.Data._street + "," + n.Data._streetNo+"," + n.Data._zipCode;
                resultAddresses.Add(address);
            }
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(resultAddresses);

            return json;
        }

        /*public string shortestRoute(string test)
        {


            Node startNode = new Node(new Location("Løkkegade", "27, 3. th.", 9000));
            Node endNode = new Node(new Location("Løkkegade", "28, 3. th.", 9000));

            List<Node> result = new List<Node>();
            Graph graph = rp.getGraph().DeepClone();
            graph.AddNode(startNode);
            graph.AddNode(endNode);
            graph.AddUndirectedEdge(startNode, graph.Nodes.ElementAt(0), 10);
            graph.AddUndirectedEdge(endNode, graph.Nodes.ElementAt(5), 5);

            result = graph.ShortestPath(startNode, endNode);
            /*Node[] test = new Node[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                test[i] = result[i];
            }

            return "test: "+test;
        }*/
    }
}
