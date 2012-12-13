using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace DBLayer
{
    public interface IDBNode
    {
        List<Node> getAllNodes();
        Node searchNodeID(int id);
        Boolean updateNode(Node Node);
        Boolean createNode(Node Node);
        Boolean deleteNode(Node Node);
    }
}
