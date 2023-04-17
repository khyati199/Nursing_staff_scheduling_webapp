using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NursingStaffPlanningandSchedulingExcellence.Models
{
    public class ShiftGapVM
    {
        public List<ShiftSchedule> WholeCalendarShifts { get; set; }
        public List<User> AllUsers { get; set; }
    }
}