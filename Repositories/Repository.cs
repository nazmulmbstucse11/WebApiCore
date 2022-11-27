using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WebApiFirst.DTO;
using WebApiFirst.Models;

namespace WebApiFirst.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MainDBContext context;
        private DbSet<T> DbSet;

        public Repository(MainDBContext _context)
        {
            context = _context;
            DbSet = context.Set<T>();
        }
    
        public void Add(T entity)
        {
            DbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = context.TaskTable.Find(id) as T;
            DbSet.Remove(entity);
            context.SaveChanges();
        }

        public List<Task> GetTaskToDo(string name)
        {
            DateTime dd = DateTime.Now;
            string date = dd.ToString("dd-MM-yyyy");

            var ts = context.TaskTable.Where(s => s.ExecutorName == name && s.Date == date).ToList();
            return ts;
        }

        public List<Task> GetRequestedTask(string name)
        {
            DateTime dd = DateTime.Now;
            string date = dd.ToString("dd-MM-yyyy");

            var ts = context.TaskTable.Where(s => s.RequesterName == name && s.Date == date).ToList();
            return ts;
        }

        public List<Task> GetSearchByWord(string word)
        {
            var ts = context.TaskTable.Where(obj => EF.Functions.Like(obj.TaskName, "%" + word + "%")
                                                     || EF.Functions.Like(obj.Date, "%" + word + "%")
                                                     || EF.Functions.Like(obj.RequesterName, "%" + word + "%")
                                                     || EF.Functions.Like(obj.RequesterMobile, "%" + word + "%")
                                                     || EF.Functions.Like(obj.RequesterAddress, "%" + word + "%")
                                                     || EF.Functions.Like(obj.ExecutorName, "%" + word + "%")
                                                     || EF.Functions.Like(obj.ExecutorMobile, "%" + word + "%")
                                                     || EF.Functions.Like(obj.ExecutorAddress, "%" + word + "%")).ToList();
            return ts;
        }

        public List<string> GetListOfAllTask()
        {
            var ts = context.TaskTable.Select(s => s.TaskName).Distinct().ToList();
            return ts;
        }

        public List<Task> GetCompletedTask(string name)
        {
            var ts = context.TaskTable.Where(s => s.ExecutorName == name && s.isComplete == true).ToList();
            return ts;
        }

        void IRepository<T>.UpdateForPersonChange(Person person)
        {
            List<Task> ts = context.TaskTable.Where(s => s.RequesterName == person.Name).ToList();

            if (ts != null)
            {
                foreach (var tt in ts)
                {
                    tt.RequesterName = person.Name;
                    tt.RequesterMobile = person.Mobile;
                    tt.RequesterAddress = person.Address;

                    context.TaskTable.Update(tt);
                    context.SaveChanges();
                }
            }

            List<Task> tss = context.TaskTable.Where(s => s.ExecutorName == person.Name).ToList();

            if (tss != null)
            {
                foreach (var tt in tss)
                {
                    tt.ExecutorName = person.Name;
                    tt.ExecutorMobile = person.Mobile;
                    tt.ExecutorAddress = person.Address;

                    context.TaskTable.Update(tt);
                    context.SaveChanges();
                }
            }
        }
    }
}
