using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Taxi24.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        DbSet<T> Table { get; }
        IEnumerable<T> Get(Expression<Func<T, bool>> query);
        IEnumerable<T> ListAll();
        T First(Expression<Func<T, bool>> query);
        bool Exists(Expression<Func<T, bool>> query);
        T GetById(int Id);
        int Count();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
