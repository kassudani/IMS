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
    public class StudentService
    {
        public void AddStudent(StudentMaster studentMaster)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("AddStudent", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@firstName", SqlDbType.VarChar));
            comm.Parameters.Add(new SqlParameter("@middleName", SqlDbType.VarChar));
            comm.Parameters.Add(new SqlParameter("@lastName", SqlDbType.VarChar));
            comm.Parameters.Add(new SqlParameter("@dateOfBirth", SqlDbType.Date));
            comm.Parameters.Add(new SqlParameter("@studentClassId", SqlDbType.Int));
            comm.Parameters.Add(new SqlParameter("@subject", SqlDbType.VarChar));
            comm.Parameters.Add(new SqlParameter("@school", SqlDbType.VarChar));
            comm.Parameters.Add(new SqlParameter("@gender", SqlDbType.VarChar));
            comm.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar));
            comm.Parameters.Add(new SqlParameter("@contact1", SqlDbType.BigInt));
            comm.Parameters.Add(new SqlParameter("@contact2", SqlDbType.BigInt));
            comm.Parameters.Add(new SqlParameter("@totalFees", SqlDbType.BigInt));
            comm.Parameters.Add(new SqlParameter("@numberOfInstallments", SqlDbType.Int));
            comm.Parameters.Add(new SqlParameter("@dateOfAdmission", SqlDbType.Date));

            comm.Parameters["@firstName"].Value = studentMaster.FirstName;
            comm.Parameters["@middleName"].Value = studentMaster.MiddleName;
            comm.Parameters["@lastName"].Value = studentMaster.LastName;
            comm.Parameters["@dateOfBirth"].Value = studentMaster.DateofBirth;
            comm.Parameters["@gender"].Value = studentMaster.Gender;
            comm.Parameters["@studentClassId"].Value = studentMaster.StudentClassId;
            comm.Parameters["@subject"].Value = studentMaster.StudentSubjectIds;
            comm.Parameters["@school"].Value = studentMaster.School;
            comm.Parameters["@address"].Value = studentMaster.StudentAddressId.Address;
            comm.Parameters["@contact1"].Value = studentMaster.StudentContactId.Contact1;
            comm.Parameters["@contact2"].Value = studentMaster.StudentContactId.Contact2;
            comm.Parameters["@totalFees"].Value = studentMaster.TotalFees;
            comm.Parameters["@numberOfInstallments"].Value = studentMaster.NumberOfInstallments;
            comm.Parameters["@dateOfAdmission"].Value = studentMaster.DateOfAdmission;

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
        public List<StudentMaster> GetStudents()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("ReadStudents", conn);
            List<StudentMaster> students = new List<StudentMaster>();

            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                SqlDataReader dataReader = comm.ExecuteReader();
                while (dataReader.Read())
                {
                    StudentMaster studentMaster = new StudentMaster();
                    studentMaster.StudentId = dataReader.GetInt32(0);
                    studentMaster.FirstName = dataReader.GetString(1);
                    studentMaster.MiddleName = dataReader.GetString(2);
                    studentMaster.LastName = dataReader.GetString(3);
                    studentMaster.TotalFees = dataReader.GetInt64(11);
                    studentMaster.IsStudentActive = dataReader.GetString(14);
                    students.Add(studentMaster);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
            return students;
        }

        public void InactiveStudent(int Id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["InstituteSystem"].ConnectionString);
            SqlCommand comm = new SqlCommand("InactiveStudent",conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@studentId", SqlDbType.Int));
            comm.Parameters["@studentId"].Value = Id;
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
    }
}