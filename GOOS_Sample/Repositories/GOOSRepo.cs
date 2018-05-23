using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using GOOS_Sample.Connection;
using GOOS_Sample.Interface;
using GOOS_Sample.Models;

namespace GOOS_Sample.Repositories
{
    public class GOOSRepo : IGOOSRepo
    {
        private ConnectionFactory _connectionFactory { get; set; }

        public int SaveBudget(Budgets budget)
        {
            var ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var cn = new SqlConnection(ConnectionString);
            cn.Open();

            var result = cn.Query<int>("INSERT INTO Budgets (YearMonth, Amount) VALUES (@month, @amount)",
                new { budget.Month, budget.Amount }).First();

            return result;
        }
    }
}