using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
    public class Dijkstra
    {
        /* Takes adjacency matrix in the following format, for a directed graph (2-D array)
        * Ex. node 1 to 3 is accessible at a cost of 4
        *        0  1  2  3  4 
        *   0  { 0, 2, 5, 0, 0},
        *   1  { 0, 0, 0, 4, 0},
        *   2  { 0, 6, 0, 0, 8},
        *   3  { 0, 0, 0, 0, 9},
        *   4  { 0, 0, 0, 0, 0}
        *   
        * How to create graph:
        * Create the array containing the adjacency matrix
            double[,] G = new double[Vertices.Count, Vertices.Count];

            Set the connections and weights based on each edge in the collection 
            foreach (Edge edge in Edges)
            {
                G[edge.from, edge.to] = edge.weight;
            }
        */

        int[] _distance;
        int[] _path;

        private List<int> _queue = new List<int>();

        private void Initialize(int startNodeID, int length)
        {
            _distance = new int[length];
            _path = new int[length];

            for (int i = 0; i < length; i++)
            {
                _distance[i] = int.MaxValue;

                _queue.Add(i);
            }

            _distance[startNodeID] = 0;
            _path[startNodeID] = -1;
        }

        private int GetNextNodeID()
        {
            int min = int.MaxValue;
            int NodeID = -1;

            foreach (int j in _queue)
            {
                if (_distance[j] <= min)
                {
                    min = _distance[j];
                    NodeID = j;
                }

            }

            _queue.Remove(NodeID);

            return NodeID;
        }

        public Dijkstra(int[,] graph, int startNodeID)
        {
            if (graph.GetLength(0) < 1 || graph.GetLength(0) != graph.GetLength(1))
                throw new ArgumentException("Graph error, wrong format or no nodes to compute");

            int length = graph.GetLength(0);

            Initialize(startNodeID, length);

            while (_queue.Count > 0)
            {
                int u = GetNextNodeID();

                for (int v = 0; v < length; v++)
                {
                    if (graph[u, v] < 0)
                    {
                        throw new ArgumentException("Graph contains negative edge(s)");
                    }

                    if (graph[u, v] > 0)
                    {
                        if (_distance[v] > _distance[u] + graph[u, v])
                        {
                            _distance[v] = _distance[u] + graph[u, v];
                            _path[v] = u;
                        }
                    }
                }
            }
        }
    }
}
