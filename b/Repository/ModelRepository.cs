using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;

namespace b.Models
{
    #region IRepository
    public interface IRepository : IDisposable
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllV<T>(string sIncludeTable = null) where T : class;

        IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// Gets objects from database with filting and paging.
        /// <typeparam name="Key"></typeparam>
        /// <param name="filter">Specified a filter</param>
        /// <param name="total">Returns the total records count of the filter.</param>
        /// <param name="index">Specified the page index.</param>
        /// <param name="size">Specified the page size</param>
        /// <returns></returns>
        IQueryable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class;

        /// Gets the object(s) is exists in database by specified filter.
        /// <param name="predicate">Specified the filter expression</param>
        /// <returns></returns>
        bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// Find object by keys.
        /// <param name="keys">Specified the search keys.</param>
        T Find<T>(params object[] keys) where T : class;

        /// Find object by specified expression.
        /// <param name="predicate"></param>
        T Find<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// Create a new object to database.
        /// <param name="t">Specified a new object to create.</param>
        T Create<T>(T t) where T : VersionTable;
        T Edit<T>(T t) where T : VersionTable;

        /// Delete the object from database.
        /// <param name="t">Specified a existing object to delete.</param>
        int Delete<T>(T t) where T : class;

        /// Delete objects from database by specified filter expression.
        /// <param name="predicate"></param>
        int Delete<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// Update object changes and save to database.
        /// <param name="t">Specified the object to save.</param>
        int Update<T>(T t) where T : class;

        /// Select Single Item by specified expression.
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        T Single<T>(Expression<Func<T, bool>> expression) where T : class;

        void SaveChanges();

        void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams);

    }
    #endregion

    #region Repository
    public class Repository : IRepository
    {
        private bDBContext db;
        public Repository()
        {
            db = new bDBContext();
        }
        public Repository(bDBContext db)
        {
            this.db = db;
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return All<T>().FirstOrDefault(expression);
        }
        public IQueryable<T> All<T>() where T : class
        {
            return db.Set<T>().AsQueryable();
        }
        public IQueryable<T> AllV<T>(string sIncludeTable = null) where T : class
        {
            //var lastVersions = from n in db.Sublocations.Include(t => t.Store)
            //                   group n by n.ID into g
            //                   select g.OrderByDescending(t => t.Version).FirstOrDefault();
            if (string.IsNullOrEmpty(sIncludeTable))
                return db.Set<T>().AsQueryable();
            return db.Set<T>().Include(sIncludeTable).AsQueryable();
        }
        public virtual IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return db.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }
        public virtual IQueryable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? db.Set<T>().Where<T>(filter).AsQueryable() : db.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual T Create<T>(T TObject) where T : VersionTable
        {
            var newEntry = db.Set<T>().Add(TObject);
            int iId = 1;
            try
            {
                iId = db.Set<T>().Max(t => t.ID) + 1;
            }
            catch { }
            newEntry.ID = iId;
            newEntry.Version = 1;
            newEntry.EntryDate = DateTime.Now;
            db.SaveChanges();
            return newEntry;
        }
        public virtual T Edit<T>(T TObject) where T : VersionTable
        {
            var newItem = TObject;
            newItem.Version = TObject.Version + 1;
            newItem.EntryDate = DateTime.Now;
            //db.Vendors.Add(newItem);
            //db.SaveChanges();

            var newEntry = db.Set<T>().Add(newItem);
            //int iId = 1;
            //try
            //{
            //    iId = db.Set<T>().Max(t => t.ID) + 1;
            //}
            //catch { }
            //newEntry.ID = iId;
            //newEntry.Version = 1;
            //newEntry.EntryDate = DateTime.Now;
            db.SaveChanges();
            return newEntry;

            //Vendor newItem = vendor;
            //newItem.Version = vendor.Version + 1;
            //newItem.EntryDate = DateTime.Now;
            //db.Vendors.Add(newItem);
            //db.SaveChanges();

        }
        public virtual int Delete<T>(T TObject) where T : class
        {
            db.Set<T>().Remove(TObject);
            return db.SaveChanges();
        }
        public virtual int Update<T>(T TObject) where T : class
        {
            try
            {
                var entry = db.Entry(TObject);
                db.Set<T>().Attach(TObject);
                entry.State = EntityState.Modified;
                return db.SaveChanges();
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw ex;
            }
        }
        public virtual int Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var objects = Filter<T>(predicate);
            foreach (var obj in objects)
                db.Set<T>().Remove(obj);
            return db.SaveChanges();
        }

        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return db.Set<T>().Count<T>(predicate) > 0;
        }
        public virtual T Find<T>(params object[] keys) where T : class
        {
            return (T)db.Set<T>().Find(keys);
        }
        public virtual T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return db.Set<T>().FirstOrDefault<T>(predicate);
        }

        public virtual void ExecuteProcedure(String procedureCommand, params SqlParameter[] sqlParams)
        {
            db.Database.ExecuteSqlCommand(procedureCommand, sqlParams);

        }
        public virtual void SaveChanges()
        {
            db.SaveChanges();
        }

        public IEnumerable<Store> GetStores()
        {
            return db.Stores;
        }

        public void Dispose()
        {
            if (db != null)
                db.Dispose();
        }
    }
    #endregion
}