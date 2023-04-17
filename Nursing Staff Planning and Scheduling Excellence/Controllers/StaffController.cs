using Newtonsoft.Json;
using NursingStaffPlanningandSchedulingExcellence.Models;
using NursingStaffPlanningandSchedulingExcellence.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NursingStaffPlanningandSchedulingExcellence.Controllers
{
    [Authorize (Roles = "Staff")]
    public class StaffController : Controller
    {
        NursingStaffEntities db = new NursingStaffEntities();

        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public async Task<ActionResult> profile(int? UserID)
        {

            int UserIDs = LoginRepository.GetUserID(User.Identity.Name);
            if(UserIDs==0)
            {
                UserIDs = UserID??0;
            }
            UserVM obj = new UserVM();
            DateTime currentdate = DateTime.Now.Date;

            //var shifts = db.ShiftSchedule.Where(x => DbFunctions.TruncateTime(x.StartDate) >= currentdate && x.UserId == UserIDs).OrderBy(x => x.StartDate).FirstOrDefault();
            var c = db.ShiftSchedule.Where(x => DbFunctions.TruncateTime(x.StartDate) >= currentdate && x.UserId == UserIDs).OrderBy(x => x.StartDate).FirstOrDefault();

            if(c != null) 
            {
                if (c.StartDate.Value.Date == currentdate) 
                {
                    if (c.EndTime > DateTime.Now.TimeOfDay)

                    {
                        ViewBag.CurrentStartTimer = c.StartDate;
                        ViewBag.Enddate = c.EndDate;
                        obj.Enddate = Convert.ToString(c.EndTime);
                        ViewBag.StartTime = c.StartTime;
                    }

                    else
                    {
                        obj.Enddate = "";
                    }
                }
                
            }
            

            var time = DateTime.Now.AddDays(1);
            var Timer = db.ShiftSchedule.Where(x => DbFunctions.TruncateTime(x.StartDate) >= DbFunctions.TruncateTime(time) && x.UserId == UserIDs).OrderBy(x => x.StartDate).FirstOrDefault();
            if (Timer != null)

            {
                ViewBag.Timer = Timer.StartDate;
            }
            try
            {
                if (UserIDs != null)
                {
                    var task = db.User.Where(x => x.UserId == UserIDs).FirstOrDefault();
                    obj.UserId = task.UserId;
                    obj.FirstName = task.FirstName;
                    obj.LastName = task.LastName;
                    obj.DOB = (DateTime)task.DOB;
                    obj.ZipCode = task.ZipCode;
                    obj.City = task.City;
                    obj.Province = task.Province;
                    obj.CellPhone = task.CellPhone;
                    obj.Email = task.Email;
                    obj.Address = task.Address;
                    obj.Sex = task.Sex;
                    obj.MaritalStatusId = task.MaritalStatusId;
                    obj.UserName = task.UserName;
                    obj.Password = task.Password;
                    obj.Image = task.Image;
                    obj.Specialization = task.Specialization;
                    obj.UserRole = task.UserRole;
                    obj.Note = task.Note;
                    obj.Fax = task.Fax;
                    obj.NurseCertification = (DateTime)task.NurseCertification;

                    obj.GenderName = task.Gender?.GenderName;
                    obj.MaritalStatus = task.MaritalStatus?.MaritalStatusName;

                }

            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(obj);

        }

        [HttpGet]
        public async Task<ActionResult> SaveStaff(int? id)
        {
            UserVM obj = new UserVM();
            try
            {
                if (id != null)
                {
                    var task = db.User.Where(x => x.UserId == id).FirstOrDefault();
                    obj.UserId = task.UserId;
                    obj.FirstName = task.FirstName;
                    obj.LastName = task.LastName;
                    obj.DOB = (DateTime)task.DOB;
                    obj.ZipCode = task.ZipCode;
                    obj.City = task.City;
                    obj.Province = task.Province;
                    obj.CellPhone = task.CellPhone;
                    obj.Email = task.Email;
                    obj.Address = task.Address;
                    obj.Sex = task.Sex;
                    obj.MaritalStatusId = task.MaritalStatusId;
                    obj.UserName = task.UserName;
                    obj.Password = task.Password;
                    obj.Image = task.Image;
                    obj.Specialization = task.Specialization;
                    obj.UserRole = task.UserRole;
                    obj.Note = task.Note;
                    obj.Fax = task.Fax;
   
                    obj.GenderName = task.Gender?.GenderName;
                    obj.MaritalStatus = task.MaritalStatus?.MaritalStatusName;
                }
                obj.gendersList = db.Gender.ToList();
                obj.maritalsList = db.MaritalStatus.ToList();
                obj.rolesList = db.Role.ToList();
                obj.doctorList = db.User.Where(x => x.UserRole == 4).ToList();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(obj);
        }


        [HttpPost]
        public async Task<ActionResult> SaveStaff(UserVM objuser)
        {
            int UserID = LoginRepository.GetUserID(User.Identity.Name);
            User user = new User();
            var userDetails = db.User.Where(x => x.UserId == objuser.UserId).FirstOrDefault();
            var sh = db.User.Where(x => x.UserName == objuser.UserName).FirstOrDefault();
            if (userDetails != null)
            {
                if (sh != null)
                {
                    if(sh != userDetails)
                    {
                        TempData["DeleteMessage"] = string.Format("User name already in use");
                        return RedirectToAction("SaveStaff");
                    }
                }
            }
            if (objuser.UserId == 0)
                {
                //user.FirstName = objuser.FirstName;
                //user.LastName = objuser.LastName;
                //user.DOB = objuser.DOB;
                //user.ZipCode = objuser.ZipCode;
                //user.City = objuser.City;
                //user.Province = objuser.Province;
                //user.HomePhone = objuser.HomePhone;
                //user.CellPhone = objuser.CellPhone;
                //user.Email = objuser.Email;
                //user.Address = objuser.Address;
                //user.Sex = objuser.Sex;
                //user.MaritalStatusId = objuser.MaritalStatusId ?? 0;
                //user.UserName = objuser.UserName;
                //user.Password = objuser.Password;
                //user.Image = objuser.Image;s
                //user.Note = objuser.Note;

                //user.UserRole = 2;
                //db.User.Add(user);
                return View("Error");

            }
                if (objuser.UserId > 0)
                {
                    user = db.User.Where(m => m.UserId == objuser.UserId).FirstOrDefault();
                    if (objuser != null)
                    {
                        user.UserName = objuser.UserName;
                        user.Password = objuser.Password;
                        user.MaritalStatusId = objuser.MaritalStatusId ?? 0;
                        user.Address = objuser.Address;
                        user.City = objuser.City;
                        user.Province = objuser.Province;
                        user.ZipCode = objuser.ZipCode;
                        user.CellPhone = objuser.CellPhone;
                        user.HomePhone = objuser.HomePhone;
                        
                        user.Note = userDetails.Note;
                        user.Fax = userDetails.Fax;
                        user.Sex = userDetails.Sex;
                        user.FirstName = userDetails.FirstName;
                        user.LastName = userDetails.LastName;
                        user.DOB = userDetails.DOB;
                        user.UserRole = 2;
                        user.Email = userDetails.Email;
                        user.NurseCertification = userDetails.NurseCertification;
      
                        db.Entry(user).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();

                TempData["message"] = string.Format("Record updated successfully.");
                return RedirectToAction("profile", "Staff", new { UserID = UserID });
            }

        [HttpGet]
        public ActionResult ShiftSchedule(int? year, int? month, int? day, int? chosenYear, int? chosenMonth)
        {
            DateTime monthSelected = (chosenYear != null && chosenMonth != null) ? new DateTime(chosenYear.Value, chosenMonth.Value, day != null ? day.Value : DateTime.Now.Day) : DateTime.Now.Date;
            ViewBag.chosenMonth = monthSelected;

            DateTime chosenDate = (year != null && month != null && day != null) ? new DateTime(year.Value, month.Value, day.Value) : DateTime.Now.Date;
            ViewBag.chosenDate = chosenDate;

            int UserID = LoginRepository.GetUserID(User.Identity.Name);
            ShiftScheduleVM obj = new ShiftScheduleVM();
            try
            {
                obj.ShiftScheduleList = db.ShiftSchedule.Where(x => x.UserId == UserID && DbFunctions.TruncateTime(x.StartDate) <= chosenDate.Date && chosenDate.Date <= DbFunctions.TruncateTime(x.EndDate)).ToList();
                obj.WholeCalendarShifts = db.ShiftSchedule.Where(x => x.UserId == UserID).OrderByDescending(x => x.StartDate).ToList();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(obj);
        }


    }
}