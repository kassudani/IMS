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
    public class UserService
    {
        public void AddUser(UserMaster userMaster)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("AddUser", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar));
            comm.Parameters.Add(new SqlParameter("@userDesignationId", SqlDbType.Int));
            comm.Parameters.Add(new SqlParameter("@contact1", SqlDbType.BigInt));
            comm.Parameters.Add(new SqlParameter("@contact2", SqlDbType.BigInt));
            comm.Parameters.Add(new SqlParameter("@qualification", SqlDbType.VarChar));
            comm.Parameters.Add(new SqlParameter("@totalPayment", SqlDbType.BigInt));
            comm.Parameters.Add(new SqlParameter("@joiningDate", SqlDbType.Date));
            comm.Parameters.Add(new SqlParameter("@worktype", SqlDbType.VarChar));
            comm.Parameters.Add(new SqlParameter("@batch", SqlDbType.VarChar));

            comm.Parameters["@fullName"].Value = userMaster.FullName;
            comm.Parameters["@userDesignationId"].Value = userMaster.UserDesignationId;
            comm.Parameters["@contact1"].Value = userMaster.ContactNumber.Contact1;
            comm.Parameters["@contact2"].Value = userMaster.ContactNumber.Contact2;
            comm.Parameters["@qualification"].Value = userMaster.Qualification;
            comm.Parameters["@totalPayment"].Value = userMaster.TotalPayment;
            comm.Parameters["@joiningDate"].Value = userMaster.JoiningDate;
            comm.Parameters["@worktype"].Value = userMaster.Worktype;
            comm.Parameters["@batch"].Value = userMaster.Batch;

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
        public void InactiveUser(int Id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("InactiveUser", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
            comm.Parameters["@userId"].Value = Id;
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

        public List<UserMaster> GetUsers()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("ReadUsers", conn);
            List<UserMaster> users = new List<UserMaster>();

            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();

                SqlDataReader dataReader = comm.ExecuteReader();

                while (dataReader.Read())
                {
                    UserMaster userMaster = new UserMaster();
                    userMaster.UserId = dataReader.GetInt32(0);
                    userMaster.FullName = dataReader.GetString(1);
                    userMaster.TotalPayment = dataReader.GetInt64(5);
                    userMaster.IsUserActive = dataReader.GetString(10);
                    users.Add(userMaster);
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return users;
        }
    }
}