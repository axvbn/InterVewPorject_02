using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterVewPorject_02.Models
{
    public class M_Index : Databace
    {
        public string Query()
        {
            string strJson = string.Empty;
            DataTable dtResult = new DataTable();
            using (SqlConnection conn = new SqlConnection(GetConnect()))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "Select CategoryID,CategoryName,Description from Categories ";
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtResult);
                    sda.Dispose();
                    strJson = JsonConvert.SerializeObject(dtResult, Formatting.Indented);
                }
            }

            return strJson;
        }
    }
}