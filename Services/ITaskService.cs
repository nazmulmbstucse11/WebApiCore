using System;
using System.Collections.Generic;
using WebApiFirst.DTO;
using WebApiFirst.Models;

namespace WebApiFirst.Services
{
    public interface ITaskService
    {
        TaskDto CreateTask(CreateTaskDto taskRequest);
        TaskDto UpdateTask(UpdateTaskDto updateRequest);
        void DeleteTask(int id);
        List<TaskToDoDto> GetTaskToDo(string name);
        List<RequestedTaskDto> GetRequestedTask(string name);
        List<TaskDto> GetSearchByWord(string word);
        List<string> GetListOfAllTask();
        List<string> GetListOfEveryone();
        PersonDto UpdatePerson(PersonDto person);
        List<CompletedTaskDto> GetCompletedTask(string name);
    }
}
