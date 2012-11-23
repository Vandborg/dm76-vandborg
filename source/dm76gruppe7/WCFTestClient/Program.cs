using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;
using BusinessTier;

namespace WCFTestClient
{
    class Program
    {
        //static IRouteplanner rp = new RoutePlanner();
        static void Main(string[] args)
        {
            RemoteBetterplaceReference.RemoteRoutePlannerClient rp = new RemoteBetterplaceReference.RemoteRoutePlannerClient();
            
            Node testNode1 = new Node(new Station("Løkkegade","27, 3. th.",9000));
            Node testNode2 = new Node(new Station("Løkkegade","28, 3. th.",9000));

            Node[] result = rp.shortestRoute(testNode1, testNode2);

            foreach (Node n in result)
            {
                Console.WriteLine(n.Data._street + " " + n.Data._streetNo);
            }

            /*Graph graph = rp.getGraph();

            List<Node> result = graph.ShortestPath(graph.Nodes.ElementAt(1), graph.Nodes.ElementAt(5));

            foreach (Node n in result)
            {
                Console.WriteLine(n.Data._street + " " + n.Data._streetNo);
            }*/
            Console.ReadLine();
        }
    }
}
