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
    public class SubjectService
    {
            public void AddSubject(SubjectMaster subjectMaster)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
                SqlCommand comm = new SqlCommand("AddSubject", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@subjectName", SqlDbType.VarChar));
                comm.Parameters["@subjectName"].Value = subjectMaster.Subject;
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
            public void DeleteSubject(int id)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
                SqlCommand comm = new SqlCommand("DeleteSubject", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@subjectId", SqlDbType.Int));
                comm.Parameters["@subjectId"].Value = id;
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

            public List<SubjectMaster> GetSubjects()
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
                SqlCommand comm = new SqlCommand("ReadSubject", conn);
                List<SubjectMaster> subjects = new List<SubjectMaster>();

                comm.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                comm.ExecuteNonQuery();
                SqlDataReader dataReader = comm.ExecuteReader();

                    while (dataReader.Read())
                    {
                        SubjectMaster subjectMaster = new SubjectMaster();
                        subjectMaster.SubjectId = dataReader.GetInt32(0);
                        subjectMaster.Subject = dataReader.GetString(1);
                        subjects.Add(subjectMaster);
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    conn.Close();
                }
                return subjects;
            }
    }
}