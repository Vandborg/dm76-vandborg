using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessTier;
using DataTier;

namespace WCFBetterplace
{
    public class RemoteRoutePlanner : IRemoteRoutePlanner
    {
        static IRouteplanner rp = new RoutePlanner();
        
        public DataTier.Graph getGraph()
        {
            return rp.getGraph();
        }

        public List<string> test()
        {
            List<string> test = new List<string>();
            test.Add("test1");
            test.Add("test2");
            test.Add("test3");
            test.Add("test4");
            test.Add("test5");
            test.Add("test6");
            return test;
        }

        public List<Node> shortestRoute(Node startNode, Node endNode)
        {
            List<Node> test = new List<Node>();
            return test;
        }
    }
}
