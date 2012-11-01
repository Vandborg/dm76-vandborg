using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
    public class RoutePlanner : IRouteplanner
    {
        Graph _web;

        public RoutePlanner()
        {
            _web = new Graph();
            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();
            Node node5 = new Node();
            Node node6 = new Node();
            node1.Data = "node1";
            node2.Data = "node2";
            node3.Data = "node3";
            node4.Data = "node4";
            node5.Data = "node5";
            node6.Data = "node6";
            _web.AddNode(node1);
            _web.AddNode(node2);
            _web.AddNode(node3);
            _web.AddNode(node4);
            _web.AddNode(node5);
            _web.AddNode(node6);

            _web.AddUndirectedEdge(node2,node1,10);
            _web.AddUndirectedEdge(node1, node4, 15);
            _web.AddUndirectedEdge(node1, node3, 5);
            _web.AddUndirectedEdge(node3, node2, 20);
            _web.AddUndirectedEdge(node3, node6, 25);
            _web.AddUndirectedEdge(node4, node3, 10);
            _web.AddUndirectedEdge(node4, node6, 5);
            _web.AddUndirectedEdge(node4, node5, 20);
            _web.AddUndirectedEdge(node5, node2, 15);

        }

        public Graph getGraph()
        {
            return _web;
        }

        /*public Route createRoute(DateTime startDate, Node<Station> startAddress, Node<Station> endAddress)
        {
            throw new NotImplementedException();
        }*/
    }
}
