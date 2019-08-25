using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Models
{
    public class LoginMaster
    {
        public int LoginId { get; set; }
        public int LoginUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime  RegistrationDate { get; set; }
        public bool IsLoginUserActive { get; set; }
    }
}