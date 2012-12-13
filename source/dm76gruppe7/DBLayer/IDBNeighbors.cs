using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace DBLayer
{
    public interface IDBNeighbors
    {
        List<Node> getAllNeighbors(Node FromNode);
        List<int> getAllCosts(Node FromNode);
        Boolean updateNeighbors(List<Node> Neighbors, List<int> Costs);
        Boolean createNeighbors(List<Node> Neighbors, List<int> Costs);
        Boolean deleteNeighbors(List<Node> Neighbors, List<int> Costs);
    }
}
