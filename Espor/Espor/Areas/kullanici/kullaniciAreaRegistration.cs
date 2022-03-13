using System.Web.Mvc;

namespace Espor.Areas.kullanici
{
    public class kullaniciAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "kullanici";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "kullanici_default",
                "kullanici/{controller}/{action}/{id}",
                new {controller="Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}