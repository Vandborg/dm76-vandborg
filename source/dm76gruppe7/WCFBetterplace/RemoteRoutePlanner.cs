using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using BusinessTier;

namespace WCFBetterplace
{
    public class RemoteRoutePlanner : IRemoteRoutePlanner
    {
        static RoutePlanner rp = new RoutePlanner();

        public Graph getGraph()
        {
            return rp.getGraph();
        }
    }
}
