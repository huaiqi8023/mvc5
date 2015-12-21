using Devin.BLL;
using Devin.Common;
using Devin.IBLL;
using Devin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Account.Controllers
{
    public class AuthController : Controller
    {
        Idt_managerService _iManagerServer = ServiceFactory.dt_managerService;
        // GET: Account/Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user_name, string password, string verifycode,bool ischecked) {
            if (user_name == "") return Content("");
            if (user_name != "" && ischecked == true)
            {
                Response.Cookies["UserName"].Value = user_name;
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(7);
            }
            string sessionCode = Session[DevinKeys.SESSION_CODE] == null ? Guid.NewGuid().ToString() : Session[DevinKeys.SESSION_CODE].ToString();

            Session[DevinKeys.SESSION_CODE] = Guid.NewGuid().ToString();
            if (sessionCode != verifycode)
            {
                return Content("请输入正确的验证码");
            }
            //获取密钥加密
            string salt = _iManagerServer.LoadEntities(m => m.user_name == user_name && m.is_lock == 0).FirstOrDefault().salt;
            //根据密钥加密
            string _password = DESEncrypt.Encrypt(password, salt);
            //检验用户名和密码
            dt_manager _admin = _iManagerServer.LoadEntities(m => m.user_name == user_name && m.password == _password && m.is_lock == 0).FirstOrDefault();
            if (_admin != null)
            {
                Session[DevinKeys.SESSION_ADMIN_INFO] = _admin;
                return Content("Success");
            }
            return Content("用户名密码错误，请您检查");
        }
    }
}