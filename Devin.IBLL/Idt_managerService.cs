using Devin.IBLL.IBaseService;
using Devin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devin.IBLL
{
    public partial interface Idt_managerService : IBaseService<dt_manager>
    {
        dt_manager checkUserLogin(dt_manager userinfo);
    }
}
