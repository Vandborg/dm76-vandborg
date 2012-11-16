using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessTier;
using DataTier;

namespace WCFBetterplace
{
    public class RemoteRoutePlanner : IRemoteRoutePlanner
    {
        static IRouteplanner rp = new RoutePlanner();
        public DataTier.Graph getGraph()
        {
            return rp.getGraph();
        }
    }
}
