using NursingStaffPlanningandSchedulingExcellence.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NursingStaffPlanningandSchedulingExcellence.Repository
{
    public static class LoginRepository
    {
        public static UserViewModel GetUserDetails(LoginViewModel obj)
        {
            using (NursingStaffEntities context = new NursingStaffEntities())
            {
                UserViewModel objUserView = new UserViewModel();
                var objUser = context.User.Where(u => u.UserName.ToLower() == obj.UserName.ToLower() && u.Password == obj.Password).FirstOrDefault();
                if (objUser != null)
                {
                    objUserView.UserName = objUser.UserName;
                    objUserView.ID = objUser.UserId;
                    objUserView.Roles = objUser.Role.RoleName;
                }
                return objUserView;
            }
        }
        public static int GetUserID(string UserName)
        {
            using (NursingStaffEntities context = new NursingStaffEntities())
            {
                var objUser = context.User.Where(u => u.UserName.ToLower() == UserName.ToLower()).FirstOrDefault();

                if (objUser != null)
                {
                    return objUser.UserId;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}