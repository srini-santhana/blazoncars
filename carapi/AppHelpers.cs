using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carapi
{
    public class AppHelpers
    {
        public static string carconn
        {
            get
            {
                if (System.Configuration.ConfigurationManager.AppSettings["carconn"] != null)
                { return System.Configuration.ConfigurationManager.AppSettings["carconn"].ToString(); }
                else
                { return string.Empty; }
            }
        }
    }
}

 