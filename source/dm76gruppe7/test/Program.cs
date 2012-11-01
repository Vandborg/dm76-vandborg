using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessTier;
using DataTier;

namespace test
{
    class Program
    {
        static IRouteplanner rp = new RoutePlanner();
        static void Main(string[] args)
        {
           Graph graph = rp.getGraph();

            /*foreach(Node gn in graph.Nodes)
            {
                foreach (int i in gn.Costs)
                {
                    Console.Write(i.ToString() + " ");
                }
            }
            Console.ReadLine();*/

           List<Node> result =  graph.ShortestPath(graph.Nodes.ElementAt(0), graph.Nodes.ElementAt(5));

           foreach (Node n in result)
           {
               Console.WriteLine(n.Value);
           }

           Console.ReadLine();
        }
    }
}
