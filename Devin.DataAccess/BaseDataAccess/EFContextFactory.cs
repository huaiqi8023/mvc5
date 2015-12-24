using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Data.Entity;
using Devin.Models;

namespace Devin.DataAccess.BaseDataAccess
{
    public class EFContextFactory
    {
        /// <summary>
        /// 帮助我们返回当前线程的数据上下文，如果当前线程内没有上下文，那么创建一个上下文并保证
        /// 访问实例在线程内部是唯一的
        /// </summary>
        /// <returns></returns>
        public static DbContext GetCurrentDbContext()
        {
            //CallContext：是线程内部唯一的独用的数据槽（一块内存空间）
            //传递DevinDBContext是上下文
            DbContext _dbContext = CallContext.GetData("DBContext") as DbContext;//DBContext上下文
            if (_dbContext == null)//线程在数据槽里面没有此上下文
            {
               // _dbContext = new DevinDBContext();//创建一个EF上下文　
                _dbContext = new DBContext();
                CallContext.SetData("DBContext", _dbContext);//放到数据槽中去
            }
            return _dbContext;
        }
    }
}
