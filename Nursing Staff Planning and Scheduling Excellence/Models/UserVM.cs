using NursingStaffPlanningandSchedulingExcellence.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NursingStaffPlanningandSchedulingExcellence.Models
{
    public class UserVM
    {

        public int UserId { get; set; }
        [Required(ErrorMessage = " First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " Last name is required")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = " Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = " Marital Status is required")]
        public Nullable<int> MaritalStatusId { get; set; }
        [Required(ErrorMessage = " Date of Birth is required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = " Gender is required")]
        public Nullable<int> Sex { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Epiration of Nurse Certification is required")]
        public DateTime NurseCertification { get; set; }
        public string City { get; set; }
        public string Province{ get; set; }
        public string ZipCode { get; set; }
        [DataType(DataType.EmailAddress)]

        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter a valid email address")]

        [Required(ErrorMessage = "Email address is required")]

        [StringLength(254, ErrorMessage = "Email cannot be longer than 254 characters")]

        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        [Required(ErrorMessage = " User Role is required")]
        public Nullable<int> UserRole { get; set; }
        public Nullable<int> AccessLevel { get; set; }

        public string Specialization { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string MaritalStatus { get; set; }
        public string GenderName { get; set; }
        public string Note { get; set; }
        public string Fax { get; set; }
        [Required]
        public List<RoleVM> roleList { get; set; }
        public List<Role> rolesList { get; set; }
        public List<UserVM> userList { get; set; }
        public List<User> doctorList { get; set; }
        public List<MaritalStatusVM> maritalList { get; set; }
        public List<MaritalStatus> maritalsList { get; set; }
        public List<GenderVM> genderList { get; set; }
        public List<Gender> gendersList { get; set; }
        public string Enddate { get; set; }
    }
}