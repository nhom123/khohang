using System.Web.Mvc;

namespace QuanLyKhoHang.Areas.Sale
{
    public class SaleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Sale";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Sale_default",
                "Sale/{controller}/{action}/{id}",
                new {controller="Sale" ,action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}