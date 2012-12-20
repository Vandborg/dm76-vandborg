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
        private Graph graph;
        private Timer reserveTimer;
        private List<Battery> reservedBatteries = new List<Battery>();
        private IDBBattery dbBattery = new DBBattery();
        private IDBNode dbNodes = new DBNode();
        private IDBNeighbors dbNeighbors = new DBNeighbors();

        public RoutePlanner()
        {
            graph = CreateGraph();
        }

        private Graph CreateGraph()
        {
            Graph finalgraph = new Graph();

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

        public List<Node> ShortestRoute(Node startNode, Node endNode)
        {
            List<Node> result = new List<Node>();
            try
            {
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
