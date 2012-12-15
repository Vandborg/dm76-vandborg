using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Client
{
    public partial class Form1 : Form
    {
        RoutePlanner.Service1 route = new RoutePlanner.Service1();
        public Form1()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient webclient = new WebClient();
            webclient.Encoding = System.Text.Encoding.UTF8;
            string DownloadedString = webclient.DownloadString("http://localhost:3108/RemoteRoutePlanner.svc/shortestRoute/Løkkegade-27_3_th-9000/Campusvej-55-5230");

            //Done because WCF is adding escape chars. It is a default behavior and is apparently mandatory. And therefore it's not valid JSON.
            DownloadedString = DownloadedString.Replace("\\", "");
            DownloadedString = DownloadedString.Remove(23, 1);
            DownloadedString = DownloadedString.Remove(DownloadedString.Count() - 2, 1);

            Debug.WriteLine("test: " + DownloadedString);
            dynamic result = JsonValue.Parse(DownloadedString);
            //dynamic result = JsonValue.Parse(webclient.DownloadString("E:\\Windows\\Documents\\DM76-gruppe7\\validJson.json"));
            textBox1.Text = result.ToString();
            string test2 = "";
            List<string> foobar = new List<string>();
            for (int i = 0; i < result.shortestRouteResult.Count; i++ )
            {
                test2 = result.shortestRouteResult[i]._street.ToString() + "," + result.shortestRouteResult[i]._streetNo.ToString() + "," + result.shortestRouteResult[i]._zipCode.ToString();
                test2 = test2.Replace("\"", "");
                foobar.Add(test2);
            }
            /*test2 = test2.Substring(0, test2.Length - 1);
            test2 = test2.Replace("\"", "");*/
            
            //string test2 = result.shortestRouteResult[0]._id.ToString();
            Debug.WriteLine("test: "+test2);
            byte[] img = route.GetMapImage(foobar.ToArray(), "denmark", 480, 380, true);
            //byte[] img = webclient.DownloadData("http://maps.googleapis.com/maps/api/staticmap?size=480x380&maptype=roadmap&sensor=false&path="+test2);
            pictureBox1.Image = new Bitmap(new MemoryStream(img));
        }
    }
}
