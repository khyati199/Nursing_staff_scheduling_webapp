using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NursingStaffPlanningandSchedulingExcellence.Models
{
    public class UserWithScheduleVM
    {
        public UserWithScheduleVM()
        {
            User = new UserVM(); // default constructor initializes the User property
        }

        public UserWithScheduleVM(UserVM user)
        {
            User = user; // constructor overload sets the User property with the user parameter
        }

        public UserVM User { get; set; }
        public List<UserVM> userList { get; set; }
        public List<ShiftSchedule> ShiftScheduleList { get; set; }
        public List<ShiftSchedule> WholeCalendarShifts { get; set; }
    }
}