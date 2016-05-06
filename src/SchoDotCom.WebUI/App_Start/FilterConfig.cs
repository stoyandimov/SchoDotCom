using SchoDotCom.WebUI.Filters;
using System.Configuration;
using System.Web.Mvc;

namespace SchoDotCom.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (ConfigurationManager.AppSettings["applicationinsights:EnableServerSideMonitoring"] == "true")
            {
                // Inherits from HandleErrorAttribute
                filters.Add(new AiHandleErrorAttribute());
            }
            else
            {
                filters.Add(new HandleErrorAttribute());
            }
        }
    }
}
