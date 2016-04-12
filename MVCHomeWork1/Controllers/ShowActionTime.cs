using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVCHomeWork1.Controllers
{
    class ShowActionTimeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.dtActionStart = DateTime.Now;
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.dtActionEnd = DateTime.Now;

            TimeSpan actionSpan = (DateTime)filterContext.Controller.ViewBag.dtActionEnd - (DateTime)filterContext.Controller.ViewBag.dtActionStart;
            filterContext.Controller.ViewBag.dtActionTimeSpan = actionSpan;
            base.OnActionExecuted(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.dtResultStart = DateTime.Now;
            base.OnResultExecuted(filterContext);
        }
    }
}
