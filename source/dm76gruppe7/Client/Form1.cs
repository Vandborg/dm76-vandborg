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
            book.Enabled = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string BingAPIKey = "AmIg7-bIkZHBKjzOkUbceNBzNeyXEus9-sJhyh0_7kczHKUoQTSaa-z7c9vSEM2f";
            WebClient webclient = new WebClient();
            webclient.Encoding = System.Text.Encoding.UTF8;

            if (fromStreet.Text != "" && toStreet.Text != "" && fromStreetNo.Text != "" && toStreetNo.Text != "" && fromZipCode.Text != "" && toZipCode.Text != "")
            {
                //map.ImageLocation = @"..\..\ajax-loader.gif";
                //map.SizeMode = PictureBoxSizeMode.CenterImage;
                string fromLocation = fromStreet.Text + "-" + fromStreetNo.Text;

                if (fromFloor.Text != "")
                {
                    fromLocation += "_" + fromFloor.Text;
                }

                if (fromSide.Text != "")
                {
                    fromLocation += "_" + fromSide.Text;
                }

                fromLocation += "-" + fromZipCode.Text;

                string toLocation = toStreet.Text + "-" + toStreetNo.Text;

                if (toFloor.Text != "")
                {
                    toLocation += "_" + toFloor.Text;
                }

                if (toSide.Text != "")
                {
                    toLocation += "_" + toSide.Text;
                }

                toLocation += "-" + toZipCode.Text;
                try
                {
                    string DownloadedString = webclient.DownloadString("http://localhost:3108/RemoteRoutePlanner.svc/shortestRoute/" + fromLocation + "/" + toLocation);

                    //Done because WCF is adding escape chars. It is a default behavior and is apparently mandatory. And therefore it's not valid JSON.
                    DownloadedString = DownloadedString.Replace("\\", "");
                    DownloadedString = DownloadedString.Remove(23, 1);
                    DownloadedString = DownloadedString.Remove(DownloadedString.Count() - 2, 1);

                    Debug.WriteLine("test: " + DownloadedString);
                    dynamic result = JsonValue.Parse(DownloadedString);
                    string AddressesString = "";
                    for (int i = 0; i < result.shortestRouteResult.Count; i++)
                    {
                        AddressesString += "wp." + i.ToString() + "=" + result.shortestRouteResult[i]._street.ToString() + "," + result.shortestRouteResult[i]._streetNo.ToString() + "," + result.shortestRouteResult[i]._zipCode.ToString() + ",denmark&";
                    }
                    AddressesString = AddressesString.Replace("\"", "");
                    byte[] img = webclient.DownloadData("http://dev.virtualearth.net/REST/v1/Imagery/Map/Road/Routes?ms=480,380&" + AddressesString + "key=" + BingAPIKey);
                    map.Image = new Bitmap(new MemoryStream(img));
                    book.Enabled = true;
                }
                catch (Exception ee)
                {
                    //map.ImageLocation = @"..\..\defaultmap.png";
                    DialogResult dlgRes = MessageBox.Show(
                    ee.ToString(),
                    "Fejl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
                    Debug.WriteLine("Error in creating route: " + ee.ToString());
                }
            }
            else
            {
                //map.ImageLocation = @"..\..\defaultmap.png";
                DialogResult dlgRes = MessageBox.Show(
                "Du har ikke udfyldt formen.", 
                "Husk!", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Question);
            }
        }
    }
}
