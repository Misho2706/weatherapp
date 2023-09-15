
using System.Linq;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;

namespace weatherapp
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {

            InitializeComponent();
            IsAdmin();
            hidepanels();
            loadImages();

            MainMethodCurr("tbilisi", false);
            MainMethodFore("tbilisi", false);

        }
        
        public void loadImages()
        {
            humcion.Load(@"C:\projects\weatherapp\weatherapp\Resources\humidityicon.png");
            humicon1.Load(@"C:\projects\weatherapp\weatherapp\Resources\humidityicon.png");
            humicon2.Load(@"C:\projects\weatherapp\weatherapp\Resources\humidityicon.png");
            humicon3.Load(@"C:\projects\weatherapp\weatherapp\Resources\humidityicon.png");
            humicon4.Load(@"C:\projects\weatherapp\weatherapp\Resources\humidityicon.png");
            windicon.Load(@"C:\projects\weatherapp\weatherapp\Resources\windicon.png");
            rainicon.Load(@"C:\projects\weatherapp\weatherapp\Resources\927915-200.png");
        }

        public async void IsAdmin()
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44337/api/auth/verifyadmin";
            var requestBody = JsonConvert.SerializeObject(Program.loggedUser);
            StringContent content = new StringContent(requestBody,  Encoding.UTF8, "application/json");
                           
            var response = await client.PostAsync(url, content);
            string isAdmin = await response.Content.ReadAsStringAsync();





            if (isAdmin == "true")
            {
                HistoryBtn.Enabled = true;
            }
            else
            {
                HistoryBtn.Enabled = true;
            }
        }





        public string convertUnitsMeters(string str)
        {
            if (!toggleSwitchUnits.IsOn)
            {

                str = str + " m/s";
            }
            else
            {
                str = str + " m/ph";
            }
            return str;
        }

        public void hidepanels()
        {
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        public void DispResCurr(Classes.responseCurr res)
        {
            var result = res.data[0];

            string image = @"C:\projects\weatherapp\weatherapp\Resources\@ex";
            image = image.Replace("@ex", result.weather.icon + ".png");
            currentimage.Load(image);
            condition.Text = result.weather.description;
            cityname.Text = result.city_name;
            today.Text = DateTime.Today.DayOfWeek.ToString() + " : ";
            humidityval.Text = result.clouds.ToString() + " %";
            chanceval.Text = result.rh.ToString() + " %";
            temp.Text = convertUnitsTemp(result.app_temp.ToString(), toggleSwitchUnits.IsOn);
            windspdval.Text = convertUnitsMeters(result.wind_spd.ToString());

        }

        public void DispResFore(Classes.responseFore res)
        {
            DateTime today = DateTime.Today;
            var result1 = res.data[0];
            var result2 = res.data[1];
            var result3 = res.data[2];
            var result4 = res.data[3];
            string image = @"C:\projects\weatherapp\weatherapp\Resources\@ex";
            image = image.Replace("@ex", result1.weather.icon + ".png");
            iconfore1.Load(image);
            image = image.Replace("@ex", result2.weather.icon + ".png");
            iconfore2.Load(image);
            image = image.Replace("@ex", result3.weather.icon + ".png");
            iconfore3.Load(image);
            image = image.Replace("@ex", result4.weather.icon + ".png");
            iconfore4.Load(image);
            day1.Text = today.AddDays(1).DayOfWeek.ToString();
            day2.Text = today.AddDays(2).DayOfWeek.ToString();
            day3.Text = today.AddDays(3).DayOfWeek.ToString();
            day4.Text = today.AddDays(4).DayOfWeek.ToString();

            mintmpval1.Text = convertUnitsTemp(result1.low_temp.ToString(), toggleSwitchUnits.IsOn);
            mintmpval2.Text = convertUnitsTemp(result2.low_temp.ToString(), toggleSwitchUnits.IsOn);
            mintmpval3.Text = convertUnitsTemp(result3.low_temp.ToString(), toggleSwitchUnits.IsOn);
            mintmpval4.Text = convertUnitsTemp(result4.low_temp.ToString(), toggleSwitchUnits.IsOn);

            maxtmpval1.Text = convertUnitsTemp(result1.high_temp.ToString(), toggleSwitchUnits.IsOn);
            maxtmpval2.Text = convertUnitsTemp(result2.high_temp.ToString(), toggleSwitchUnits.IsOn);
            maxtmpval3.Text = convertUnitsTemp(result3.high_temp.ToString(), toggleSwitchUnits.IsOn);
            maxtmpval4.Text = convertUnitsTemp(result4.high_temp.ToString(), toggleSwitchUnits.IsOn);

            sunset1val.Text = UnixSecondsToDateTime(Convert.ToInt64(result1.sunset_ts), false).AddHours(4).ToString("HH:mm");
            sunset2val.Text = UnixSecondsToDateTime(Convert.ToInt64(result2.sunset_ts), false).AddHours(4).ToString("HH:mm");
            sunsetval3.Text = UnixSecondsToDateTime(Convert.ToInt64(result3.sunset_ts), false).AddHours(4).ToString("HH:mm");
            sunsetval4.Text = UnixSecondsToDateTime(Convert.ToInt64(result4.sunset_ts), false).AddHours(4).ToString("HH:mm");
            sunrise1val.Text = UnixSecondsToDateTime(Convert.ToInt64(result1.sunrise_ts), false).AddHours(4).ToString("HH:mm");
            sunrise2val.Text = UnixSecondsToDateTime(Convert.ToInt64(result2.sunrise_ts), false).AddHours(4).ToString("HH:mm");
            sunriseval3.Text = UnixSecondsToDateTime(Convert.ToInt64(result3.sunrise_ts), false).AddHours(4).ToString("HH:mm");
            sunriseval4.Text = UnixSecondsToDateTime(Convert.ToInt64(result4.sunrise_ts), false).AddHours(4).ToString("HH:mm");
            humidity1val.Text = result1.rh.ToString() + "%";
            humidityval2.Text = result2.rh.ToString() + "%";
            humidityval3.Text = result3.rh.ToString() + "%";
            humidityval4.Text = result4.rh.ToString() + "%";


        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            timer1_Tick(sender, e);
            datetoday.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            datetoday.AutoScrollOffset = Point.Empty;

        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            currtime.Text = DateTime.Now.ToLongTimeString();
        }

        private void city_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MainMethodCurr(txtcity.Text, toggleSwitchUnits.IsOn);

                MainMethodFore(txtcity.Text, toggleSwitchUnits.IsOn);

            }
        }

        private void change_theme_Click(object sender, EventArgs e)
        {
            //DispResCurr(Program.client.MainMethodCurr(txtcity.Text, toggleSwitchUnits.IsOn));
           // DispResFore(Program.client.MainMethodFore(txtcity.Text, toggleSwitchUnits.IsOn));

        }

        private void themeswitch_Toggled(object sender, EventArgs e)
        {
            Image nightImage = new Bitmap(@"C:\projects\weatherapp\weatherapp\Resources\night.JPG");
            Image dayImage = new Bitmap(@"C:\projects\weatherapp\weatherapp\Resources\day.JPG");
            if (themeswitch.IsOn == true)
            {

                this.BackgroundImage = nightImage;
                currtime.ForeColor = Color.White;
            }
            else
            {
                this.BackgroundImage = dayImage;
                currtime.ForeColor = Color.DarkGray;
            }

        }



        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
          //  MainMethodCurr(txtcity.Text, toggleSwitchUnits.IsOn);
          //   MainMethodFore(txtcity.Text, toggleSwitchUnits.IsOn);
        }

        private void panelControl1_MouseHover(object sender, EventArgs e)
        {
            panel5.Visible = true;

        }

        private void panelControl2_MouseHover(object sender, EventArgs e)
        {
            panel6.Visible = true;


        }

        private void panelControl3_MouseHover(object sender, EventArgs e)
        {
            panel7.Visible = true;

        }

        private void panelControl4_MouseHover(object sender, EventArgs e)
        {
            panel8.Visible = true;

        }

        private void panelControl1_MouseLeave(object sender, EventArgs e)
        {
            panel5.Visible = false;

        }

        private void panelControl2_MouseLeave(object sender, EventArgs e)
        {
            panel6.Visible = false;

        }

        private void panelControl3_MouseLeave(object sender, EventArgs e)
        {
            panel7.Visible = false;

        }

        private void panelControl4_MouseLeave(object sender, EventArgs e)
        {
            panel8.Visible = false;





        }

        private void HistoryBtn_Click(object sender, EventArgs e)
        {
            Request_History history = new Request_History();
            history.Show();
        }

        public static WebRequest GetWeatherInfo(string url, string post_get)
        {
            WebRequest request = null;
            try
            {
                request = WebRequest.Create(url);
                request.PreAuthenticate = true;
                request.Method = post_get;
                request.ContentType = "application/json; charset=utf-8";
            }

            catch //(Exception ex)
            {
            }
            return request;
        }

        public Classes.responseCurr MainMethodCurr(string city, bool toggleSwitchUnits)
        {

            string urlCurr = "https://localhost:44337/api/weather/getcurrent?city=@tbilisi&ImperialUnits=@false";

            urlCurr = urlCurr.Replace("@tbilisi", city);
            if (toggleSwitchUnits == true)
            {
                urlCurr = urlCurr.Replace("@false", "true");

            }
            else
            {
                urlCurr = urlCurr.Replace("@false", "false");

            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            WebRequest requestCurr = GetWeatherInfo(urlCurr, "get");

            var WebResponseCurr = (HttpWebResponse)requestCurr.GetResponse();

            if (WebResponseCurr.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReaderCurr = new StreamReader(WebResponseCurr.GetResponseStream()))
                {
                    var resultCurr = streamReaderCurr.ReadToEnd();
                    Classes.responseCurr resCurr = JsonConvert.DeserializeObject<Classes.responseCurr>(resultCurr);
                    streamReaderCurr.Close();
                    streamReaderCurr.Dispose();

                    WebResponseCurr.Close();
                    if (resCurr == null)
                    {
                        //MessageBox.Show("city not found");

                        return null;
                    }
                    //DispResCurr(resCurr);
                    DispResCurr(resCurr);

                    return resCurr;
                }

            }
            else
            {
                return null;
            }

            


        }

        public Classes.responseFore MainMethodFore(string city, bool toggleSwitchUnits)
        {
            string urlFore = "https://localhost:44337/api/weather/getforecast?city=@tbilisi&ImperialUnits=@false";
            if (toggleSwitchUnits == true)
            {
                urlFore = urlFore.Replace("@false", "true");

            }
            else
            {
                urlFore = urlFore.Replace("@false", "false");

            }

            urlFore = urlFore.Replace("@tbilisi", city);

            WebRequest requestFore = GetWeatherInfo(urlFore, "get");

            var WebResponseFore = (HttpWebResponse)requestFore.GetResponse();

            if (WebResponseFore.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReaderFore = new StreamReader(WebResponseFore.GetResponseStream()))
                {
                    var resultFore = streamReaderFore.ReadToEnd();
                    Classes.responseFore resFore = JsonConvert.DeserializeObject<Classes.responseFore>(resultFore);
                    streamReaderFore.Close();
                    streamReaderFore.Dispose();
                    WebResponseFore.Close();

                    DispResFore(resFore);
                    
                    return resFore;

                }

            }
            else
            {
                return null;
            }
        }
        public DateTime UnixSecondsToDateTime(long timestamp, bool local = false)
        {
            var offset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            return local ? offset.LocalDateTime : offset.UtcDateTime;
        }



        public string convertUnitsTemp(string str, bool toggleSwitchUnits)
        {
            if (!toggleSwitchUnits == true)
            {
                str = str + "C";

            }
            else
            {
                str = str + "F";

            }
            return str;
        }
    }
}
