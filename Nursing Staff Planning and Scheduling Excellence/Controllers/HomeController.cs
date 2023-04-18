using Newtonsoft.Json;
using NursingStaffPlanningandSchedulingExcellence.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NursingStaffPlanningandSchedulingExcellence.Controllers
{
    [Authorize(Roles = "Admin, Staff")]
    public class HomeController : Controller
    {
        NursingStaffEntities db = new NursingStaffEntities();

        [HttpGet]
        public ActionResult Index()
        {
            UserVM obj = new UserVM();

            var user = db.User.Where(m => m.UserId > 10);
            if (user != null)
            {
                obj.userList = user.Select(s => new UserVM
                {
                    UserId = s.UserId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Address = s.Address,
                    Sex = s.Sex,
                    DOB = (DateTime)s.DOB,
                    ZipCode = s.ZipCode,
                    City = s.City,
                    Province = s.Province,
                    Email = s.Email,
                    HomePhone = s.HomePhone,
                    CellPhone = s.CellPhone,
                    UserRole = s.UserRole,
                    AccessLevel = s.AccessLevel,
                    MaritalStatusId = s.MaritalStatusId,
                    UserName = s.UserName,
                    Password = s.Password,
                    NurseCertification = (DateTime)s.NurseCertification,

                    Image = s.Image,
                    Specialization = s.Specialization,
                    Note = s.Note,
                    Fax = s.Fax,
                    FullName = s.FirstName + "" + s.LastName,
                    GenderName = s.Gender.GenderName,
                    MaritalStatus = s.MaritalStatus.MaritalStatusName,
                }).OrderBy(x => x.LastName).ToList();
            }
            return View(obj);

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}