using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatelliteTrackerActual;

namespace SatTrackerComs
{
    public partial class TrackerUIForm : Form
    {
        public TrackerUIForm()
        {
            InitializeComponent();



            locationNameBox.Text = "";
            userLatitudeBox.Text = "0.000";
            userLongitudeBox.Text = "0.000";
            userAltitudeBox.Text = "0.0";

            try
            {
                serialPort1.Open();

            }
            catch
            {
                Console.WriteLine("COM 16 doesn't exist.");
            }

            //GatherData();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            // send command to arduino to 'Home' Tracker
 
            //var info = new Info();
            //var position = new Position();

            //Console.WriteLine(info.satname + "%ELEV:" + elevationStr + "AZI:" + position.elevation.ToString() + "%LAT:40.92 LNG:-83.20%09-01-24");

            //serialPort1.Write(info.satname + "%ELEV:" + position.elevation + "AZI:" + position.elevation.ToString() +"%LAT:40.92 LNG:-83.20%09-01-24");
        }


        public async void GatherData()
        {
            var user = new UserInfo();
            var satinfo = new SatelliteInfo();
            var parser = new ParseJson();
            var info = new Info();
            var position = new Position();
            var location = new Location();

            while (true)
            {
                //satinfo.NoradId = 25544;
                //location.ObserverLat = 43.019101;
                //location.ObserverLon = -89.329832;
                //location.ObserverAltitude = 400;

                var uri = "https://api.n2yo.com/rest/v1/satellite/tle/" + satinfo.NoradId + "&apiKey=" + user.ApiKey;
                var uri2 = "https://api.n2yo.com/rest/v1/satellite/positions/" + satinfo.NoradId + "/" + location.ObserverLat + "/" + location.ObserverLon + "/" + location.ObserverAltitude + "/" + 1 + "/&apiKey=" + user.ApiKey;

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,

                    RequestUri = new Uri(uri2),
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);

                    info.satname = parser.JMethodString(body);
                    info.satid = parser.JMethodDub(body);
                    var list = parser.JMethodList(body);
                    Console.WriteLine("\n\nSat: \t\t" + info.satname);
                    Console.WriteLine("SatID: \t\t" + info.satid);

                    foreach (var items in list)
                    {
                        position.azimuth = Math.Round(items.azimuth, 1);
                        position.elevation = Math.Round(items.elevation, 1);
                        position.timestamp = items.timestamp;

                        position.satlatitude = Math.Round(items.satlatitude, 2);
                        position.satlongitude = Math.Round(items.satlongitude, 1);

                        user.Date = parser.UnixTimeStampToDateTime(position.timestamp);
                        Console.WriteLine("Azimuth: \t" + items.azimuth);
                        Console.WriteLine("Elevation: \t" + items.elevation);
                        Console.WriteLine(user.Date + "\n\n");
                    }

                }

                try
                {
                    serialPort1.Write("SAT: " + info.satname + "%ELV:" + position.elevation + " $AZI:" + position.azimuth + "%LAT:" + position.satlatitude + "#LNG:" + position.satlongitude + "%" + user.Date);
                }
                catch
                {
                    Console.WriteLine("Error Communicating with device or COM port closed");
                }

                Console.WriteLine("SATELLITE: " + info.satname + "\tELEVATION: " + position.elevation + "\tAZIMUTH: " + position.azimuth + "\tLATITUDE: " + position.satlatitude + "\tLONGITUDE: " + position.satlongitude + "\tTIME: " + user.Date);

                Thread.Sleep(5000);
            }
        }

        // Counter Clockwise rotation
        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("A");

        }

        // Clockwise rotation
        private void button3_Click(object sender, EventArgs e)
        {

        }

        // Elevation up
        private void button4_Click(object sender, EventArgs e)
        {

        }

        // Elevation down
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void userLatitudeLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void saveUserLocationButton_Click(object sender, EventArgs e)
        {
            if (ValidateLocationForm())
            {
                Location model = new Location(
                    locationNameBox.Text, 
                    userLatitudeBox.Text, 
                    userLongitudeBox.Text, 
                    userAltitudeBox.Text);
                    
                GlobalConfig.Connection.AddLocationInfo(model);
                

                locationNameBox.Text = "";
                userLatitudeBox.Text = "0.000";
                userLongitudeBox.Text = "0.000";
                userAltitudeBox.Text = "0.0";

                
            }
            else
            {
                MessageBox.Show("This form has invalid information.  Please enter correct details");
            }
        }

        private bool ValidateLocationForm()
        { 
            bool output = true;
            string locationName = locationNameBox.Text;
            double userLatitude = 0;
            double userLongitude = 0;
            bool userLatitudeValidNumber = double.TryParse(userLatitudeBox.Text, out userLatitude);
            bool userLongitudeValidNumber = double.TryParse(userLongitudeBox.Text, out userLongitude);

            if (locationName.Length > 15 || string.IsNullOrEmpty(locationName))
            {
                output = false;
            }

            if (userLatitudeValidNumber == false || userLongitudeValidNumber == false)
            {
                output = false;
            }

            if (userLongitude <= 0 && userLatitude <= 0)
            {
                output = false;
            }

            return output;

        }
    }
}
