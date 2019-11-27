using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaApi.Models
{
   public  interface IRepositorio<T>
    {
        void Insert(T item);

        void Update(T item);

        void Delete(T item);

        IEnumerable<T> GetAll();


        T GetById(int? id);
    }
}
