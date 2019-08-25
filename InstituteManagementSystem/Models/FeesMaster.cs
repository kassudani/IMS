using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Models
{
    public class FeesMaster
    {
        public int FeesId { get; set; }
        public StudentMaster FeesStudentId { get; set; }
        public StudentMaster TotalFees { get; set; }
        public long FeesPaid { get; set; }
        public long FeesBalance { get; set; }
        public DateTime FeesPaidDate { get; set; }
        public FeesDetails FeesFeesDetilsId { get; set; }

    }
}