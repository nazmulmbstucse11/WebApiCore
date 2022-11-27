using Microsoft.EntityFrameworkCore;
using WebApiFirst.Models;

namespace WebApiFirst.Repositories
{
    public class LogRepository<T> : ILogRepository<T> where T : class
    {
        private readonly MainDBContext context;
        private DbSet<T> DbSet;

        public LogRepository(MainDBContext _context)
        {
            context = _context;
            DbSet = context.Set<T>();
        }

        public void AddRequestLog(RequestLog requestLog)
        {
            context.RequestTable.Add(requestLog);
            context.SaveChanges();
        }
        public void AddExceptionLog(ExceptionLog exceptionLog)
        {
            context.ExceptionTable.Add(exceptionLog);
            context.SaveChanges();
        }
    }
}
