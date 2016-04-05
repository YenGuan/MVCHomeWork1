using MVCHomeWork1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHomeWork1.Controllers
{
    public class BaseController : Controller
    {
        protected 客戶資料Repository repo客戶資料 = RepositoryHelper.Get客戶資料Repository();
        protected 客戶銀行資訊Repository repo銀行資訊 = RepositoryHelper.Get客戶銀行資訊Repository();
        protected 客戶聯絡人Repository repo聯絡人 = RepositoryHelper.Get客戶聯絡人Repository();
        protected override void HandleUnknownAction(string actionName)
        {
            this.RedirectToAction("Index", "Home").ExecuteResult(this.ControllerContext);
        }
    }
}