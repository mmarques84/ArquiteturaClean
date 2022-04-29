using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DBContext _context;

        public Repository(DBContext context)
        {
            _context = context;
        }

        public virtual TEntity GetById(int id)
        {
            var query = _context.Set<TEntity>().Where(e => e.Id == id);

            if (query.Any())
                return query.FirstOrDefault();

            return null;
        }
    
        public virtual IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>();

            if (query.Any())
                return query.ToList();

            return new List<TEntity>();
        }

        public virtual void Save(TEntity entity)
        {
            _context.Add(entity);
            Save();
        }      
        public void Save()
        {
            _context.SaveChanges();
        }
        public bool UPDATE(TEntity entity)
        {
          //  _context.Entry(TEntity).State = EntityState.Modified;
            _context.Set<TEntity>().Add(entity);
            return true;
        }
      

        public IEnumerable<Cliente> GetDOC(int DOC)
        {
            var query = _context.Set<Cliente>().Where(e => e.Documento == DOC);

            if (query.Any())
                return query.ToList();

            return new List<Cliente>();
        }
    }
}
