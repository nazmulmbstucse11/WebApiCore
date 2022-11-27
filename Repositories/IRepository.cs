using System.Collections.Generic;
using WebApiFirst.DTO;
using WebApiFirst.Models;

namespace WebApiFirst.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        List<Task> GetTaskToDo(string name);
        List<Task> GetRequestedTask(string name);
        List<Task> GetSearchByWord(string word);
        List<string> GetListOfAllTask();
        List<Task> GetCompletedTask(string name);

        void UpdateForPersonChange(Person entity);
    }
}
