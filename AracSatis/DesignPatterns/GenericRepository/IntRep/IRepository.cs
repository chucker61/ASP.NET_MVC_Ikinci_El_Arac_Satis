﻿using AracSatis.Models.Entity;
using System.Linq.Expressions;

namespace AracSatis.DesignPatterns.GenericRepository.IntRep
{
    public interface IRepository<T> where T : BaseEntity
    {
        //List
        List<T> GetAll();
        List<T> GetActives();
        List<T> GetDeleteds();

        //Modify
        void Add(T item);
        void AddRange(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        void Update(T item);
        void UpdateRange(List<T> list);
        void Destory(T item);
        void DestroyRange(List<T> list);
        void Recover(T item);
        void RecoverRange(List<T> list);
        //Linq
        List<T> Where(Expression<Func<T,bool>> exp);
        bool Any(Expression<Func<T,bool>> exp);
        T FirstOrDefault(Expression<Func<T,bool>> exp);
        object Select(Expression<Func<T,object>> exp);
        IQueryable<X> Select<X>(Expression<Func<T,X>> exp);

        //Find
        T Find(int id);


    }
}
