using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApiFirst.Services;

namespace WebApiFirst.Middleware
{
    public class ExceptionMiddleware: IMiddleware
    {
        private readonly ILogService _logService;
        public ExceptionMiddleware(ILogService logService)
        {
            _logService = logService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                context.Request.EnableBuffering();         
                await next(context);
            }
            catch { }
            finally
            {
                var now = DateTime.Now;
                var date = new DateTime(now.Year, now.Month, now.Day,
                                        now.Hour, now.Minute, now.Second);


                if (context.Response?.StatusCode == 400)
                {
                    _logService.AddExceptionLog("HTTP Error 400 - Bad Request", date.ToString());
                }

                else if (context.Response?.StatusCode == 404)
                {
                    _logService.AddExceptionLog("HTTP status 404 - Not Found", date.ToString());
                }

                else if (context.Response?.StatusCode == 408)
                {
                    _logService.AddExceptionLog("HTTP Error 408 - Request Timeout", date.ToString());
                }

                else if (context.Response?.StatusCode == 500)
                {
                    _logService.AddExceptionLog("HTTP status 500 - Internal Server Error", date.ToString());
                }

                else if (context.Response?.StatusCode == 502)
                {
                    _logService.AddExceptionLog("HTTP status 502 - Bad Gateway", date.ToString());
                }
            }
        }
    }
}
