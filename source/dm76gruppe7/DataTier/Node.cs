using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataTier
{
    [KnownType(typeof(Location))]
    public class Node
    {
        [DataMember]
        public int Id { get; private set;}
        [DataMember]
        public Location Data { get; set; }
        [DataMember]
        public List<Node> Neighbors { get; set; }
        [DataMember]
        public List<int> Costs { get; private set; }
        [DataMember]
        public int Label { get; set; }
        [DataMember]
        public Node Previous { get; set; }
        [DataMember]
        public bool InQueue = false;

        public Node() : this(null) {}
        public Node(Location data) : this(-1,data, new List<Node>()) { }
        public Node(int id, Location data) : this(id, data, new List<Node>()) { }
        public Node(int id, Location data, List<Node> neighbors)
        {
            Id = id;
            Data = data;
            Neighbors = neighbors;
            Costs = new List<int>();
            Label = 0;
            Previous = null;
        }
    }
}
