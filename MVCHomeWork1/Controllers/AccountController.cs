using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MVCHomeWork1.Models;
using System.Web.Security;
using System.Web.Helpers;

namespace MVCHomeWork1.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(客戶資料 p_model)
        {
            if (CheckLogin(p_model))
            {
                FormsAuthentication.RedirectFromLoginPage(p_model.客戶名稱, false);
            }
            return View();
        }
        private bool CheckLogin(客戶資料 data)
        {
            var vali = repo客戶資料.Where(p => p.帳號 == data.帳號).FirstOrDefault(); ;
            if(vali!=null)
            {
                return Crypto.VerifyHashedPassword(vali.密碼,data.密碼);  
            }
            return false;
        }

        [AllowAnonymous]
        public ActionResult Signup()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Signup(客戶資料 p_model)
        {
            if (ModelState.IsValid)
            {
                // TODO

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [AllowAnonymous]
        public ActionResult AccMaintain()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AccMaintain(客戶資料 p_model)
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}