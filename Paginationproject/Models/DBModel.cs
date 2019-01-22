using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Paginationproject.Models
{
    public class DBModel
    {
        public SqlConnection DBconnection()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Constring"].ConnectionString);
            return connection;
        }
    }
    
}