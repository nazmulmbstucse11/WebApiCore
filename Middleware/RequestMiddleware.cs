using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Threading.Tasks;
using WebApiFirst.Repositories;
using WebApiFirst.Services;

namespace WebApiFirst.Middleware
{
    public class RequestMiddleware : IMiddleware
    {
        private readonly ILogService _logService;
        public RequestMiddleware(ILogService logService)
        {
            _logService = logService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var now = DateTime.Now;
            var date = new DateTime(now.Year, now.Month, now.Day,
                                    now.Hour, now.Minute, now.Second);

            _logService.AddRequestLog(date.ToString());

            await next(context);
        }
    }
}
