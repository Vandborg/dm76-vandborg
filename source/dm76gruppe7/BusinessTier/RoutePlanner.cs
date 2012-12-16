using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;
using System.Diagnostics;
using DBLayer;
using System.Net;
using System.Json;
using System.Timers;

namespace BusinessTier
{
    public class RoutePlanner : IRouteplanner
    {
        Graph graph;
        Timer reserveTimer;
        List<Battery> reservedBatteries = new List<Battery>();
        IDBBattery dbBattery = new DBBattery();

        public RoutePlanner()
        {
            graph = CreateGraph();

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

        private Graph CreateGraph()
        {
            Graph finalgraph = new Graph();
            IDBNode dbNodes = new DBNode();
            IDBNeighbors dbNeighbors = new DBNeighbors();
            IDBBattery dbBattery = new DBBattery();

            List<Node> Nodes = dbNodes.getAllNodes();
            List<Battery> Batteries = dbBattery.getAllBatteries();

            foreach (Node node in Nodes)
            {
                foreach (Battery battery in Batteries)
                {
                    if (battery._station != null)
                    {
                        if (node.Data._id == battery._station._id)
                        {
                            node.Data.AddBattery(battery);
                        }
                    }
                }

                Battery batteryCharged = node.Data.Batteries.Find(
                        delegate(Battery bttr)
                        {
                            return bttr._status == Battery.Status.Charged;
                        }
                        );

                if (batteryCharged != null)
                {
                    finalgraph.AddNode(node);
                }
            }

            Debug.WriteLine("count: "+finalgraph.Nodes.Count().ToString());

            foreach (Node node in finalgraph.Nodes)
            {
                List<List<int>> Neighbors = dbNeighbors.getAllNeighbors(node);
                foreach (int i in Neighbors.ElementAt(0))
                {
                    int count = 0;
                    foreach (Node Neighbor in finalgraph.Nodes)
                        if (Neighbor.Id == i)
                        {
                            finalgraph.AddDirectedEdge(node, Neighbor, Neighbors.ElementAt(1).ElementAt(count));
                        }
                    count++;
                }
            }
            return finalgraph;
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

                result = tempGraph.ShortestPath(startNode, endNode);

                //Reservering the batteries
                foreach (Node node in result)
                {
                    if (node.Id != -1)
                    {
                        Battery battery = node.Data.Batteries.First();
                        battery._status = Battery.Status.Reserved;
                        reservedBatteries.Add(battery);
                        Debug.WriteLine("Succes: "+dbBattery.updateBattery(battery).ToString());
                    }
                }

                reserveTimer = new System.Timers.Timer(1000 * 60 * 15);
                reserveTimer.Elapsed += new ElapsedEventHandler(unreserveBatteries);
                reserveTimer.Start();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            Debug.WriteLine("result count: "+result.Count.ToString());

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

            destination = destination.Substring(0, destination.Length - 1);

            string DownloadString = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + origins + "&destinations=" + destination + "&mode=driving&language=da&sensor=false";
            //string DownloadString = "E:/Windows/Documents/DM76-gruppe7/testjson.json";

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

            return inputGraph;
        }

        private void unreserveBatteries(object source, ElapsedEventArgs e)
        {
            reserveTimer.Stop();
            reserveTimer.Dispose();

            foreach(Battery battery in reservedBatteries)
            {
                if(battery._status != Battery.Status.Booked)
                {
                    battery._status = Battery.Status.Charged;
                    dbBattery.updateBattery(battery);
                }
            }
        }
    }
}
