﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ELibrary_Team1.DataAccess.Data.Repository
{
    public interface IGenericRepository<T> where T: class
    {
    // Add
        T Add(T entity);
        T AddRange(T entites);
        //Task<T> AddAsync(T entity);
        //Task<T> AddRangeAsync(T entites);

    // Remove
        T Remove(T entity);
        //T RemoveRage(T entites);

    // Get
        IEnumerable<T> GetAll() ;
        T GetById(int id);
        T GetById(string id);
        //Task<T> GetByIdAsync(int id);
        //Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();

        // Find
        //T Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    // Update
        T Update(T entity);
        //Task<T> UpdateAsync(T entity);
    }
}
