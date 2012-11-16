﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessTier;
using DataTier;

namespace Client
{
    class Program
    {
        static RemoteBetterplaceReference.RemoteRoutePlannerClient rp = new RemoteBetterplaceReference.RemoteRoutePlannerClient();

        static void Main(string[] args)
        {
            Graph graph = rp.getGraph();

            List<Node> result = graph.ShortestPath(graph.Nodes.ElementAt(1), graph.Nodes.ElementAt(5));

            foreach (Node n in result)
            {
                Console.WriteLine(n.Data._street + " " + n.Data._streetNo);
            }
            Console.ReadLine();
        }
    }
}