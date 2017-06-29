using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using Dapper;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParkDAL : IParkDAL
    {
        private string ConnectionString;

        public ParkDAL (string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private const string SQL_GetAllParks = "SELECT * FROM park";
        private const string SQL_GetPark = "SELECT * FROM park WHERE parkCode = @parkCode";


        public List<ParkModel> GetAllParks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    List<ParkModel> parks = conn.Query<ParkModel>(SQL_GetAllParks).ToList();
                    return parks;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public ParkModel GetPark(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    ParkModel park = conn.QueryFirstOrDefault<ParkModel>(SQL_GetPark, new { parkCode = parkCode });
                    return park;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}