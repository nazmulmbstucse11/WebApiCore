using System.Collections.Generic;
using WebApiFirst.Models;

namespace WebApiFirst.Repositories
{
     public interface IPersonRepository<T> where T : class
     {
        void Add(Person entity);
        void Update(Person entity);
        void Delete(int id);
        List<string> GetListOfEveryone();
     }
}
