using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin.IDataAccess.IBaseRepository;
using System.Linq.Expressions;
using Devin.DataAccess.BaseDataAccess;
using Devin.IDataAccess.IBaseDataAccess;

namespace Devin.BLL.BaseService
{
    public abstract class BaseService<T> where T : class,new()
    {
        /// <summary>
        /// DBSession的存放
        ///目标：单元工作模式，就是批量的把对数据库的操作提交到数据库中去，
        /// 就是把一系列对数据库的操作封装成一个单元工作，一次性的把单元工作里面的所有改变都提交到数据库里面去，
        /// 这就是单元工作模式，它的目的就是为了提高跟数据库交互的效率，减少跟数据库交互的次数。
        /// </summary>
        public IDbSession _DbSession = new DbSession();

        /// <summary>
        /// 当前仓储
        /// </summary>
        public IBaseRepository<T> CurrentRepository { get; set; }

        /// <summary>
        /// 基类的构造方法
        /// </summary>
        public BaseService()
        {
            SetCurrentRepository();//构造方法里面去调用子类实现的抽象方法,此设置获取当前仓储的抽象方法
        }

        /// <summary>
        /// 子类必须实现抽象方法
        /// </summary>
        public abstract void SetCurrentRepository();

        /// <summary>
        /// 实现对数据库的添加功能，添加实现EF框架的引用
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>最后返回对象的实体类型</returns>
        public T AddEntity(T entity)
        {
            var AddEntity = CurrentRepository.AddEntity(entity);
            return _DbSession.SaveChanges() > 0 ? AddEntity : null;
        }

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>返回是否执行成功，如果执行成功则返回true，否则返回false</returns>
        public bool UpdateEntity(T entity)
        {
            CurrentRepository.UpdateEntity(entity);
            return _DbSession.SaveChanges() > 0 ? true : false;
        }

        /// <summary>
        /// 判断是否存在记录
        /// </summary>
        /// <param name="anylambda">查询条件</param>
        /// <returns>如果存在记录则返回true，否则返回false</returns>
        public bool Exists(Expression<Func<T, bool>> anylambda)
        {
            return CurrentRepository.Exists(anylambda);
        }

        /// <summary>
        /// 获取数据库的总记录
        /// </summary>
        /// <param name="pressionlambda">查询条件</param>
        /// <returns>返回总记录</returns>
        public int Count(Expression<Func<T, bool>> pressionlambda)
        {
            return CurrentRepository.Count(pressionlambda);
        }

        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>执行成功则返回true，否则返回false</returns>
        public bool DeleteEntity(T entity)
        {
            CurrentRepository.DeleteEntity(entity);
            return _DbSession.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteBy(Expression<Func<T, bool>> wherelambda)
        {
            CurrentRepository.DeleteBy(wherelambda);
            return _DbSession.SaveChanges() > 0 ? true : false;
        }

        /// <summary>
        /// 实现对数据库的实体的查询
        /// </summary>
        /// <param name="wherelambda">查询实体类的条件</param>
        /// <returns>返回一个实体类</returns>
        public T FindEntity(Expression<Func<T, bool>> wherelambda)
        {
            return CurrentRepository.FindEntity(wherelambda);
        }

        /// <summary>
        /// 实现对数据库查询--简单查询
        /// </summary>
        /// <param name="wherelambda">查询的简单条件</param>
        /// <returns>返回一个实体类的IQueryable集合</returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> wherelambda)
        {
            return CurrentRepository.LoadEntities(wherelambda);
        }

        /// <summary>
        /// 实现对数据的查询并排序
        /// </summary>
        /// <typeparam name="S">按照某个类进行排序</typeparam>
        /// <param name="wherelambda">查询条件</param>
        /// <param name="isAsc">如何排序，根据倒序还是升序</param>
        /// <param name="orderlambda">根据哪个字段进行排序</param>
        /// <returns>返回一个实体类型的IQueryable集合</returns>
        public IQueryable<T> FindList<S>(Expression<Func<T, bool>> wherelambda, bool isAsc, Expression<Func<T, S>> orderlambda)
        {
            return CurrentRepository.FindList(wherelambda, isAsc, orderlambda);
        }

        /// <summary>
        /// 实现对数据分布查询
        /// </summary>
        /// <typeparam name="S">按照某个类进行排序</typeparam>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="totalRecord">总条数</param>
        /// <param name="wherelambda">取得排序的查询条件</param>
        /// <param name="isAsc">根据倒序还是升序排序</param>
        /// <param name="orderlambda">根据哪个字段进行排序</param>
        /// <returns>返回一个实体类型的IQueryable的集合</returns>
        public IQueryable<T> FindPageList<S>(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> wherelambda, bool isAsc, Expression<Func<T, S>> orderlambda)
        {
            return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, wherelambda, isAsc, orderlambda);
        }
    }
}
