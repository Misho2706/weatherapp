using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace weatherapp
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
            rememberMe();
            progressPanel.Hide();
        }

        public static String GetIP()
        {
            
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            string ip = localIPs[4].ToString();

            return ip;
        }

        public String GetMAC()
        {
            string macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                              where nic.OperationalStatus == OperationalStatus.Up
                              select nic.GetPhysicalAddress().ToString()
                              ).FirstOrDefault();

            return macAddr;
        }


        public async void LoginBtn_ClickAsync(object sender, EventArgs e)
        {
            progressPanel.Show();
            HttpClient httpClient = new HttpClient();
            string url = "https://localhost:44337/api/auth/login?usernametxt=@usr&passwordtxt=@pwd&rememberMe=@t";
            url = url.Replace("@usr", Usernametxt.Text);
            url = url.Replace("@pwd", Passwordtxt.Text);
            url = url.Replace("@t", RememberMe.Checked.ToString());
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    StreamReader streamReader = new StreamReader(responseBody);
                    var result = streamReader.ReadToEnd();
                    Program.loggedUser = JsonConvert.DeserializeObject<Classes.User>(result);
                    streamReader.Close();
                    streamReader.Dispose();

                    if(Program.loggedUser != null)
                    {
                        Main weatherForm = new Main();
                        weatherForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("username or password is incorrect");
                    }
                    
                }
                else
                {
                    MessageBox.Show("pizdec");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            progressPanel.Hide();
        }


        public async void RegBtn_Click(object sender, EventArgs e)
        {
            progressPanel.Show();
            HttpClient httpClient = new HttpClient();
            string url = $"https://localhost:44337/api/auth/register?usernametxt={Usernametxt.Text}&passwordtxt={Passwordtxt.Text}&mail={txtemail.Text}";
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseText = await response.Content.ReadAsStringAsync();

                    if (responseText == "true")
                    {
                        MessageBox.Show("registration succesful");
                    }
                    else
                    {
                        MessageBox.Show("user already exists");
                    }



                }
                else
                {
                    MessageBox.Show("pizdec");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            progressPanel.Hide();
        }

        public void rememberMe()
        {
            StreamReader reader = new StreamReader(@"C:\Users\1\Desktop\rememberme.txt");
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                Usernametxt.Text = line;
                line = reader.ReadLine();
                Passwordtxt.Text = line;
            }
            reader.Close();
            reader.Dispose();
        }
        private void RememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void forget_Click(object sender, EventArgs e)
        {
            progressPanel.Show();
            Forget newform = new Forget();
            newform.Show();
            progressPanel.Hide();
        }

        static HttpClient client = new HttpClient();
       
    }
}
