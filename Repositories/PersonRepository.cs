using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WebApiFirst.Models;

namespace WebApiFirst.Repositories
{
    public class PersonRepository<T> : IPersonRepository<T> where T : class
    {
        private readonly MainDBContext context;
        private DbSet<T> DbSet;

        public PersonRepository(MainDBContext _context)
        {
            context = _context;
            DbSet = context.Set<T>();
        }
        public void Add(Person entity)
        {
            Person person = context.PersonTable.Where(s=>s.Name == entity.Name).FirstOrDefault();

            if(person == null)
            {
                try
                {
                    context.PersonTable.Add(entity);
                    context.SaveChanges();
                }
                catch { }
            }
        }
        public void Update(Person entity)
        {
            Person person = context.PersonTable.Where(s => s.Name == entity.Name).FirstOrDefault();

            if (person == null)
            {
                try
                {
                    context.PersonTable.Add(entity);
                    context.SaveChanges();
                }
                catch { }
            }

            else
            {
                var ts = context.PersonTable.Where(s => s.Name == entity.Name).FirstOrDefault();

                if (ts != null)
                {
                    ts.Mobile = entity.Mobile;
                    ts.Address = entity.Address;
                }
                context.PersonTable.Update(ts);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity = context.TaskTable.Where(s => s.TaskId == id).FirstOrDefault();

            int count = context.TaskTable.Where(s => s.RequesterName == entity.RequesterName).Count();

            if(count == 1)
            {
                var ts = context.PersonTable.Where(s => s.Name == entity.RequesterName).FirstOrDefault();
                context.PersonTable.Remove(ts);
                context.SaveChanges();
            }

            int count1 = context.TaskTable.Where(s => s.ExecutorName == entity.ExecutorName).Count();

            if (count1 == 1)
            {
                var ts = context.PersonTable.Where(s => s.Name == entity.ExecutorName).FirstOrDefault();
                context.PersonTable.Remove(ts);
                context.SaveChanges();
            }
        } 

        public List<string> GetListOfEveryone()
        {
            var ts = context.PersonTable.Select(s => s.Name).ToList();
            return ts;
        }
    }
}
