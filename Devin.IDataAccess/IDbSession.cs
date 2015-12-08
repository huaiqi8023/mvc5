


using Devin.Models;
using Devin.IDataAccess.IBaseDataAccess;

namespace Devin.IDataAccess
{
public interface IDbSession{
		//这里需要一个foreach循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有表对应的仓储显示出来

			/// <summary>
        /// 每个表对应的实体仓储对象
        /// </summary>
    Idt_managerRepository dt_managerRepository{get;}

			/// <summary>
        /// 每个表对应的实体仓储对象
        /// </summary>
    Idt_manager_logRepository dt_manager_logRepository{get;}

			/// <summary>
        /// 每个表对应的实体仓储对象
        /// </summary>
    Idt_manager_roleRepository dt_manager_roleRepository{get;}

			/// <summary>
        /// 每个表对应的实体仓储对象
        /// </summary>
    Idt_manager_role_valueRepository dt_manager_role_valueRepository{get;}

			/// <summary>
        /// 每个表对应的实体仓储对象
        /// </summary>
    Idt_navigationRepository dt_navigationRepository{get;}

			/// <summary>
        /// 每个表对应的实体仓储对象
        /// </summary>
    Idt_sms_templateRepository dt_sms_templateRepository{get;}

	

		/// <summary>
        /// 将当前应用程序跟数据库的会话内所有实体的变化更新回数据库
        /// </summary>
        /// <returns>保存成功就返回大于0，失败返回等于0</returns>
        int SaveChanges();

        /// <summary>
        /// 执行一个sql脚本的方法
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>保存成功就返回大于0，失败返回等于0</returns>
        int ExcuteSql(string strSql, System.Data.Common.DbParameter[] parameters);
 }
}