using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using Dapper;

namespace Capstone.Web.DAL
{
    public class ForecastDAL : IForecastDAL
    {
        private string connectionString;
        private const string SQL_GetForecast = "SELECT * FROM weather WHERE parkCode = @parkCode";
    
        public ForecastDAL (string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ForecastModel> GetForecast(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    List<ForecastModel> forecast = conn.Query<ForecastModel>(SQL_GetForecast, new { parkCode = parkCode}).ToList();
                    return forecast;
                }
            }
            catch (SqlException e)
            {

                throw;
            }
        }
    }
}