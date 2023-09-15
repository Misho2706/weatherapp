using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace weatherapp
{
    public partial class Forget : Form
    {
        public Forget()
        {
            InitializeComponent();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {

            try
            {
                 HttpClient httpClient = new HttpClient();
            string url = $"https://localhost:44337/api/auth/validate?mail={txtmail.Text}";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Classes.User resultUser = JsonConvert.DeserializeObject<Classes.User>(responseBody);
                    if(resultUser is null)
                    {
                        MessageBox.Show("user not found");
                    }
                    else
                    {

                        
                        string url_ = $"https://localhost:44337/api/auth/sendmail?toEmail={txtmail.Text}&username={resultUser.username}&password={resultUser.password}";
                        response = await httpClient.GetAsync(url_);
                        if(response.IsSuccessStatusCode)
                        {
                            string responseBody_ = await response.Content.ReadAsStringAsync();
                            if (responseBody_ == "true")
                            {
                                MessageBox.Show("email sent! check your inbox");
                                this.Hide();
                            }
                        }

                        
                        
                    }

                }
                
               
                
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(""))
                {
                    
                }
                MessageBox.Show(ex.Message);
                return;
            }

        }
    }
}
