using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Models
{
    public class StudentMaster
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int StudentClassId { get; set; }
        public string StudentSubjectIds { get; set; }
        public string School { get; set; }
        public string Gender { get; set; }
        public AddressMaster StudentAddressId { get; set; }
        public ContactMaster StudentContactId { get; set; }
        public long TotalFees { get; set; }
        public int NumberOfInstallments { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string IsStudentActive { get; set; }
        public bool IsStudentPassed { get; set; }
        public DateTime DateOfPassing { get; set; }
    }
    
}