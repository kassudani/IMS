using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Models
{
    public class FeesDetails
    {
        public int FeesDetailsId { get; set; }
        public StudentMaster FeesDetailsStudentId { get; set; }
        public long TotalFees { get; set; }
        public long FeesPaid { get; set; }
        public long FeesBalance { get; set; }
        public DateTime FeesPaidDate { get; set; }
        public string ReceivedBy { get; set; }
    }
}