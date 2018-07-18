using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepository<T> where T : class
    {
        T GetById(string id);
        void Create(T item);
        void Update(T item);
    }
}