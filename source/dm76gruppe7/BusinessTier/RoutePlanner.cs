using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;
using System.Diagnostics;

namespace BusinessTier
{
    public class RoutePlanner : IRouteplanner
    {
        Graph graph;

        public RoutePlanner()
        {
            graph = new Graph();
            Node node1 = new Node(new Station("Løkkegade","21, 3. th.",9000));
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
            graph.AddUndirectedEdge(node5, node2, 15);

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
                tempGraph.AddNode(startNode);
                tempGraph.AddNode(endNode);
                tempGraph.AddUndirectedEdge(startNode, tempGraph.Nodes.ElementAt(0), 10);
                tempGraph.AddUndirectedEdge(endNode, tempGraph.Nodes.ElementAt(5), 5);

                result = tempGraph.ShortestPath(startNode, endNode);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
            return result;
        }

        public string[] AddressParser(string s)
        {
            //Format - Løkkegade-27_3_th-9000/Løkkegade-28_3_th-9000

            string[] split = s.Split(new Char[] { '-' });

            split[1] = split[1].Replace("_", " ");
            
            return split;
        }
    }
}
