
using Devin.IBLL.IBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin.Models;
namespace Devin.IBLL
{
    public partial interface Idt_managerService : IBaseService<dt_manager>
    {
    }
	    public partial interface Idt_manager_logService : IBaseService<dt_manager_log>
    {
    }
	    public partial interface Idt_manager_roleService : IBaseService<dt_manager_role>
    {
    }
	    public partial interface Idt_manager_role_valueService : IBaseService<dt_manager_role_value>
    {
    }
	    public partial interface Idt_navigationService : IBaseService<dt_navigation>
    {
    }
	    public partial interface Idt_sms_templateService : IBaseService<dt_sms_template>
    {
    }
	}