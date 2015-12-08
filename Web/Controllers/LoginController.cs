using Devin.BLL;
using Devin.Common;
using Devin.IBLL;
using Devin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        Idt_managerService _iManagerServer =  ServiceFactory.dt_managerService;
        // GET: Login
        public ActionResult Index()
        {
            var UserName = Request.Cookies["UserName"] != null ? Request.Cookies["UserName"].Value : "";
            ViewBag.UserName = UserName;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="Code">验证码</param>
        /// <returns></returns>
        public ActionResult CheckUserLogin(dt_manager admin, string Code)
        {
            ///把用户存放Cookie里
            if (admin.user_name != null && admin.user_name != "")
            {
                Response.Cookies["UserName"].Value = admin.user_name;
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(7);
            }
            string sessionCode = Session["ValidateCode"] == null ? Guid.NewGuid().ToString() : Session["ValidateCode"].ToString();

            Session["ValidateCode"] = Guid.NewGuid().ToString();
            if (sessionCode != Code)
            {
                return Content("请输入正确的验证码");
            }
            //获取密钥加密
            string salt = _iManagerServer.LoadEntities(m => m.user_name == admin.user_name && m.is_lock == 0).FirstOrDefault().salt;
            //根据密钥加密
            string password = DESEncrypt.Encrypt(admin.password, salt);
            //检验用户名和密码
            dt_manager _admin = _iManagerServer.LoadEntities(m => m.user_name == admin.user_name && m.password == password && m.is_lock == 0).FirstOrDefault();
            if (_admin != null)
            {
                Session["admin"] = _admin;
                return Content("Success");
            }
            return Content("用户名密码错误，请您检查");
        }

        /// <summary>
        /// 验证码的校验
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}