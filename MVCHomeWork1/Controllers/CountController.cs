using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCHomeWork1.Models;

namespace MVCHomeWork1.Controllers
{
    public class CountController : Controller
    {
        客戶資料Entities db = new 客戶資料Entities();
        public ActionResult Index()
        {
            var data = db.VW_HomeWorkCount1;
            return View(data);
        }
    }
}
