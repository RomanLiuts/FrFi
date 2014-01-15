using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrFi.DomainModel;
using FrFi.Models;
using HtmlAgilityPack;

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
     
        
        //TODO: вытащить список друзей и записать в бд
        // TODO: если капча нужна опять

        [HttpPost]
        public JsonResult VkCaptchaLogIn(string email, string password, string src, string captchaKey)
        {
            string captchaSid = src.Split('=')[2];

            Vk.LogIn(email, password, captchaSid, captchaKey);

            string friendsDocument = Vk.Post(@"http://m.vk.com/friends", null);


            return Json("Ok!");
        }


    }
}
