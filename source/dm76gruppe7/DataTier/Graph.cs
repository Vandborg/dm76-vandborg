using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataTier
{
    [KnownType(typeof(Node))]
    [DataContract(IsReference = true)]
    [Serializable]
    public class Graph
    {
        private List<Node> _nodeSet;

        public Graph() : this(null) { }

        public Graph(List<Node> nodeSet)
        {
            if (nodeSet == null)
            {
                this._nodeSet = new List<Node>();
            }
            else
            {
                this._nodeSet = nodeSet;
            }
        }

        public void AddNode(Node node)
        {
            _nodeSet.Add(node);
        }

        public void AddDirectedEdge(Node from, Node to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);
        }

        public void AddUndirectedEdge(Node from, Node to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);

            to.Neighbors.Add(from);
            to.Costs.Add(cost);
        }

        public bool Remove(Node nodeToRemove)
        {
            if (nodeToRemove == null)
            {
                return false;
            }

            _nodeSet.Remove(nodeToRemove);

            foreach (Node gnode in _nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    gnode.Neighbors.RemoveAt(index);
                    gnode.Costs.RemoveAt(index);
                }
            }

            return true;
        }

        public List<Node> ShortestPath(Node startNode, Node endNode)
        {
            List<Node> queue = _nodeSet;
            Node nextNode = null;
            List<Node> shortestRoute = new List<Node>();
            
            foreach(Node x in queue){
                Debug.Write(x.Data._streetNo + " => ");
                foreach (var y in x.Neighbors)
                    Debug.Print(y.Data._streetNo + " (" + x.Costs[x.Neighbors.IndexOf(y)] + ")");
                x.Label = int.MaxValue;
                x.InQueue = true;
            }
            startNode.Label = 0;

            while (queue.Count > 0)
            {
                int smallestDistance = int.MaxValue;

                foreach (Node j in queue) // only the previous nodes have a label
                {
                    if (j.Label < smallestDistance)
                    {
                        smallestDistance = j.Label;
                        nextNode = j;
                    }
                }

                if (smallestDistance == int.MaxValue)
                {
                    break;
                }

                queue.Remove(nextNode);
                nextNode.InQueue = false; // optimization

                if (nextNode == endNode)
                {
                    var tmp = nextNode;
                    shortestRoute.Add(nextNode);
                    while (tmp.Previous != null)
                    {
                        shortestRoute.Add(tmp.Previous);
                        tmp = tmp.Previous;
                    }
                    shortestRoute.Reverse();
                    break;
                }

                for(int i = 0; i < nextNode.Neighbors.Count; i++)
                {
                    var Neighbour = nextNode.Neighbors[i];
                    if (Neighbour.InQueue)
                    {
                        int distance = nextNode.Label + nextNode.Costs[i];
                        if (distance < Neighbour.Label)
                        {
                            Neighbour.Label = distance;
                            Neighbour.Previous = nextNode;
                        }
                    }
                }
            }
            Console.WriteLine("Teest");
            return shortestRoute;
        }

        [DataMember]
        public List<Node> Nodes
        {
            get
            {
                return _nodeSet;
            }
        }

        public Graph DeepClone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (Graph)formatter.Deserialize(ms);
            }
        }

        /*[DataMember]
        public int Count
        {
            get
            {
                return _nodeSet.Count;
            }
        }*/
    }
}
