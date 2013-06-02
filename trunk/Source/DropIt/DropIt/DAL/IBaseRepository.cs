using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DropIt.DAL
{
    interface IBaseRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void AddOrUpdate(T obj);
        void Delete(int id);
        void Save();
    }
}
