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
            Console.WriteLine(DateTime.Now); 
          Graph graph = rp.getGraph();
          Console.WriteLine(DateTime.Now); 

          // Console.WriteLine(Marshal.SizeOf(graph).ToString());
            List<Node> result =  graph.ShortestPath(graph.Nodes.ElementAt(0), graph.Nodes.ElementAt(2));

           foreach (Node n in result)
           {
               Console.WriteLine(n.Data._street+" "+n.Data._streetNo);
           }
           Console.ReadLine();
        }
    }
}
