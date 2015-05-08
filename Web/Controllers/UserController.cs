using Devin.BLL.BaseService;
using Devin.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 在这里也需要依赖接口编程
        /// </summary>
        private static readonly IUserService _userinfoService = ServiceFactory.UserService;
        // GET: User

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUserInfos()
        {
            //Json格式的要求{total:22,rows:{}}
            //实现对用户分布的查询，rows：一共多少条，page：请求的当前第几页
            int pageIndex = string.IsNullOrEmpty(Request["page"]) ? 1 : int.Parse(Request["page"].ToString());
            int pageSize = string.IsNullOrEmpty(Request["rows"]) ? 1 : int.Parse(Request["rows"].ToString());
            int totalRecord = 0;
            //调用分页的方法，传递参数，拿到分页之后的数据
            var data = _userinfoService.FindPageList(pageIndex, pageSize, out totalRecord, userinfo => true, true, userinfo => userinfo.Id);
            var result = new { total = totalRecord, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
