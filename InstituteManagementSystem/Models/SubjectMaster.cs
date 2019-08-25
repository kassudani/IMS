using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Models
{
    public class SubjectMaster
    {
        public int SubjectId { get; set; }
        public string Subject { get; set; }
        public bool SubjectSelectionResult { get; set; }
    }
}