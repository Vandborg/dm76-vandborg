using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
    public interface IRouteplanner
    {
        //List<Node> ShortestRoute(string start, string end);
        List<Node> ShortestRoute(Node startNode, Node endNode);
        //Graph getGraph();
        //Route createRoute(DateTime startDate, Node<Station> startAddress, Node<Station> endAddress);
    }
}
