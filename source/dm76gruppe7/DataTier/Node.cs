using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataTier
{
    [KnownType(typeof(Location))]
    [KnownType(typeof(Station))]
    [DataContract(IsReference = true)]
    [Serializable]
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
        public Node(Location data) : this(-1, data, new List<Node>(), new List<int>()) { }
        public Node(int id, Location data) : this(id, data, new List<Node>(), new List<int>()) { }
        public Node(int id, Location data, List<Node> neighbors, List<int> costs)
        {
            Id = id;
            Data = data;
            Neighbors = neighbors;
            //Costs = new List<int>();
            Costs = costs;
            Label = 0;
            Previous = null;
        }
    }
}
