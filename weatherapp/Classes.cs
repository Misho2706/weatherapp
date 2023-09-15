using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherapp
{
   public class Classes
    {
        public class responseCurr
        {


            public data[] data { get; set; }


        }
        public class data
        {
            public double high_temp { get; set; }
            public double low_temp { get; set; }
            public double app_temp { get; set; }
            public string city_name { get; set; }
            public double clouds { get; set; }
            public string country_code { get; set; }

            public string datetime { get; set; }
            public double rh { get; set; }
            public string sunrise_ts { get; set; }
            public string sunset_ts { get; set; }
            public string timezone { get; set; }
            public weather weather { get; set; }


            public string wind_cdir { get; set; }
            public double wind_spd { get; set; }

        }

        public class weather
        {
            public string description { get; set; }
            public string icon { get; set; }


        }
        public class responseFore
        {
            public string city_name { get; set; }
            public data[] data { get; set; }
        }
        public  class User
        {
            public int id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string mail { get; set; }
            public Nullable<int> role_id { get; set; }
        }
    }
}
