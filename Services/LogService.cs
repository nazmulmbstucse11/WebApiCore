using System;
using WebApiFirst.Models;
using WebApiFirst.Repositories;

namespace WebApiFirst.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository<RequestLog> request_repository;
        private readonly ILogRepository<ExceptionLog> exception_repository;

        public LogService(ILogRepository<RequestLog> request_repository, ILogRepository<ExceptionLog> exception_repository)
        {
            this.request_repository = request_repository;
            this.exception_repository = exception_repository;
        }

        public void AddRequestLog(string time)
        {
            var data = new RequestLog()
            {
                Logtime = time
            };

            request_repository.AddRequestLog(data);
        }

        public void AddExceptionLog(string exception, string time)
        {
            var data = new ExceptionLog()
            {
                 ExceptionType = exception,
                 Logtime = time
            };

            exception_repository.AddExceptionLog(data);
        }
    }
}
