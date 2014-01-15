using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrFi.DomainModel;
using FrFi.Models;

namespace FrFi.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string VkLogIn(string email, string password)
        {
            string captchaLink = string.Empty;
            using ( VkParser parser = new VkParser() )
            {
                captchaLink = parser.GetCaptchaLink(Vk.LogIn(email, password));

            }

            return captchaLink;
        }



    }
}
