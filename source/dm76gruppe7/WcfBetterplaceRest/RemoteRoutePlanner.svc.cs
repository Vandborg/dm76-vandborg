using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessTier;
using DataTier;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace WcfBetterplaceRest
{
    public class RemoteRoutePlanner : IRemoteRoutePlanner
    {
        
        public string shortestRoute(string start,string end)
        {
            IRouteplanner rp = new RoutePlanner();
            List<Location> resultList = new List<Location>();

            string[] startAddress = AddressParser(start);
            string[] endAddress = AddressParser(end);
            Node startNode = new Node(new Location(startAddress[0], startAddress[1], Convert.ToInt32(startAddress[2])));
            Node endNode = new Node(new Location(endAddress[0], endAddress[1], Convert.ToInt32(endAddress[2])));

            List<Node> result = rp.ShortestRoute(startNode, endNode);
            foreach(Node n in result)
            {
                resultList.Add(n.Data);
            }
            Debug.WriteLine("remote result count: "+result.Count.ToString());
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(resultList);

            return json;
        }

        private string[] AddressParser(string s)
        {
            //Format - Løkkegade-27_3_th-9000/Løkkegade-28_3_th-9000

            string[] split = s.Split(new Char[] { '-' });

            split[1] = split[1].Replace("_", " ");

            return split;
        }
    }
}
