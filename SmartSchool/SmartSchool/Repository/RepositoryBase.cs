using Microsoft.EntityFrameworkCore;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Repository
{
    public class RepositoryBase<T> where T : class
    {
        private readonly SmartSchoolContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(SmartSchoolContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T Get(int id)
        {
            return _dbSet.Find(id);
        }
        public bool Create(T entity)
        {
            _dbSet.Add(entity);
            return true;
        }
        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
        public bool Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return true;
            }
            return false;
        }
    }
}
