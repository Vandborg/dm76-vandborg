using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class Node
    {
        private string _data; //skal blive en location
        private List<Node> _neighbors = new List<Node>();
        private List<int> _costs = new List<int>();

        public Node() {}
        public Node(string data) : this(data, null) {}
        public Node(string data, List<Node> neighbors)
        {
            this._data = data;
            this._neighbors = neighbors;
        }

        public string Value
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public List<Node> Neighbors
        {
            get
            {
                return _neighbors;
            }
            set
            {
                _neighbors = value;
            }
        }

        public List<int> Costs
        {
            get
            {
                if (_costs == null)
                {
                    _costs = new List<int>();
                }

                return _costs;
            }
        }
    }
}
