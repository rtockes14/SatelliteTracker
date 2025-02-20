using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatelliteTrackerActual;
using Newtonsoft.Json;

namespace SatTrackerComs
{
    public partial class TrackerUIForm : Form
    {
        private List<SatelliteInfo> savedSatellitesList = new List<SatelliteInfo>();
        private List<Location> savedLocationsList = GlobalConfig.Connection.GetLocations_All();
        //private List<Location> savedLocationsList = new List<Location>();
        public TrackerUIForm()
        {
            InitializeComponent();

            CreateSampleData();

            WireUpLists();

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
                Console.WriteLine("COM 10 doesn't exist.");
            }

            GatherData();
        }

        private void CreateSampleData()
        {
            savedSatellitesList.Add(new SatelliteInfo { SatelliteName = "SPACE STATION", NoradId = 25544, Period = 2457 });
            savedSatellitesList.Add(new SatelliteInfo { SatelliteName = "GOES 13", NoradId = 29155, Period = 1457 });
            savedLocationsList.Add(new Location { Name = "New home", ObserverAltitude = 0, ObserverLat = -55.56141, ObserverLon = 14.33092 });
            savedSatellitesList.Add(new SatelliteInfo { SatelliteName = "NOAA 18", NoradId = 28654, Period = 101 });
            savedLocationsList.Add(new Location { Name = "Country Rd K", ObserverLat = 42.999181, ObserverLon = -89.892574, ObserverAltitude = 10 });
        }

        private void WireUpLists()
        {
            savedSatsListBox.DataSource = null;

            savedSatsListBox.DataSource = savedSatellitesList;
            savedSatsListBox.DisplayMember = "SatelliteName";

            savedLocationDropDown.DataSource = null;

            savedLocationDropDown.DataSource = savedLocationsList;
            savedLocationDropDown.DisplayMember = "Name";
        }


        private void Home_Click(object sender, EventArgs e)
        {
            // send command to arduino to 'Home' Tracker
 
            //var info = new Info();
            //var position = new Position();

            //Console.WriteLine(info.satname + "%ELEV:" + elevationStr + "AZI:" + position.elevation.ToString() + "%LAT:40.92 LNG:-83.20%09-01-24");

            //serialPort1.Write(info.satname + "%ELEV:" + position.elevation + "AZI:" + position.elevation.ToString() +"%LAT:40.92 LNG:-83.20%09-01-24");
        }


        public async Task<SatelliteInfo> FetchSatName(string NoradId)
        {
            SatelliteInfo sat = new SatelliteInfo();
            var parser = new ParseJson();
            var user = new UserInfo();

            sat.NoradId = int.Parse(NoradId);

            var simpleuri = "https://api.n2yo.com/rest/v1/satellite/tle/" + sat.NoradId + "&apiKey=" + user.ApiKey;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,

                RequestUri = new Uri(simpleuri),
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);

                sat.SatelliteName = parser.JMethodString(body);
                sat.NoradId = parser.JMethodDub(body);
                Console.WriteLine("\n\nSat: \t\t" + sat.SatelliteName);
                Console.WriteLine("SatID: \t\t" + sat.NoradId);

                return sat;
            }
        }


        public async void GatherData()
        {
            var user = new UserInfo();
            var satinfo = new SatelliteInfo();
            var parser = new ParseJson();
            var info = new Info();
            var position = new Position();
            var location = new Location();


            satinfo.NoradId = 25544;
            location.ObserverLat = 40.32820;
            location.ObserverLon = -89.234123;
            location.ObserverAltitude = 200;

            while (true)
            {

                // var uri = "https://api.n2yo.com/rest/v1/satellite/tle/" + satinfo.NoradId + "&apiKey=" + user.ApiKey;
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
                        position.sataltitude = Math.Round(items.sataltitude, 2);

                        user.Date = parser.UnixTimeStampToDateTime(position.timestamp);
                        Console.WriteLine("Azimuth: \t" + items.azimuth);
                        Console.WriteLine("Elevation: \t" + items.elevation);
                        Console.WriteLine(user.Date + "\n\n");
                    }

                }

                RelevantData relevantData = new RelevantData(info.satname, info.satid, position.elevation, position.azimuth, position.satlatitude, position.satlongitude, position.sataltitude, user.Date);

                string jsonData = JsonConvert.SerializeObject(relevantData);

                Console.Write("Satellite data in JSON format: ");
                Console.WriteLine(jsonData);
                satelliteLabel.Text = info.satname;
                satelliteLatitudeActual.Text = position.satlatitude.ToString();
                satelliteLongitudeActual.Text = position.satlongitude.ToString();
                satelliteAltitudeActual.Text = $"{position.sataltitude}m";
                satelliteElevationActual.Text = position.elevation.ToString();
                satelliteAzimuthActual.Text = $"{position.azimuth}";

                try
                {
                    //serialPort1.Write("SAT: " + info.satname + "%ELV:" + position.elevation + " $AZI:" + position.azimuth + "%LAT:" + position.satlatitude + "#LNG:" + position.satlongitude + "%" + user.Date);
                    serialPort1.WriteLine(jsonData);
                    Console.WriteLine("Sensor data sent over USB");
                }
                catch
                {
                    Console.WriteLine("Error Communicating with device or COM port closed");
                }

                //Console.WriteLine("SATELLITE: " + info.satname + "\tELEVATION: " + position.elevation + "\tAZIMUTH: " + position.azimuth + "\tLATITUDE: " + position.satlatitude + "\tLONGITUDE: " + position.satlongitude + "\tTIME: " + user.Date);

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

        private bool ValidateSatelliteIDForm()
        {
            if (newSatelliteIDBox.Text.Length < 5)
            {
                return false;
            }
            return true;
        }

        private async void addSatelliteIDButton_Click(object sender, EventArgs e)
        {
            if (ValidateSatelliteIDForm())
            {
                var model = await FetchSatName(newSatelliteIDBox.Text);
                // Debugging help
                Console.WriteLine(model);

                savedSatellitesList.Add(model);

                foreach (var sat in savedSatellitesList)
                {
                    Console.Write(sat.SatelliteName);
                }
                //satellite.SatelliteName = model.SatelliteName;
                GlobalConfig.Connection.AddSatelliteInfo(model);

                newSatelliteIDBox.Text = "";
            }
            else
            {
                MessageBox.Show("Enter a valid Norad ID");
            }

            WireUpLists();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void saveUserLocationLabel_Click(object sender, EventArgs e)
        {

        }

        private void userSavedLocationLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
