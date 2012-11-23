using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessTier;
using DataTier;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.IO;

namespace test
{
    class Program
    {
        static IRouteplanner rp = new RoutePlanner();
        static void Main(string[] args)
        {
            Node testNode1 = new Node(new Station("Løkkegade", "27, 3. th.", 9000));
            Node testNode2 = new Node(new Station("Løkkegade", "28, 3. th.", 9000));

            Graph graph1 = rp.getGraph();
            Graph graph2 = rp.getGraph().DeepClone();

            graph2.AddNode(testNode1);
            graph2.AddNode(testNode2);

            //List<Node> result =  graph.ShortestPath(testNode1, testNode2);
            /*List<Node> result = graph1.ShortestPath(graph1.Nodes.ElementAt(0), graph1.Nodes.ElementAt(5));

            //Console.WriteLine(result.Count.ToString());
           
           foreach (Node n in result)
           {
               Console.WriteLine(n.Data._street+" "+n.Data._streetNo);
           }*/

            foreach (Node n in graph1.Nodes)
            {
                Console.WriteLine(n.Data._street + " " + n.Data._streetNo);
            }

           Console.WriteLine("------------------------------------------------");

           /*result = graph2.ShortestPath(graph2.Nodes.ElementAt(0), graph2.Nodes.ElementAt(5));

           Console.WriteLine(result.Count.ToString());

           foreach (Node n in result)
           {
               Console.WriteLine(n.Data._street + " " + n.Data._streetNo);
           }*/

           foreach (Node n in graph2.Nodes)
           {
               Console.WriteLine(n.Data._street + " " + n.Data._streetNo);
           }

           Console.ReadLine();
        }
    }
}
