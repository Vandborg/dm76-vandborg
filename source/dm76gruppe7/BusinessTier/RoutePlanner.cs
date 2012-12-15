using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;
using System.Diagnostics;
using DBLayer;
using System.Net;
using System.Json;

namespace BusinessTier
{
    public class RoutePlanner : IRouteplanner
    {
        Graph graph;

        public RoutePlanner()
        {
            graph = new Graph();
            IDBNode dbNodes = new DBNode();
            IDBNeighbors dbNeighbors = new DBNeighbors();

            List<Node> Nodes = dbNodes.getAllNodes();
            Debug.WriteLine("First Count: "+Nodes.Count.ToString());

            foreach(Node node in Nodes)
            {
                graph.AddNode(node);
            }

            foreach (Node node in graph.Nodes)
            {
                List<List<int>> Neighbors = dbNeighbors.getAllNeighbors(node);
                foreach (int i in Neighbors.ElementAt(0))
                {
                   int count = 0;
                   foreach(Node Neighbor in graph.Nodes)
                   if(Neighbor.Id==i)
                   {
                       graph.AddDirectedEdge(node, Neighbor,Neighbors.ElementAt(1).ElementAt(count));
                   }
                   count++;
                }
            }

            /*Node node1 = new Node(new Station("Løkkegade","21, 3. th.",9000));
            Node node2 = new Node(new Station("Løkkegade", "22, 3. th.", 9000));
            Node node3 = new Node(new Station("Løkkegade", "23, 3. th.", 9000));
            Node node4 = new Node(new Station("Løkkegade", "24, 3. th.", 9000));
            Node node5 = new Node(new Station("Løkkegade", "25, 3. th.", 9000));
            Node node6 = new Node(new Station("Løkkegade", "26, 3. th.", 9000));
            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddNode(node5);
            graph.AddNode(node6);

            graph.AddUndirectedEdge(node2,node1,10);
            graph.AddUndirectedEdge(node1, node4, 15);
            graph.AddUndirectedEdge(node1, node3, 5);
            graph.AddUndirectedEdge(node3, node2, 20);
            graph.AddUndirectedEdge(node3, node6, 25);
            graph.AddUndirectedEdge(node4, node3, 10);
            graph.AddUndirectedEdge(node4, node6, 5);
            graph.AddUndirectedEdge(node4, node5, 20);
            graph.AddUndirectedEdge(node5, node2, 15);*/

        }

        public List<Node> ShortestRoute(string start, string end)
        {
            List<Node> result = new List<Node>();
            //Node startNode = new Node(AddressParser(start));
            try
            {
                string[] startAddress = AddressParser(start);
                string[] endAddress = AddressParser(end);
                Node startNode = new Node(new Location(startAddress[0], startAddress[1], Convert.ToInt32(startAddress[2])));
                Node endNode = new Node(new Location(endAddress[0], endAddress[1], Convert.ToInt32(endAddress[2])));
                Graph tempGraph = graph.DeepClone();
                tempGraph = GoogleMapsAddEdges(tempGraph, startNode, endNode);

                Debug.WriteLine("--------------------------------------------------------");
                Debug.WriteLine("ElementAt(0): "+tempGraph.Nodes.ElementAt(0).Data._street);
                Debug.WriteLine("ElementAt(5): " + tempGraph.Nodes.ElementAt(5).Data._street);
                Debug.WriteLine("--------------------------------------------------------");

                result = tempGraph.ShortestPath(startNode, endNode);
                //result = tempGraph.ShortestPath(tempGraph.Nodes.ElementAt(0), tempGraph.Nodes.ElementAt(5));
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
            return result;
        }

        private string[] AddressParser(string s)
        {
            //Format - Løkkegade-27_3_th-9000/Løkkegade-28_3_th-9000

            string[] split = s.Split(new Char[] { '-' });

            split[1] = split[1].Replace("_", " ");
            
            return split;
        }

        private Graph GoogleMapsAddEdges(Graph inputGraph,Node startNode, Node endNode)
        {
            string startNodeAddress = startNode.Data._street+"+"+startNode.Data._streetNo+"+"+startNode.Data._zipCode+"+Danmark|";
            string endNodeAddress = endNode.Data._street + "+" + endNode.Data._streetNo + "+" + endNode.Data._zipCode + "+Danmark";
            string destination = "";
            string origins = startNodeAddress+endNodeAddress;
            
            foreach (Node node in inputGraph.Nodes)
            {
                destination += node.Data._street + "+" + node.Data._streetNo + "+" + node.Data._zipCode + "+danmark|";
            }

            Debug.WriteLine("Count: "+inputGraph.Nodes.Count.ToString());
            destination = destination.Substring(0, destination.Length - 1);

            Debug.WriteLine("Origins: "+origins);
            Debug.WriteLine("Destination: "+destination);

            //string DownloadString = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + origins + "&destinations=" + destination + "&mode=driving&language=da&sensor=false";
            string DownloadString = "E:/Windows/Documents/DM76-gruppe7/testjson.json";
            
            Debug.WriteLine("DownloadString: "+DownloadString);

            WebClient webclient = new WebClient();

            dynamic result = JsonValue.Parse(webclient.DownloadString(DownloadString));

            if (result.status == "OK")
            {
                for (int i = 0; i < result.rows.Count; i++)
                {
                    for (int j = 0; j < result.rows[i].elements.Count; j++)
                    {
                        if (result.rows[i].elements[j].status == "OK")
                        {
                            if (result.rows[i].elements[j].distance.value > 100000 && result.rows[i].elements[j].distance.value < 140000)
                            {
                                if (i == 0)
                                {
                                    inputGraph.AddUndirectedEdge(startNode, inputGraph.Nodes.ElementAt(j), (int)result.rows[i].elements[j].distance.value);
                                }
                                else
                                {
                                    inputGraph.AddUndirectedEdge(endNode, inputGraph.Nodes.ElementAt(j), (int)result.rows[i].elements[j].distance.value);
                                }
                            }
                        }
                    }
                }
            }

            inputGraph.AddNode(startNode);
            inputGraph.AddNode(endNode);

            foreach(Node node in inputGraph.Nodes)
            {
                Debug.WriteLine("Street: "+node.Data._street);
                Debug.WriteLine("StreetNo: " + node.Data._streetNo);
                Debug.WriteLine("ZipCode: " + node.Data._zipCode.ToString());
            }
            Debug.WriteLine("NeighborCount: "+inputGraph.Nodes.Last().Neighbors.Count().ToString());

            return inputGraph;
        }
    }
}
