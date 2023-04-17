using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;

namespace NursingStaffPlanningandSchedulingExcellence.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }
    }

    public class LoginResponse
    {
        public bool success { get; set; }
        public string token { get; set; }
        public string message { get; set; }
        public string failureMessage { get; set; }
        public HttpStatusCode statuscode { get; set; }
        public long UserId { get; set; }
        public string UserRole { get; set; }
        public string UserName { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = " User name is required")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}