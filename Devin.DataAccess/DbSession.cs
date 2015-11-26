//引进TT模板的命名空间

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin.IDataAccess;
using Devin.Models;
using Devin.IDataAccess.IBaseDataAccess;
using System.Data;
using System.Linq.Expressions;
using Devin.DataAccess.BaseDataAccess;
namespace Devin.DataAccess
{
    //一次跟数据库交互的会话
    public partial class DbSession : IDbSession  //代表应用程序跟数据库之间的一次会话，也是数据库访问层的统一入口
    {
        //从这里需要一个for循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有表的对应的仓储显示出来

        public Idt_managerRepository dt_managerRepository
        {
            get { return new dt_managerRepository(); }
        }
        public Idt_manager_logRepository dt_manager_logRepository
        {
            get { return new dt_manager_logRepository(); }
        }
        public Idt_manager_roleRepository dt_manager_roleRepository
        {
            get { return new dt_manager_roleRepository(); }
        }
        public Idt_manager_role_valueRepository dt_manager_role_valueRepository
        {
            get { return new dt_manager_role_valueRepository(); }
        }
        public Idt_navigationRepository dt_navigationRepository
        {
            get { return new dt_navigationRepository(); }
        }
        public Idt_sms_templateRepository dt_sms_templateRepository
        {
            get { return new dt_sms_templateRepository(); }
        }

        /// <summary>
        /// 代表：当前应用程序跟数据库的绘画内所有的实体的变化，更新数据库
        /// </summary>
        /// <returns></returns>
        public int SaveChanges() //目标是实现单元工作模式(UintWork)
        {
            //调用EF上下文的SaveChanges方法
            return EFContextFactory.GetCurrentDbContext().SaveChanges();
        }

        /// <summary>
        /// 执行一个sql脚本的方法
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExcuteSql(string strSql, System.Data.Common.DbParameter[] parameters)
        {
            return EFContextFactory.GetCurrentDbContext().Database.ExecuteSqlCommand(strSql, parameters);
        }
    }
}
