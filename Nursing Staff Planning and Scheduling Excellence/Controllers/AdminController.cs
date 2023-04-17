using DayPilot.Utils;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NursingStaffPlanningandSchedulingExcellence.Models;
using NursingStaffPlanningandSchedulingExcellence.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace NursingStaffPlanningandSchedulingExcellence.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdminController : Controller
    {
        NursingStaffEntities db = new NursingStaffEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        #region Staff
        public ActionResult AllStaffList()
        {
            UserVM obj = new UserVM();

            try
            {
                var user = db.User.Where(m => m.UserRole == 2);
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
                        CellPhone = s.CellPhone,
                        UserRole = s.UserRole,
                        MaritalStatusId = s.MaritalStatusId,
                        UserName = s.UserName,
                        Password = s.Password,
                        Image = s.Image,
                        Note = s.Note,
                        Fax = s.Fax,
                        NurseCertification = (DateTime)s.NurseCertification,

                        FullName = s.FirstName + "" + s.LastName,
                        GenderName = s.Gender.GenderName,
                        MaritalStatus = s.MaritalStatus.MaritalStatusName,
                    }).OrderBy(x=>x.LastName).ToList();
                }
               
            }
            catch (Exception ex)
            {

            }
            return View(obj);
           
        }

        [HttpGet]
        public ActionResult AddStaff(int? id)
        {
            int UserID = LoginRepository.GetUserID(User.Identity.Name);
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
                    obj.NurseCertification = (DateTime)task.NurseCertification.Value.Date;

                    obj.GenderName = task.Gender?.GenderName;
                    obj.MaritalStatus = task.MaritalStatus?.MaritalStatusName;
                }
                obj.gendersList = db.Gender.ToList();
                obj.maritalsList = db.MaritalStatus.ToList();
                obj.rolesList = db.Role.ToList();

            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(obj);
        }


        [HttpPost]
        public ActionResult AddStaff(UserVM objuser)
        {
            User user = new User();
            if ((DateTime.Now < objuser.DOB))
            {
                TempData["DeleteMessage"] = string.Format("User can't be from the future");
                return RedirectToAction("AddStaff");
            }
            TimeSpan age = DateTime.Now - objuser.DOB;
            if (age < new TimeSpan(157788, 0, 0))
            {
                TempData["DeleteMessage"] = string.Format("User should atleast be 18 years old");
                return RedirectToAction("AddStaff");
            }
            var sh = db.User.Where(x => x.Email == objuser.Email).FirstOrDefault();
            var checkUserDb = db.User.Where(x => x.UserId == objuser.UserId).FirstOrDefault();
            var sh2 = db.User.Where(x => x.UserName == objuser.UserName).FirstOrDefault();
            if (sh != null)
            {
                if(sh != checkUserDb)
                {
                    TempData["DeleteMessage"] = string.Format("Email already in use");
                    return RedirectToAction("AddStaff");
                }
            }
            if (sh2 != null) {
                if (sh2 != checkUserDb)
                {
                    TempData["DeleteMessage"] = string.Format("User name already in use");
                    return RedirectToAction("AddStaff");
                }           
            }
            if (objuser.UserId == 0)
            {
                user.FirstName = objuser.FirstName;
                user.LastName = objuser.LastName;
                user.DOB = objuser.DOB.Date;
                user.ZipCode = objuser.ZipCode;
                user.City = objuser.City;
                user.Province = objuser.Province;
                user.HomePhone = objuser.HomePhone;
                user.CellPhone = objuser.CellPhone;
                user.Email = objuser.Email;
                user.Address = objuser.Address;
                user.Sex = objuser.Sex;
                user.MaritalStatusId = objuser.MaritalStatusId ?? 0;
                user.UserName = objuser.UserName;
                user.Password = objuser.Password;
                user.Image = objuser.Image;
                user.Note = objuser.Note;
                user.NurseCertification = objuser.NurseCertification;

                user.UserRole = 2;
                db.User.Add(user);

            }
            if (objuser.UserId > 0)
            {
                user = db.User.Where(m => m.UserId == objuser.UserId).FirstOrDefault();
                if (objuser != null)
                {
                    user.FirstName = objuser.FirstName;
                    user.LastName = objuser.LastName;
                    user.DOB = objuser.DOB.Date;
                    user.ZipCode = objuser.ZipCode;
                    user.City = objuser.City;
                    user.Province = objuser.Province;
                    user.HomePhone = objuser.HomePhone;
                    user.CellPhone = objuser.CellPhone;
                    user.UserRole = 2;
                    user.Email = objuser.Email;
                    user.Address = objuser.Address;
                    user.Sex = objuser.Sex;
                    user.MaritalStatusId = objuser.MaritalStatusId ?? 0;
                    user.UserName = objuser.UserName;
                    user.Password = objuser.Password;
                    user.Note = objuser.Note;
                    user.Fax = objuser.Fax;
                    user.NurseCertification = objuser.NurseCertification;

                    db.Entry(user).State = EntityState.Modified;
                }
            }
            try
            {
                db.SaveChanges();
                TempData["message"] = string.Format("Record save successfully. ");
                return RedirectToAction("AllStaffList");
            } catch (Exception ex) {
                Console.WriteLine(ex);
                return RedirectToAction("AddStaff");
            }

        }


        public ActionResult DeleteStaff(int id)
        {

            if (id != 0)
            {
                var user = db.User.Where(x => x.UserId == id).FirstOrDefault();
                if (user != null)
                {
                    db.User.Remove(user);
                    db.SaveChanges();
                    TempData["message"] = string.Format("Record delete successfully. ");
                    return RedirectToAction("AllStaffList");
                }
            }
            return RedirectToAction("AllStaffList");
        }

        [HttpGet]
        public ActionResult StaffDetails(int id, int? year, int? month, int? day)
        {
            DateTime chosenMonth = (year != null && month != null) ? new DateTime(year.Value, month.Value, 1) : DateTime.Now;
            ViewBag.chosenMonth = chosenMonth;

            DateTime chosenDate = (year != null && month != null && day != null) ? new DateTime(year.Value, month.Value, day.Value) : DateTime.Now;
            ViewBag.chosenDate = chosenDate;

            int UserID = id;
            UserID = LoginRepository.GetUserID(User.Identity.Name);
            try
            {
                User task = db.User.Where(x => x.UserId == id).FirstOrDefault();
                UserWithScheduleVM staffDetails = new UserWithScheduleVM()
                {
                    User = new UserVM()
                    {
                        UserId = task.UserId,
                        FirstName = task.FirstName,
                        LastName = task.LastName,
                        DOB = (DateTime)task.DOB,
                        ZipCode = task.ZipCode,
                        City = task.City,
                        Province = task.Province,
                        CellPhone = task.CellPhone,
                        Email = task.Email,
                        Address = task.Address,
                        Sex = task.Sex,
                        MaritalStatusId = task.MaritalStatusId,
                        UserName = task.UserName,
                        Password = task.Password,
                        Image = task.Image,
                        Specialization = task.Specialization,
                        UserRole = task.UserRole,
                        Note = task.Note,
                        Fax = task.Fax,
                        NurseCertification = (DateTime)task.NurseCertification
                    }
                //staffDetails.User.gendersList = db.Gender.ToList()
                //obj.maritalsList = db.MaritalStatus.ToList();
                //obj.rolesList = db.Role.ToList();

            };

                staffDetails.ShiftScheduleList = db.ShiftSchedule.Where(x => x.UserId == id && DbFunctions.TruncateTime(x.StartDate) <= chosenDate.Date && chosenDate.Date <= DbFunctions.TruncateTime(x.EndDate)).ToList();
                staffDetails.WholeCalendarShifts = db.ShiftSchedule.Where(x => x.UserId == id).OrderByDescending(x => x.StartDate).ToList();
                return View(staffDetails);
            }

            
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult StaffGap(int? year, int? month, int? day)
        {
            DateTime chosenMonth = (year != null && month != null) ? new DateTime(year.Value, month.Value, 1) : DateTime.Now;
            ViewBag.chosenMonth = chosenMonth;

            DateTime chosenDate = (year != null && month != null && day != null) ? new DateTime(year.Value, month.Value, day.Value) : DateTime.Now;
            ViewBag.chosenDate = chosenDate;

            var UserID = LoginRepository.GetUserID(User.Identity.Name);
            try
            {
                ShiftGapVM shiftgap = new ShiftGapVM();
                shiftgap.AllUsers = db.User.OrderBy(x => x.LastName).ToList();
                shiftgap.WholeCalendarShifts = db.ShiftSchedule.Where(x => x.Id > 0).OrderBy(x=>x.StartDate).ToList(); // get all schedules
                return View(shiftgap);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        #endregion Staff

        #region Shift Schedule
        [HttpGet]
        public ActionResult ShiftSchedule(int? UserId, int? id, DateTime? StartDate)
        {
            int UserID = LoginRepository.GetUserID(User.Identity.Name);
            var checkUserDb = db.User.Where(x => x.UserId == UserId).FirstOrDefault();
            if(checkUserDb.NurseCertification < DateTime.Now)
            {
                TempData["DeleteMessage"] = string.Format("Nurse Certification of "+ checkUserDb.FirstName + " " + checkUserDb.LastName + " has Expired");
                return RedirectToAction("ScheduleList");
            }
            if (checkUserDb.NurseCertification < DateTime.Now.Date.AddMonths(1))
            {
                TempData["DeleteMessage"] = string.Format("Nurse Certification of " + checkUserDb.FirstName + " " + checkUserDb.LastName + " is Expiring");
            }
            ShiftScheduleVM obj = new ShiftScheduleVM();
            try
            {
                if (id != null)
                {
                    var task = db.ShiftSchedule.Where(x => x.Id == id).FirstOrDefault();
                    if (task != null)
                    {
                        obj.Id = task.Id;
                        obj.UserId = task.UserId;
                        obj.StartDate = (DateTime)task.StartDate;
                        obj.EndDate = (DateTime)task.EndDate;
                        obj.StartTime = task.StartDate.Value.TimeOfDay;
                        obj.EndTime = task.EndDate.Value.TimeOfDay;
                        obj.ShiftId = task.ShiftId;
                    }
                }

                obj.ShiftScheduleList = db.ShiftSchedule.Where(x => x.UserId == UserId && x.EndDate >= DateTime.Now).OrderBy(x => x.StartDate).ToList();
                var assignname = db.User.Where(x => x.UserId == UserId).FirstOrDefault();
                obj.Assignname = assignname.UserName;
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult ShiftSchedules(ShiftScheduleVM objShift)
            {
            Request.InputStream.Seek(0, SeekOrigin.Begin);
            string jsonData = new StreamReader(Request.InputStream).ReadToEnd();
            objShift.EndDate = objShift.StartDate + new TimeSpan (objShift.Hours, 0, 0);
            ShiftSchedule Shift = new ShiftSchedule();
            var totalWeeklyHours = db.ShiftSchedule.Where(x => x.UserId == objShift.UserId).ToList(); // get weekly hours... to be continued
            if ((objShift.EndDate < objShift.StartDate))
            {
                TempData["DeleteMessage"] = string.Format("Shift End is earlier than Start Date");
                return RedirectToAction("ShiftSchedule", new { userid = objShift.UserId });
            }
            TimeSpan shiftDuration = objShift.EndDate - objShift.StartDate;
            if (shiftDuration > new TimeSpan(12, 0, 0))
            {
                TempData["DeleteMessage"] = string.Format("Shift hours can not be greater than 12 hours");
                return RedirectToAction("ShiftSchedule", new { userid = objShift.UserId });
            }
            var sh = db.ShiftSchedule.Where(x => (EntityFunctions.TruncateTime(x.StartDate) == EntityFunctions.TruncateTime(objShift.StartDate) || EntityFunctions.TruncateTime(x.EndDate) == EntityFunctions.TruncateTime(objShift.EndDate)) && x.UserId == objShift.UserId && x.Id != objShift.Id).FirstOrDefault();
            if (sh != null)
            {
                TempData["DeleteMessage"] = string.Format("Already schedule the user for this date please choose new date ");
                return RedirectToAction("ShiftSchedule", new { userid = objShift.UserId });
            }
            else
            {

                if (objShift.Id == 0)
                {
                    Shift.UserId = objShift.UserId;
                    Shift.StartDate = objShift.StartDate;
                    Shift.EndDate = objShift.EndDate;
                    Shift.StartTime = objShift.StartDate.TimeOfDay;
                    Shift.EndTime = objShift.EndDate.TimeOfDay;
                    db.ShiftSchedule.Add(Shift);
                    db.SaveChanges();
                    if (objShift.Days > 1)
                    {
                        for (int i = 1; i < objShift.Days; i++) 
                        {
                            Shift.UserId = objShift.UserId;
                            Shift.StartDate = objShift.StartDate.AddDays(i);
                            Shift.EndDate = objShift.EndDate.AddDays(i);
                            Shift.StartTime = objShift.StartDate.TimeOfDay;
                            Shift.EndTime = objShift.EndDate.TimeOfDay;
                            db.ShiftSchedule.Add(Shift);
                            db.SaveChanges();
                        }
                    }
                }
                else if (objShift.Id > 0)
                {
                    Shift = db.ShiftSchedule.Where(m => m.Id == objShift.Id).FirstOrDefault();
                    if (objShift != null)
                    {
                        Shift.Id = objShift.Id;
                        Shift.UserId = objShift.UserId;
                        Shift.StartDate = objShift.StartDate;
                        Shift.EndDate = objShift.EndDate;
                        Shift.StartTime = objShift.StartDate.TimeOfDay;
                        Shift.EndTime = objShift.EndDate.TimeOfDay;
                        //Shift.ShiftId = objShift.ShiftId;
                        db.Entry(Shift).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                
                TempData["message"] = string.Format("Record saved successfully.");
            }
            return RedirectToAction("ShiftSchedule", new { userid = Shift.UserId });

        }


        public ActionResult DeleteShiftSchedule(int id, int userid)
        {

            if (id != 0)
            {
                var Shift = db.ShiftSchedule.Where(x => x.Id == id).FirstOrDefault();
                if (Shift != null)
                {
                    db.ShiftSchedule.Remove(Shift);
                    db.SaveChanges();
                    TempData["message"] = string.Format("Record delete successfully. ");
                    return RedirectToAction("ShiftSchedule", new { userid = userid });
                }
            }
            return RedirectToAction("ShiftSchedule", new { userid = userid });
        }


        public ActionResult ScheduleList(int? year, int? month, int? day)
        {
            DateTime chosenDate = (year != null && month != null && day != null) ? new DateTime(year.Value, month.Value, day.Value) : DateTime.Now.Date;
            ViewBag.chosenDate = chosenDate;
            var previousDate = chosenDate.AddDays(-1);
            UserVM obj = new UserVM();

            if(chosenDate != DateTime.Now.Date) 
            {
                var userList = db.User.Where(x => x.UserId > 10).OrderBy(x=>x.LastName).ToList();
                var shiftCheck = db.ShiftSchedule.Where(x => DbFunctions.TruncateTime(x.StartDate) == chosenDate.Date || DbFunctions.TruncateTime(x.StartDate) == previousDate.Date).ToList();
                //var shiftCheck = db.ShiftSchedule.Where(x => DbFunctions.TruncateTime(x.StartDate) == chosenDate.Date).ToList();
                //shiftCheck = db.ShiftSchedule.Where(x => DbFunctions.TruncateTime(x.StartDate) == chosenDate.Date.AddDays(-1)).ToList();
                for (int i = userList.Count - 1; i >= 0; i--)
                {
                    var userToRemove = userList[i];
                    if (shiftCheck.Any(x => x.UserId == userToRemove.UserId))
                    {
                        userList.RemoveAt(i);
                    }
                }
                try
                {
                    var user = db.User.Where(m => m.UserRole == 2);
                    if (user != null)
                    {
                        obj.userList = userList.Select(s => new UserVM
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
                            CellPhone = s.CellPhone,
                            UserRole = s.UserRole,
                            MaritalStatusId = s.MaritalStatusId,
                            UserName = s.UserName,
                            Password = s.Password,
                            Image = s.Image,
                            Note = s.Note,
                            Fax = s.Fax,
                            NurseCertification = (DateTime)s.NurseCertification,

                            FullName = s.FirstName + "" + s.LastName,
                            GenderName = s.Gender.GenderName,
                            MaritalStatus = s.MaritalStatus.MaritalStatusName,
                        }).ToList();
                        obj.userList = obj.userList.OrderBy(x => x.LastName).ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else 
            {
                try
                {
                    var user = db.User.Where(m => m.UserRole == 2);
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
                            CellPhone = s.CellPhone,
                            UserRole = s.UserRole,
                            MaritalStatusId = s.MaritalStatusId,
                            UserName = s.UserName,
                            Password = s.Password,
                            Image = s.Image,
                            Note = s.Note,
                            Fax = s.Fax,
                            NurseCertification = (DateTime)s.NurseCertification,

                            FullName = s.FirstName + "" + s.LastName,
                            GenderName = s.Gender.GenderName,
                            MaritalStatus = s.MaritalStatus.MaritalStatusName,
                        }).ToList();
                        obj.userList = obj.userList.OrderBy(x => x.LastName).ToList();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            return View(obj);
        }

        #endregion Shift Schedule

    }
}
