using AracSatis.Data;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.DesignPatterns.Singleton;
using AracSatis.Models.Entity;
using System.Linq.Expressions;

namespace AracSatis.DesignPatterns.GenericRepository.BaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _db;
        public BaseRepository(AppDbContext db)
        {
            _db = db;
        }
        void Save()
        {
            _db.SaveChanges();
        }
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.isDeleted = true;
            item.DeletedDate = DateTime.Now;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
             foreach(T item in list)
            {
                Delete(item);
            }
        }

        public void Destory(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.isDeleted == false);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> GetDeleteds()
        {
            return Where(x =>x.isDeleted == true);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public void Update(T item)
        {
            item.ModifiedDate = DateTime.Now;
            T unchangedEntity = Find(item.Id);
            _db.Entry(unchangedEntity).CurrentValues.SetValues(item);
            Save();
        }

        public void UpdateRange(List<T> list)
        {
            foreach(T item in list)
            {
                Update(item);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }

        public void Recover(T item)
        {
            item.isDeleted = false;
            item.DeletedDate = null;
            Save();
        }

        public void RecoverRange(List<T> list)
        {
            foreach (T item in list)
            {
                Recover(item);
            }
        }
    }
}
