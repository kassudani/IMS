using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using InstituteManagementSystem.Models;

namespace InstituteManagementSystem
{
    public class InstituteDbContext : DbContext
    {
        public InstituteDbContext() : base("InstituteSystem")
        {

        }
        public DbSet<AddressMaster> AddressMasters { get; set; }
        public DbSet<ClassMaster> ClassMasters { get; set; }
        //public DbSet<ContactMaster> ContactMasters { get; set; }
        //public DbSet<DesignationMaster> DesignationMasters { get; set; }
        //public DbSet<FeesDetails> FeesDetails { get; set; }
        //public DbSet<FeesMaster> FeesMasters { get; set; }
        //public DbSet<LoginMaster> LoginMasters { get; set; }
        //public DbSet<StudentMaster> StudentMasters { get; set; }
        //public DbSet<SubjectMaster> SubjectMasters { get; set; }
        //public DbSet<UserMaster> UserMasters { get; set; }
        public static InstituteDbContext Create()
        {
            return new InstituteDbContext();
        }
    }
}