using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NursingStaffPlanningandSchedulingExcellence.Models
{
    public class ShiftScheduleVM
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Required(ErrorMessage = " Start Date is required")]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = " End Date is required")]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY h:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        [Required(ErrorMessage = " Shift is required")]
        public Nullable<int> ShiftId { get; set; }
        public string Assignname { get; set; }
        [Required(ErrorMessage = " Number of hours is required")]
        [DefaultValue(8)]
        public int Hours { get; set; }
        [DefaultValue(1)]
        public int Days { get; set; }
        public int CountDays { get; set; }
        public int CountHours { get; set; }
        public int CountMinutes { get; set; }
        public int CountSeconds { get; set; }
        public bool IsCountingDownToShiftStart { get; set; }
        public List<ShiftSchedule> ShiftScheduleList { get; set; }
        public List<ShiftSchedule> WholeCalendarShifts { get; set; }
    }
}