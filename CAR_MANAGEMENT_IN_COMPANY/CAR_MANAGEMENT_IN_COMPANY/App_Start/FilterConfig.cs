using System.Web;
using System.Web.Mvc;

namespace CAR_MANAGEMENT_IN_COMPANY
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
