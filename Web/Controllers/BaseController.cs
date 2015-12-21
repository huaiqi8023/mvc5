using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devin.Models;
using Devin.IBLL;
using Devin.BLL;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        private Idt_managerService _current = new dt_managerService();
        public dt_manager CurrentUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            #region 检查用户是否已登录
            base.OnActionExecuting(filterContext);
            CurrentUser = Session["admin"] as dt_manager;
            //检验用户是否登录，如果不登录则跳转到登录页面
            if (CurrentUser == null) Response.Redirect("/Login/Index");
            #endregion
            #region-----检验用户是否有访问此地址的权利
            //获取当前请求的URL地址
            string requestUrl = filterContext.HttpContext.Request.Path;
            //获取当前请求的类型
            string requestType = filterContext.HttpContext.Request.RequestType.ToLower().Equals("get") ? "HttpGet" : "HttpPost";

            var UserCurrent = _current.LoadEntities(u => u.id == CurrentUser.id).FirstOrDefault();
            
            #endregion
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Response.Redirect("/Error.html");
        }

        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
    }
}