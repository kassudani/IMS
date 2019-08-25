using InstituteManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Services
{
    public class DesignationService
    {
        public void AddDesignation(DesignationMaster designationMaster)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("AddDesignation", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@designationName", SqlDbType.VarChar));
            comm.Parameters["@designationName"].Value = designationMaster.Designation;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
        }
        public void DeleteDesignation(int DesignationId)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("DeleteDesignation", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@designationId", SqlDbType.Int));
            comm.Parameters["@designationId"].Value = DesignationId;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public List<DesignationMaster> GetDesignation()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("ReadDesignation", conn);
            List<DesignationMaster> designations = new List<DesignationMaster>();

            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                SqlDataReader dataReader = comm.ExecuteReader();

                while (dataReader.Read())
                {
                    DesignationMaster designationMaster = new DesignationMaster();
                    designationMaster.DesignationId = dataReader.GetInt32(0);
                    designationMaster.Designation = dataReader.GetString(1);
                    designations.Add(designationMaster);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return designations;
        }
    }
}