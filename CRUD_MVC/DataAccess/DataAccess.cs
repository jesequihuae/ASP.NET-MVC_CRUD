using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_MVC.Models.DataAccess
{
    public class DataAccess
    {

        private string getConnection()
        {
            return ConfigurationManager.ConnectionStrings["UniversityConnection"].ToString();
        }

        public DataTable executeStoredProcedureDataTable(string spName)
        {
            SqlConnection dbConn = new SqlConnection(getConnection());
            SqlCommand cmd = new SqlCommand(spName, dbConn);

            SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
            DataTable dtx = new DataTable();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1000;

            try
            {
                dbConn.Open();
                sqlAdp.Fill(dtx);
                dbConn.Close();
                return dtx;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dbConn.State != ConnectionState.Closed)
                {
                    dbConn.Close();
                }
            }
        }

        public DataTable executeStoredProcedureDataTable(String StoredProcedure, Dictionary<String, Object> Parameters)
        {
            SqlConnection dbConn = new SqlConnection(getConnection());
            SqlCommand cmd = new SqlCommand(StoredProcedure, dbConn);

            SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
            DataTable dtx = new DataTable();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1000;

            foreach (string item in Parameters.Keys)
            {
                cmd.Parameters.AddWithValue(item, Parameters[item]);
            }

            try
            {
                dbConn.Open();
                sqlAdp.Fill(dtx);
                dbConn.Close();
                return dtx;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dbConn.State != ConnectionState.Closed)
                {
                    dbConn.Close();
                }
            }
        }
    }
}