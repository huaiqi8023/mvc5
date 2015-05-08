using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin.IDataAccess;
using Devin.Models;
using Devin.IDataAccess.IBaseRepository;
using System.Data;
using System.Linq.Expressions;

namespace Devin.DataAccess.BaseDataAccess
{
    /// <summary>
    /// 实现对数据库的操作（增删改查）的基类
    /// </summary>
    /// <typeparam name="T">定义泛型，约束其是一个类，创建构造方法</typeparam>
    public abstract class BaseRepository<T> where T : class,new()
    {
        //第一种方法
        /// <summary>
        /// 创建EF框架的上下文
        /// EF上下文的实例保证线程唯一
        /// </summary>
        //protected DevinDBContext _nContext = new DevinDBContext();


        //第二种方法
        /// <summary>
        /// 获取的是当前线程内部的上下文实例，而且保证了线程内上下文唯一
        /// </summary>
        private readonly DevinDBContext _nContext = EFContextFactory.GetCurrentDbContext();

        public IQueryable<T> Entities
        {
            get { return _nContext.Set<T>(); }
        }

        /// <summary>
        /// 实现对数据库的添加功能，添加实现EF框架的引用
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>最后返回对象的实体类型</returns>
        public T AddEntity(T entity)
        {
            //EF4.0的写法   添加实体
            //db.CreateObjectSet<T>().AddObject(entity);
            _nContext.Set<T>().Add(entity);
            _nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            return _nContext.SaveChanges() > 0 ? entity : null;
        }

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>返回是否执行成功，如果执行成功则返回true，否则返回false</returns>
        public bool UpdateEntity(T entity)
        {
            //EF4.0的写法
            //db.CreateObjectSet<T>().Addach(entity);
            //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            _nContext.Set<T>().Attach(entity);
            _nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return _nContext.SaveChanges() > 0 ? true : false;
        }

        /// <summary>
        /// 判断是否存在记录
        /// </summary>
        /// <param name="anylambda">查询条件</param>
        /// <returns>如果存在记录则返回true，否则返回false</returns>
        public bool Exists(Expression<Func<T, bool>> anylambda)
        {
            return _nContext.Set<T>().Any(anylambda);
        }

        /// <summary>
        /// 获取数据库的总记录
        /// </summary>
        /// <param name="pressionlambda">查询条件</param>
        /// <returns>返回总记录</returns>
        public int Count(Expression<Func<T, bool>> pressionlambda)
        {
            return _nContext.Set<T>().Count(pressionlambda);
        }

        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>执行成功则返回true，否则返回false</returns>
        public bool DeleteEntity(T entity)
        {
            //EF4.0的写法
            //db.CreateObjectSet<T>().Addach(entity);
            //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
            _nContext.Set<T>().Attach(entity);
            _nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return _nContext.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteBy(Expression<Func<T, bool>> wherelambda)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 实现对数据库的实体的查询
        /// </summary>
        /// <param name="wherelambda">查询实体类的条件</param>
        /// <returns>返回一个实体类</returns>
        public T FindEntity(Expression<Func<T, bool>> wherelambda)
        {
            T _entity = _nContext.Set<T>().FirstOrDefault<T>(wherelambda);
            return _entity;
        }

        /// <summary>
        /// 实现对数据库查询--简单查询
        /// </summary>
        /// <param name="wherelambda">查询的简单条件</param>
        /// <returns>返回一个实体类的IQueryable集合</returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> wherelambda)
        {
            //EF4.0的写法
            //return db.CreateObjectSet<T>().Where<T>(whereLambda).AsQueryable();
            //EF5.0的写法
            return _nContext.Set<T>().Where<T>(wherelambda).AsQueryable();
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
            var _list = _nContext.Set<T>().Where<T>(wherelambda);
            if (isAsc)
            {
                _list = _list.OrderBy<T, S>(orderlambda);
            }
            else
            {
                _list = _list.OrderByDescending<T, S>(orderlambda);
            }
            return _list.AsQueryable();
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
            var _list = _nContext.Set<T>().Where<T>(wherelambda);
            totalRecord = _list.Count();//得到总条数
            if (isAsc)//排序，获取当前的数据
            {
                _list = _list.OrderBy<T, S>(orderlambda)
                    .Skip<T>((pageIndex - 1) * pageSize)//越过多少条
                    .Take<T>(pageSize);//取出多少条
            }
            else
            {
                _list = _list.OrderByDescending<T, S>(orderlambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return _list.AsQueryable();
        }
    }
}
