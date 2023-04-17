using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NursingStaffPlanningandSchedulingExcellence.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);

        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        T GetById(object Id);
        Task<T> GetByIdAsync(object id);
        void Insert(T obj);
        Task<T> InsertAsync(T t);

        T Find(Expression<Func<T, bool>> match);

        Task<T> FindAsync(Expression<Func<T, bool>> match);
        void Update(T obj);
        void Delete(Object Id);

        Task<int> DeleteAsync(object key);
        void Save();
        string UploadPlansPicture(string targetPath, string fileName, Stream inputStream, string fileExtension, string postType, ref string newTargetpath, ref string newFileName);
    }
}

