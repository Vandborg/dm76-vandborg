using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DataTier
{
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

        /*public void AddNode(T value)
        {
            _nodeSet.Add(new GraphNode<T>(value));
        }*/

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

        /*public bool Contains(Node value)
        {
            //return _nodeSet.FindByValue(value) != null;
            return _nodeSet.Contains(value);
        }*/

        public bool Remove(Node nodeToRemove)
        {
           /* Node nodeToRemove = _nodeSet.Find(value);
            Node nodeToRemove = _nodeSet.Find(*/
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
            List<int> distance = new List<int>();
            List<int> altDistance = new List<int>();
            List<Node> previous = new List<Node>();
            List<Node> queue = _nodeSet;
            Node nextNode = null;
            List<Node> shortestRoute = new List<Node>();

            foreach (Node i in queue)
            {
                distance.Add(int.MaxValue);
                previous.Add(null);
            }

            distance[queue.IndexOf(startNode)] = 0;
            
            #region Init start
            Debug.WriteLine("------------------Init start------------------");
            Debug.WriteLine("Node: "+queue.ElementAt(queue.IndexOf(startNode)).Value);
            Debug.WriteLine("Distance: " + distance[queue.IndexOf(startNode)]);
            Debug.WriteLine("Index: " + queue.IndexOf(startNode));
            Debug.WriteLine("-------------------Init end...----------------");
            #endregion

            //previous[queue.IndexOf(startNode)] = -1;

            while (queue.Count > 0)
            {
                int smallestDistance = int.MaxValue;
                #region Smallest distance start
                Debug.WriteLine("------------------Smallest distance start------------------");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Windows\Documents\DM76-gruppe7\Log.txt", true))
                {
                    file.WriteLine("------------------Smallest distance start------------------");
                    file.WriteLine("SmallestDistance before loop: " + smallestDistance.ToString());
                } 
                Debug.WriteLine("SmallestDistance before loop: " + smallestDistance.ToString());
                #endregion
                #region commented out
                /*for (int i = 0; i < queue.Count; i++)
                {
                    if (distance[i] <= smallestDistance && distance[i] != 0 )
                    {
                        smallestDistance = distance[i];
                        nextNode = i;
                    }
                    else if (distance[i] == 0)
                    {
                        nextNode = queue.IndexOf(startNode);
                    }
                }*/
                #endregion

                foreach (Node j in queue)
                {
                    #region output
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Windows\Documents\DM76-gruppe7\Log.txt", true))
                    {
                        file.WriteLine("foreach: " + j.Value);
                    }
                    Debug.WriteLine("Node j:" + j.Value);
                    #endregion
                    if (distance[queue.IndexOf(j)] <= smallestDistance)
                    {
                        smallestDistance = distance[queue.IndexOf(j)];
                        #region output
                        Debug.WriteLine("SmallestDistance after loop: " + smallestDistance.ToString());
                        #endregion
                        nextNode = j;
                        #region output
                        Debug.WriteLine("nextNode: " + nextNode.Value);
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Windows\Documents\DM76-gruppe7\Log.txt", true))
                        {
                            file.WriteLine("Distance[" + queue.IndexOf(j) + "]: " + distance[queue.IndexOf(j)]);
                            file.WriteLine("SmallestDistance after loop: " + smallestDistance.ToString());
                            file.WriteLine("nextNode: " + nextNode.Value);
                        }
                        #endregion
                    }
                }

                altDistance.Add(distance[queue.IndexOf(nextNode)]);

                #region output
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Windows\Documents\DM76-gruppe7\Log.txt", true))
                {
                    file.WriteLine("Before remove");
                }

                foreach (int i in distance)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Windows\Documents\DM76-gruppe7\Log.txt", true))
                    {
                        file.WriteLine("i: " + i.ToString());
                    }
                }
                #endregion

                if (distance[queue.IndexOf(nextNode)] == int.MaxValue)
                {
                    break;
                }


                distance.RemoveAt(queue.IndexOf(nextNode));
                queue.Remove(nextNode);

                if (nextNode == endNode)
                {
                    for (int i = 0; i < previous.Count;i++ )
                    {
                        if (previous[i] != null)
                        {
                            shortestRoute.Add(previous[i]);
                        }
                    }
                    break;
                }

                
                #region output
                Debug.WriteLine("------------------Smallest distance end--------------------");
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Windows\Documents\DM76-gruppe7\Log.txt", true))
                {
                    file.WriteLine("------------------Smallest distance end--------------------" + nextNode.Value);
                    file.WriteLine("-------------------Removing stuff start--------------------");
                }
                #endregion



                #region output
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Windows\Documents\DM76-gruppe7\Log.txt", true))
                {
                    file.WriteLine("After remove");
                }
                foreach (int i in distance)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Windows\Documents\DM76-gruppe7\Log.txt", true))
                    {
                        file.WriteLine("i: " + i.ToString());
                    }
                }
                #endregion
                

                #region output
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Windows\Documents\DM76-gruppe7\Log.txt", true))
                {
                    file.WriteLine("-------------------Removing stuff end----------------------");
                }
                #endregion

                #region commented out
                /*if (nextNode == queue.IndexOf(endNode))
                {
                    for (int i = 0; i < previous.Count; i++)
                    {
                        if (previous[i] != -1)
                        {
                            shortestRoute.Add(_nodeSet.ElementAt(previous[i]));
                            break;
                        }
                    }
                }*/
                #endregion

                foreach (Node neighbor in nextNode.Neighbors)
                {
                    if(queue.Contains(neighbor))
                    {
                        int alt = altDistance.Last() + nextNode.Costs[nextNode.Neighbors.IndexOf(neighbor)];
                        int v = queue.IndexOf(neighbor);
                        if(alt < distance[v])
                        {
                            #region output
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\Windows\Documents\DM76-gruppe7\Log.txt", true))
                            {
                                file.WriteLine("-------------------Neighborloop start----------------------");
                                file.WriteLine("nextNode: " + nextNode.Value);
                                file.WriteLine("neighbor: " + neighbor.Value);
                                file.WriteLine("alt: " + alt.ToString());
                                file.WriteLine("distance: " + distance[v].ToString());
                                file.WriteLine("-------------------Neighborloop end------------------------");
                            }
                            #endregion
                            distance[v] = alt;
                            previous.Add(nextNode);
                        }
                    }
                }
                #region commented out
                /*if (nextNode > 0)
                {
                    for (int v = 0; v < queue.ElementAt(nextNode).Neighbors.Count; v++)
                    {
                        Node Neighbor = queue.ElementAt(nextNode).Neighbors.ElementAt(v);

                        /*for (int i = 0; i < queue.Count; i++)
                        {
                        }*/

                /* int alt = distance[nextNode] + queue.ElementAt(nextNode).Costs[v];

                 if (queue.Contains(Neighbor))
                 {
                     if (alt < distance[queue.IndexOf(Neighbor)])
                     {
                         distance[queue.IndexOf(Neighbor)] = alt;
                         previous[queue.IndexOf(Neighbor)] = nextNode;
                     }
                 }
             }
         }
         queue.RemoveAt(nextNode);*/
                #endregion
            }
            
            return shortestRoute;
        }

        public List<Node> Nodes
        {
            get
            {
                return _nodeSet;
            }
        }

        public int Count
        {
            get
            {
                return _nodeSet.Count;
            }
        }
    }
}
