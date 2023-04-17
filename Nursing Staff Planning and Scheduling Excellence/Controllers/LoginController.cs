using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using NursingStaffPlanningandSchedulingExcellence.Models;

namespace NursingStaffPlanningandSchedulingExcellence.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        NursingStaffEntities db = new NursingStaffEntities();
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel login)
        {
            var loginResponse = new LoginResponse { };
            LoginViewModel loginrequest = new LoginViewModel { };
            loginrequest.UserName = login.UserName;
            loginrequest.Password = login.Password;

            if (ModelState.IsValid)
            {
                var objResult = db.User.Where(x => x.UserName == login.UserName).FirstOrDefault();
                if (objResult != null && objResult.UserId > 0)
                {
                    if (objResult.Password == loginrequest.Password)
                    {
                        loginResponse.message = "Login Successful";
                        loginResponse.statuscode = HttpStatusCode.OK;
                        loginResponse.success = true;
                        loginResponse.UserId = objResult.UserId;
                        loginResponse.UserRole = objResult.Role.RoleName;
                        loginResponse.UserName = objResult.UserName;
                    }
                    else
                    {
                        loginResponse.UserId = 0;
                        loginResponse.message = "Password incorrect";
                        TempData["DeleteMessage"] = string.Format("Password incorrect");
                        loginResponse.statuscode = HttpStatusCode.BadRequest;
                        loginResponse.success = false;
                    }
                }
                else
                {
                    loginResponse.message = "Username does not exists.";
                    TempData["DeleteMessage"] = string.Format("Username does not exists");
                    loginResponse.statuscode = HttpStatusCode.NotFound;
                    loginResponse.success = false;
                }
                if (objResult != null)
                {
                    FormsAuthentication.SetAuthCookie(loginResponse.UserName, false);
                    var authTicket = new FormsAuthenticationTicket(1, loginResponse.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), true, loginResponse.UserRole);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (authCookie != null)
                    {
                        if (!string.IsNullOrEmpty(authCookie.Value))
                        {
                            authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                            string UserName = authTicket.Name;
                        }
                    }
                    authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    Session["token"] = loginResponse.token;
                    //TempData["message"] = loginResponse.message;
                    if (loginResponse.UserRole == "Admin")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (loginResponse.UserRole == "Staff")
                    {
                        return RedirectToAction("ShiftSchedule", "Staff");
                    }
                  
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View(login);
        }


        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("Login");
            return View();
        }
    }
}