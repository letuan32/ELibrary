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
        // Add
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void AddRange(T entites)
        {
            dbSet.AddRange(entites);
        }
        // Find & Get
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.SingleOrDefaultAsync(predicate);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public T GetById(string id)
        {
            return dbSet.Find(id);
        }

        // Remove
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);
        }

        // Update
        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }


        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }


        public Task RemoveRangeAsync(IEnumerable<T> entites)
        {
            throw new NotImplementedException();
        }

        public T GetById(int? id)
        {
            return dbSet.Find(id);
            
        }
 
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }
    }
}
