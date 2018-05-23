using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GOOS_Sample.Connection
{
    public class ConnectionFactory
    {
        public IDbConnection CreateConnection(string name = "default")
        {
            switch (name)
            {
                case "default":
                    {
                        var ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                        return new SqlConnection(ConnectionString);
                    }
                default:
                    {
                        throw new Exception("name not exist");
                    }
            }
        }
    }
}