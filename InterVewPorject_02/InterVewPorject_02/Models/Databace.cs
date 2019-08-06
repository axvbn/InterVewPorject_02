using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace InterVewPorject_02.Models
{
    public  class Databace
    {
        public string GetConnect()
        {
            string connect = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            return connect;
        }
    }
}