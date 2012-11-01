using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
    public interface IRouteplanner
    {
        Graph getGraph();
        //Route createRoute(DateTime startDate, Node<Station> startAddress, Node<Station> endAddress);
    }
}
