//引进TT模版的命名空间
using Devin.IDataAccess.IBaseDataAccess;
using Devin.Models;
namespace Devin.IDataAccess
{
    public interface Idt_managerRepository : IBaseRepository<dt_manager>
    {
    }
	    public interface Idt_manager_logRepository : IBaseRepository<dt_manager_log>
    {
    }
	    public interface Idt_manager_roleRepository : IBaseRepository<dt_manager_role>
    {
    }
	    public interface Idt_manager_role_valueRepository : IBaseRepository<dt_manager_role_value>
    {
    }
	    public interface Idt_navigationRepository : IBaseRepository<dt_navigation>
    {
    }
	    public interface Idt_sms_templateRepository : IBaseRepository<dt_sms_template>
    {
    }
	}
