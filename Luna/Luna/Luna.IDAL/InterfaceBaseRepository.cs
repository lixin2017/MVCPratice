﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Luna.IDAL
{
    /// <summary>
    /// 接口基类
    /// <remarks>
    /// 2017/9/5
    /// </remarks>
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface InterfaceBaseRepository<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity);

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">提交表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        T Find(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="whereLambda">查询表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <returns>实体列表</returns>
        IQueryable<T> FindList<S>(Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderLambda);

        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="whereLambda">查询表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderLambda">排序表达式</param>
        /// <returns></returns>
        IQueryable<T> FindPageList<S>(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderLambda);
    }
}
