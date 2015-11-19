using System.Web.Mvc;

namespace QuanLyKhoHang.Areas.Main
{
    public class MainAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Main";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Main_default",
                "Main/{controller}/{action}/{id}",
                new { controller="Main", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}