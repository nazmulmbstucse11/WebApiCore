namespace WebApiFirst.DTO
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Date { get; set; }
        public string RequesterName { get; set; }
        public string RequesterMobile { get; set; }
        public string RequesterAddress { get; set; }
        public string ExecutorName { get; set; }
        public string ExecutorMobile { get; set; }
        public string ExecutorAddress { get; set; }
        public bool isComplete { get; set; }
    }
}
