//引进TT模版的命名空间

using Devin.Models;
using Devin.IDataAccess;
using Devin.DataAccess.BaseDataAccess;

namespace Devin.DataAccess
{

    public partial class dt_managerRepository : BaseRepository<dt_manager>, Idt_managerRepository
    {

    }
    public partial class dt_manager_logRepository : BaseRepository<dt_manager_log>, Idt_manager_logRepository
    {

    }
    public partial class dt_manager_roleRepository : BaseRepository<dt_manager_role>, Idt_manager_roleRepository
    {

    }
    public partial class dt_manager_role_valueRepository : BaseRepository<dt_manager_role_value>, Idt_manager_role_valueRepository
    {

    }
    public partial class dt_navigationRepository : BaseRepository<dt_navigation>, Idt_navigationRepository
    {

    }
    public partial class dt_sms_templateRepository : BaseRepository<dt_sms_template>, Idt_sms_templateRepository
    {

    }
    //这里需要一个foreach循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有表对应的仓储显示出来

}