using AccountProjectCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountProjectCore.Repository.Interfaces
{
    public interface IRepository<T> where T : EntityRoots
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        T GetbyId(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(Func<T, bool> predicate);
    }
}