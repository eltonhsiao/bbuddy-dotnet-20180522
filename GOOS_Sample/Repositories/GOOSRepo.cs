using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using GOOS_Sample.Connection;
using GOOS_Sample.Controllers;
using GOOS_Sample.Interface;
using GOOS_Sample.Models;

namespace GOOS_Sample.Repositories
{
    public class GOOSRepo : IGOOSRepo
    {
        private ConnectionFactory _connectionFactory { get; set; }

        public int AddBudget(Budget budget)
        {
            var connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var cn = new SqlConnection(connectionString);
            cn.Open();

            var result = cn.Query<int>("INSERT INTO Budgets (YearMonth, Amount) VALUES (@month, @amount)",
                new
                {
                    Month = budget.YearMonth,
                    budget.Amount
                });

            return result.FirstOrDefault();
        }

        public List<Budget> GetAllBudgets()
        {
            var connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var cn = new SqlConnection(connectionString);
            cn.Open();

            var result = cn.Query<Budget>("SELECT * FROM Budgets").ToList();

            cn.Close();
            return result;
        }

        public void UpdateBudget(Budget budget)
        {
            var connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var cn = new SqlConnection(connectionString);
            cn.Open();

            var result = cn.Query<Budget>("UPDATE Budgets SET Amount = @amount WHERE YearMonth = @month",
                new { Month = budget.YearMonth, budget.Amount }).ToList();

            cn.Close();
            //return result;
        }

        public List<Budget> GetTotalBudgetByTimeRange(DateRange dateRange)
        {
            var connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var cn = new SqlConnection(connectionString);
            cn.Open();

            var result = cn.Query<Budget>("SELECT * FROM Budgets WHERE YearMonth >= @start AND YearMonth <= @end",
                new { start = dateRange.Start.ToString("yyyy-MM"), end = dateRange.End.ToString("yyyy-MM") }).ToList();

            return result;
        }
    }
}