using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class Node
    {
        public string Data { get; set; }  //skal blive en location
        public List<Node> Neighbors { get; set; }
        public List<int> Costs { get; private set; }
        public int Label { get; set; }
        public Node Previous { get; set; }
        public bool InQueue = false;

        public Node() : this("") {}
        public Node(string data) : this(data, new List<Node>()) { }
        public Node(string data, List<Node> neighbors)
        {
            this.Data = data;
            this.Neighbors = neighbors;
            this.Costs = new List<int>();
            this.Label = 0;
            this.Previous = null;
        }
    }
}
