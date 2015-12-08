using Devin.BLL.BaseService;
using Devin.IBLL;
using Devin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devin.BLL
{
    public partial class dt_managerService : BaseService<dt_manager>, Idt_managerService
    {
        /// <summary>
        /// 检验用户名和密码，并登录
        /// </summary>
        /// <param name="userinfo">用户实体</param>
        /// <returns></returns>
        public dt_manager checkUserLogin(dt_manager userinfo)
        {
            return LoadEntities(m => m.user_name == userinfo.user_name && m.password == userinfo.password && m.is_lock == 0).FirstOrDefault();
        }
    }
}
