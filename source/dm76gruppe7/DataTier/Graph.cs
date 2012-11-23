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
            //List<Node> queue = new List<Node>();
            
            /*foreach (Node n in _nodeSet)
            {
                if (n == startNode)
                { 
                    startNode = startNode.DeepClone();
                    queue.Add(startNode);
                    //startNode = new Node(startNode.Id, startNode.Data, startNode.Neighbors, startNode.Costs);
                    //queue.Add(startNode);
                }
                else if (n == endNode)
                {
                   // endNode = new Node(endNode.Id, endNode.Data, endNode.Neighbors, endNode.Costs);
                    //queue.Add(endNode);
                    endNode = endNode.DeepClone();
                    queue.Add(endNode);
                }
                else
                {
                    //queue.Add(new Node(n.Id, n.Data, n.Neighbors, n.Costs));
                    queue.Add(n.DeepClone());
                }
            }*/

            /*foreach (Node test in queue)
            {
                Console.WriteLine(test.Data._street + " " + test.Data._streetNo);
            }*/

            Node nextNode = null;
            List<Node> shortestRoute = new List<Node>();

           /* if (!_nodeSet.Contains(startNode))
            {
                Console.WriteLine("running");
                queue.Add(startNode);
                startNode.Neighbors.Add(queue.ElementAt(0));
                startNode.Costs.Add(10);
                //this.AddUndirectedEdge(startNode, queue.ElementAt(0),10);
            }

            if (!_nodeSet.Contains(endNode))
            {
                queue.Add(endNode);
                endNode.Neighbors.Add(queue.ElementAt(2));
                endNode.Costs.Add(5);
                //this.AddUndirectedEdge(endNode, queue.ElementAt(2), 10);
            }*/

            
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
