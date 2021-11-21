using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LabSch.DAL
{
    public class Db
    {
        public static SqlConnection getConnection()
        {
            String connStr = ConfigurationManager.ConnectionStrings["LabDb"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}