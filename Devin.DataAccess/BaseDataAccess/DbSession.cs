using Devin.IDataAccess;
using Devin.IDataAccess.IBaseDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devin.DataAccess.BaseDataAccess
{
    public class DbSession : IDbSession     //代表应用程序跟数据库之间的一次会话，也是数据库访问层的统一入口
    {
        public IUserRepository UserRepository
        {
            get { return new UserRepository(); }
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
