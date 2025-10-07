using Demo_DataAccess.Data.Contexts;
using Demo_DataAccess.Models;
using Demo_DataAccess.Models.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DataAccess.Repositories.Generics
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext) 
        {
          _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true).ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true).ToList();
            }

        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }


        // Get department by ID
        public TEntity? GetById(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            return entity;
        }

        // Add a new department
        public void Add(TEntity entity)
        {
            _dbContext.Add(entity);
            
        }

        // Update an existing department
        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
            
        }

        // remove a department

        public void Remove(TEntity entity)
        {
            _dbContext.Remove(entity);
            
        }

        int IGenericRepository<TEntity>.Add(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
