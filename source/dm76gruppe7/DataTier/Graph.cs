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
        {												    // Initializations

            List<Node> queue = _nodeSet;                    // The set of all nodes in
                                                            // Graph

            Node nextNode = null;						    // Previous node in optimal
                                                            // path from startNode

            List<Node> shortestRoute = new List<Node>();    // This will hold the set
                                                            // of nodes which is the
                                                            // shortestPath.
            foreach (Node x in queue)
            {
                x.Label = int.MaxValue;					    // Unknown distance from
                                                            // startNode to endNode
                                                            // (infinity)

                x.InQueue = true;						    // "Cheat" queue for
                                                            // optimatiztion.
            }
            startNode.Label = 0;						    // Distance from startNode
                                                            // to startNode.

            while (queue.Count > 0)						    // The main loop
            {
                int smallestDistance = int.MaxValue;	    // This finds the vertex
                foreach (Node j in queue)				    // with the smallest
                {										    // distance.
                    if (j.Label < smallestDistance) 	    // Start node in first case
                    {									    //
                        smallestDistance = j.Label;		    //	
                        nextNode = j;					    //
                    }									    //
                }										    //

                if (smallestDistance == int.MaxValue)	    // all remaining vertices
                {										    // are inaccessible from
                    break;								    // source
                }
                queue.Remove(nextNode);					    // removes the vertex with
                                                            // smallest distance from
                                                            // queue

                nextNode.InQueue = false;				    // optimization - Don't
                                                            // have to loop through the
                                                            // List to findout
                                                            // if the node still are in
                                                            // the queue.

                if (nextNode == endNode)				    // If next node is the
                {										    // destination. Stop and
                    var tmp = nextNode;					    // Create route.
                    shortestRoute.Add(nextNode);
                    while (tmp.Previous != null)
                    {
                        shortestRoute.Add(tmp.Previous);
                        tmp = tmp.Previous;
                    }
                    shortestRoute.Reverse();
                    break;
                }

                for (int i = 0; i < nextNode.Neighbors.Count; i++)  //For every
                {												    //neighbor
                    var Neighbour = nextNode.Neighbors[i];		    //Which stil
                    if (Neighbour.InQueue)						    //are in queue
                    {
                        int distance = nextNode.Label + nextNode.Costs[i];
                        if (distance < Neighbour.Label) 		    //Relaxing
                        {
                            Neighbour.Label = distance;
                            Neighbour.Previous = nextNode;
                        }
                    }
                }
            }
            return shortestRoute;			                        //Return of the shortestRoute
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
    }
}
