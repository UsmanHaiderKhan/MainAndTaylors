using MainTaylorANDClothes.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace MainTaylorANDClothes.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            HttpCookie myCookie = Request.Cookies["logsec"];
            if (myCookie != null)
            {
                User user = new UserHandler().GetUser(myCookie.Values["logid"], myCookie.Values["psd"]);
                if (user != null)
                {
                    myCookie.Expires = DateTime.Now.AddDays(7);

                }
            }
            ViewBag.Controller = Request.QueryString["ctl"];
            ViewBag.Action = Request.QueryString["act"];
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User u = new UserHandler().GetUser(model.LoginId, model.Password);
            if (u != null)
            {

                HttpCookie cookie = new HttpCookie("logsec")
                { Expires = DateTime.Now.AddDays(7) };
                cookie.Values.Add("logid", u.LoginId);
                cookie.Values.Add("psd", u.Password);
                Response.SetCookie(cookie);


                string ctl = Request.QueryString["c"];
                string act = Request.QueryString["a"];
                if (!string.IsNullOrEmpty(ctl) && string.IsNullOrEmpty(act))
                {
                    return RedirectToAction(ctl, act);
                }
                return RedirectToAction("Index", "Taylors");
            }
            else
            {
                ViewBag.Error = "Your LoginId and Password are Wrong..Please try Again!";
            }
            return View();
        }
    }
}
