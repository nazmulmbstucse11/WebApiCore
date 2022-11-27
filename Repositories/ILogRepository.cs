using System;
using WebApiFirst.Models;

namespace WebApiFirst.Repositories
{
    public interface ILogRepository<T> where T : class
    {
        public void AddRequestLog(RequestLog requestLog);
        public void AddExceptionLog(ExceptionLog exceptionLog);
    }
}
