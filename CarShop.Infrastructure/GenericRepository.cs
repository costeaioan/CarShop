using Carshop.Core.Entities;
using CarShop.Infrastructure.Data;
using CarShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Infrastructure
{
    public class GenericRepository<T> :IGenericRepository<T> where T : BaseEntity
    {
        private readonly CarShopDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(CarShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        public virtual T GetByID(int id)
        {
            //TODO test for null
            return _dbSet.Find(id);
        }

        public virtual void Delete(int id)
        {
            T objectToDelete = _dbSet.Find(id);
            if(objectToDelete != null)
            {
                _dbSet.Remove(objectToDelete);
            }
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
