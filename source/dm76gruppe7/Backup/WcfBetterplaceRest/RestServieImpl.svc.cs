using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;

namespace WcfBetterplaceRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestServieImpl" in code, svc and config file together.
    public class RestServieImpl : IRestServieImpl
    {
        #region IRestService Memebers
        public string XMLData(string id)
        {
            return "You requested product " + id;
        }

        public string JSONData(string id)
        {
            List<string> test = new List<string>();
            List<string> test1 = new List<string>();
            test.Add("test1");
            test.Add("test2");
            test.Add("test3");
            test.Add("test4");
            test.Add("test5");
            test.Add("test6");
            test.Add("test7");

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(test);

            test1 = jsonSerialiser.Deserialize<List<string>>(json);

            foreach(string s in test1)
            {
                json += s;
            }

            return json;
        }
        #endregion
    }
}
