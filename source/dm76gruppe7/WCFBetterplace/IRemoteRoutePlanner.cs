using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;

namespace WCFBetterplace
{
    [ServiceContract]
    public interface IRemoteRoutePlanner
    {
        [OperationContract]
        Graph getGraph();

        [OperationContract]
        List<string> test();

        [OperationContract]
        List<Node> shortestRoute(Node startNode, Node endNode);
    }
}
