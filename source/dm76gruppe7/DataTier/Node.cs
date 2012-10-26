using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class Node
    {
        public int _id { get; set; }
        public string _street { get; set; }
        public string _streetNo { get; set; }
        public int _zipCode { get; set; }
        List<Node> _adjacentNodes = new List<Node>();
        List<Edge> _edges = new List<Edge>();

        public Node()
        {
            _id = -1;
            _street = null;
            _streetNo = null;
            _zipCode = -1;
        }

        public Node(String street, String streetNo, int zipCode)
        {
            _id = -1;
            _street = street;
            _streetNo = streetNo;
            _zipCode = zipCode;
        }

        public Node(int id, String street, String streetNo, int zipCode)
        {
            _id = id;
            _street = street;
            _streetNo = streetNo;
            _zipCode = zipCode;
        }

        public void AddAdjacentNode(Node node)
        {
            _adjacentNodes.Add(node);
        }

        public void RemoveAdjacentNode(int id)
        {
            Node result = _adjacentNodes.Find(
                        delegate(Node node)
                        {
                            return node._id == id;
                        });
            _adjacentNodes.Remove(result);
        }

        public void RemoveAdjacentNode(Node node)
        {
            _adjacentNodes.Remove(node);
        }

        public void AddEdge(Edge edge)
        {
            _edges.Add(edge);
        }

        public void RemoveEdge(int id)
        {
            Edge result = _edges.Find(
                        delegate(Edge edge)
                        {
                            return edge._id == id;
                        });
            _edges.Remove(result);
        }

        public void RemoveEdge(Edge edge)
        {
            _edges.Remove(edge);
        }
    }
}
