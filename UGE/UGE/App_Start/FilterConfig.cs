using System.Web;
using System.Web.Mvc;
using Filters;

namespace UGE {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AreaAuthorizeAttribute());

        }
    }
}
