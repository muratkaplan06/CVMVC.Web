using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CVMVC.Web.Models.Entity;

namespace CVMVC.Web.Repository
{
    public class GenericRepository<T>where T:class,new()
    {
        private readonly DbCvEntities _db = new DbCvEntities();

        public List<T> List()
        {
            return _db.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }
        public void Add(T entity)
        {
            var addedEntity = _db.Entry(entity);
            addedEntity.State = EntityState.Added;
            _db.SaveChanges();

        }

        public void Delete(T entity)
        {
            var removedEntity = _db.Entry(entity);
            removedEntity.State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            var updatedEntity = _db.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> filter)
        {
            return _db.Set<T>().FirstOrDefault(filter);
        }
    }
}