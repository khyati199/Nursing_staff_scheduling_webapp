using NursingStaffPlanningandSchedulingExcellence.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace NursingStaffPlanningandSchedulingExcellence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private NursingStaffEntities _entities;

        public Repository()
        {
            this._entities = new NursingStaffEntities();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _entities.Set<T>().Where(match).ToListAsync();
        }

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _entities.Set<T>().Where(match).ToList();
        }
        public List<T> GetAll()
        {
            return _entities.Set<T>().ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.Set<T>().ToListAsync();
        }

        public T GetById(object Id)
        {
            return _entities.Set<T>().Find(Id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _entities.Set<T>().FindAsync(id);
        }

        public void Insert(T obj)
        {
            _entities.Set<T>().Add(obj);
        }

        public async Task<T> InsertAsync(T obj)
        {
            _entities.Set<T>().Add(obj);
            await _entities.SaveChangesAsync();
            return obj;
        }

        public void Update(T obj)
        {
            _entities.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(object Id)
        {
            T getObjById = _entities.Set<T>().Find(Id);
            _entities.Set<T>().Remove(getObjById);
        }

        public async Task<int> DeleteAsync(object key)
        {
            T Obj = await _entities.Set<T>().FindAsync(key);
            _entities.Set<T>().Remove(Obj);
            return await _entities.SaveChangesAsync();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _entities.Set<T>().SingleOrDefault(match);
        }

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _entities.Set<T>().SingleOrDefaultAsync(match);
        }
        public void Save()
        {
            _entities.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._entities != null)
                {
                    this._entities.Dispose();
                    this._entities = null;
                }
            }
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public string UploadPlansPicture(string targetPath, string fileName, Stream inputStream, string fileExtension, string postType, ref string newTargetpath, ref string newFileName)
        {
            throw new NotImplementedException();
        }
    }
}