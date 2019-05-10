using AccountProjectCore.EF;
using AccountProjectCore.Models;
using AccountProjectCore.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountProjectCore.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityRoots
    {
        protected readonly ApplicationDbContext _context;
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
        public Repository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=EVI\\SQLEXPRESS; Initial Catalog=AccountProjectDB; Integrated Security=True; MultipleActiveResultSets=True");
            _context = new ApplicationDbContext(optionsBuilder.Options);
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        }
        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }
        protected void Save() => _context.SaveChanges();


        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();

        }

        public T GetbyId(int id)
        {
            return _context.Set<T>().Find(id);

        }

        public void Update(T entity)
        {
            using (var cont = new ApplicationDbContext(_optionsBuilder.Options))
            // using (_context )

            {
                var oldentity = cont.Set<T>().Find(entity.Id);

                if (oldentity == null)
                    throw new Exception($"Invalid Or Missing  Id {entity.Id}");
                // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                //  _context.Set<T>().Update(entity);
                Save();
            }
        }
    }
}
