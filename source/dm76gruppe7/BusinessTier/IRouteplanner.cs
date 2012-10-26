using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
    interface IRouteplanner
    {
        Route createRoute(DateTime startDate, Node startAddress, Node endAddress);
    }
}
