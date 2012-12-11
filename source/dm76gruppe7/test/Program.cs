using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessTier;
using DataTier;
using DBLayer;
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
            /*Node testNode1 = new Node(new Station("Løkkegade", "27, 3. th.", 9000));
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
           }

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
           }

           foreach (Node n in graph2.Nodes)
           {
               Console.WriteLine(n.Data._street + " " + n.Data._streetNo);
           }

           Console.ReadLine();*/

            IDBBattery dbbattery = new DBBattery();
            Battery battery = new Battery(Battery.Status.Charged,new Station(1,"TRAFIKCENTER SÆBY SYD","20",9300));

            if (dbbattery.createBattery(battery))
            {
                Console.WriteLine("Battery created in database");
                List<Battery> batteries = dbbattery.getAllBatteries();
                Console.WriteLine("-------------The new battery------------");
                Console.WriteLine("ID: "+batteries.Last()._id.ToString());
                Console.WriteLine("StationID: "+batteries.Last()._station._id.ToString());
                Console.WriteLine("Status: "+batteries.Last()._status.ToString());
                Console.WriteLine("----------------------------------------");

                batteries.Last()._station = null;
                batteries.Last()._status = Battery.Status.Booked;

                if(dbbattery.updateBattery(batteries.Last()))
                {
                    Console.WriteLine("Battery updated in database");
                    List<Battery> batteries2 = dbbattery.getAllBatteries();
                    Console.WriteLine("----------The updated battery------------");
                    Console.WriteLine("ID: " + batteries2.Last()._id.ToString());
                    //Console.WriteLine("StationID: " + batteries2.Last()._station.ToString());
                    Console.WriteLine("Status: " + batteries2.Last()._status.ToString());
                    Console.WriteLine("----------------------------------------");
                }
            }
            Console.ReadLine();
        }
    }
}
