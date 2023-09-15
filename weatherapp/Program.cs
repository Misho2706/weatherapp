using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace weatherapp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
           

        }
        public static WeatherService.ServiceClient client = new WeatherService.ServiceClient();
        public static WeatherService.User currUser = new WeatherService.User();
        public static Classes.User loggedUser = new Classes.User();


    }
}
