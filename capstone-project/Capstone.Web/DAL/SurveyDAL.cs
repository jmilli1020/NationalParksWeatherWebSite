﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using Dapper;


namespace Capstone.Web.DAL
{
    public class SurveyDAL : ISurveyDAL
    {
        public string ConnectionString;

        public SurveyDAL (string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private const string SQL_SaveSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) " +
            "VALUES (@parkCode, @emailAddress, @state, @activity)";
        private const string SQL_GetCount = "SELECT COUNT(*) FROM survey_result WHERE parkCode = @parkCode";

        public void SaveSurvey (SurveyViewModel survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                   survey.Survey.SurveyId = conn.Query<int>(SQL_SaveSurvey, new
                    {
                        parkCode = survey.Park.ParkCode,
                        emailAddress = survey.Survey.EmailAddress,
                        state = survey.Survey.State,
                        activity = survey.Survey.Activity
                    }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public int SurveyCount (string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    int count = conn.ExecuteScalar<int>(SQL_GetCount, new
                    {
                        parkCode = parkCode
                    });
                    return count;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}