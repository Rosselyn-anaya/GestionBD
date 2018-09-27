using System.Web;
using System.Web.Mvc;

namespace Evaluacion3_Gestion_BD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
