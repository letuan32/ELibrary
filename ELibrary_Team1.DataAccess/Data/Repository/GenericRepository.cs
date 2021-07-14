using ELibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_Team1.DataAccess.Data.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ELibraryDbContext _db;
        internal DbSet<T> dbSet;
        public GenericRepository(ELibraryDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T AddRange(T entites)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public T Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
