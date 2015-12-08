
using Devin.DataAccess;
using Devin.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin.Models;
using Devin.DataAccess.BaseDataAccess;
using Devin.IBLL;
using Devin.BLL.BaseService;

namespace Devin.BLL
{
    public partial class dt_managerService : BaseService<dt_manager>, Idt_managerService
    {
        /// <summary>
        /// 重写抽象方法,设置当前仓储为dt_manager仓储
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.dt_managerRepository;//RepositoryFactory.dt_managerRepository;
        }
    }
    public partial class dt_manager_logService : BaseService<dt_manager_log>, Idt_manager_logService
    {
        /// <summary>
        /// 重写抽象方法,设置当前仓储为dt_manager_log仓储
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.dt_manager_logRepository;//RepositoryFactory.dt_manager_logRepository;
        }
    }
    public partial class dt_manager_roleService : BaseService<dt_manager_role>, Idt_manager_roleService
    {
        /// <summary>
        /// 重写抽象方法,设置当前仓储为dt_manager_role仓储
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.dt_manager_roleRepository;//RepositoryFactory.dt_manager_roleRepository;
        }
    }
    public partial class dt_manager_role_valueService : BaseService<dt_manager_role_value>, Idt_manager_role_valueService
    {
        /// <summary>
        /// 重写抽象方法,设置当前仓储为dt_manager_role_value仓储
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.dt_manager_role_valueRepository;//RepositoryFactory.dt_manager_role_valueRepository;
        }
    }
    public partial class dt_navigationService : BaseService<dt_navigation>, Idt_navigationService
    {
        /// <summary>
        /// 重写抽象方法,设置当前仓储为dt_navigation仓储
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.dt_navigationRepository;//RepositoryFactory.dt_navigationRepository;
        }
    }
    public partial class dt_sms_templateService : BaseService<dt_sms_template>, Idt_sms_templateService
    {
        /// <summary>
        /// 重写抽象方法,设置当前仓储为dt_sms_template仓储
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = _DbSession.dt_sms_templateRepository;//RepositoryFactory.dt_sms_templateRepository;
        }
    }
}