using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Models
{
    public class UserMaster
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int UserDesignationId { get; set; }
        public ContactMaster ContactNumber { get; set; }
        public string Qualification { get; set; }
        public long TotalPayment { get; set; }
        public string PaymentDate { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Worktype { get; set; }
        public string Batch { get; set; }
        public string IsUserActive { get; set; }
        
    }
}