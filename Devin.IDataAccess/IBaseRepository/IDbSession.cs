using System;
namespace Devin.IDataAccess.IBaseDataAccess
{
    public interface IDbSession
    {

        /// <summary>
        /// 每个表对应的实体仓储对象
        /// </summary>
        IUserRepository UserRepository { get; }

        /// <summary>
        /// 将当前应用程序跟数据库的会话内所有实体的变化更新回数据库
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 执行一个sql脚本的方法
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        int ExcuteSql(string strSql, System.Data.Common.DbParameter[] parameters);
    }
}
