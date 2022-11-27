namespace WebApiFirst.Services
{
    public interface ILogService
    {
        void AddRequestLog(string time);
        void AddExceptionLog(string exception, string time);
    }
}
