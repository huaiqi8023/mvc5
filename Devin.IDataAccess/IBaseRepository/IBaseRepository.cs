using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Devin.IDataAccess.IBaseDataAccess
{
    public interface IBaseRepository<T> where T : class
    {

        /// <summary>
        /// 数据实体列表
        /// </summary>
        IQueryable<T> Entities { get; }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        T AddEntity(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anylambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exists(Expression<Func<T, bool>> anylambda);

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="pressionlambda">lambda形式的条件表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T, bool>> pressionlambda);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool DeleteEntity(T entity);

        /// <summary>
        /// 根据lambda表达式删除
        /// </summary>
        /// <param name="wherelambda">删除表达式</param>
        /// <returns>记录数</returns>
        bool DeleteBy(Expression<Func<T, bool>> wherelambda);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="wherelambda">查询表达式</param>
        /// <returns>实体</returns>
        T FindEntity(Expression<Func<T, bool>> wherelambda);

        /// <summary>
        /// 对数据库简单查询
        /// </summary>
        /// <param name="wherelambda">查询表达式</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> wherelambda);

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="wherelambda">查询表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderlambda">排序表达式</param>
        /// <returns></returns>
        IQueryable<T> FindList<S>(Expression<Func<T, bool>> wherelambda, bool isAsc, Expression<Func<T, S>> orderlambda);

        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="wherelambda">查询表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderlambda">排序表达式</param>
        /// <returns></returns>
        IQueryable<T> FindPageList<S>(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> wherelambda, bool isAsc, Expression<Func<T, S>> orderlambda);
    }
}
