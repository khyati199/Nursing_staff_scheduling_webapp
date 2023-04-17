using System.Web;
using System.Web.Mvc;

namespace NursingStaffPlanningandSchedulingExcellence
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
        }
    }
}
