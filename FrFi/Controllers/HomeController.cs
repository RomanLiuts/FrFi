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
            //UserModel user = new UserModel() { FirstName="Roman", LastName="Lyuts" };

            //Data.CreateUser(user);
            
            Vk.LogIn();
            return View();
        }

    }
}
