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
    public class ClassService
    {
        public void AddClass(ClassMaster classMaster)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("AddClass", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@className", SqlDbType.VarChar));
            comm.Parameters["@className"].Value = classMaster.Class;
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
        public void DeleteClass (int Id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("DeleteClass", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@classId", SqlDbType.Int));
            comm.Parameters["@classId"].Value = Id;
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

        public List<ClassMaster> GetClasses ()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("ReadClass", conn);
            List<ClassMaster> classes = new List<ClassMaster>();

            comm.CommandType = CommandType.StoredProcedure;
            
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();

                SqlDataReader dataReader = comm.ExecuteReader();

                while (dataReader.Read())
                {
                    ClassMaster classMaster = new ClassMaster();
                    classMaster.Id = dataReader.GetInt32(0);
                    classMaster.Class = dataReader.GetString(1);
                    classes.Add(classMaster);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return classes;
        }
    }
}