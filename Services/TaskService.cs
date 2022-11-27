using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using WebApiFirst.DTO;
using WebApiFirst.Models;
using WebApiFirst.Repositories;

namespace WebApiFirst.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<Task> task_repository;
        private readonly IPersonRepository<Person> person_repository;

        public TaskService(IRepository<Task> task_repository, IPersonRepository<Person> person_repository)
        {
            this.task_repository = task_repository;
            this.person_repository = person_repository;
        }

        public TaskDto CreateTask(CreateTaskDto taskRequest)
        {
            var newTask = new Task()
            {
                TaskName = taskRequest.TaskName,
                Date = taskRequest.Date,
                RequesterName = taskRequest.RequesterName,
                RequesterMobile = taskRequest.RequesterMobile,
                RequesterAddress = taskRequest.RequesterAddress,
                ExecutorName = taskRequest.ExecutorName,
                ExecutorMobile = taskRequest.ExecutorMobile,
                ExecutorAddress = taskRequest.ExecutorAddress,
                isComplete = taskRequest.isComplete
            };

            var person1 = new Person()
            {
                Name = taskRequest.RequesterName,
                Mobile = taskRequest.RequesterMobile,
                Address = taskRequest.RequesterAddress
            };

            var person2 = new Person()
            {
                Name = taskRequest.ExecutorName,
                Mobile = taskRequest.ExecutorMobile,
                Address = taskRequest.ExecutorAddress
            };

            task_repository.Add(newTask);
            person_repository.Add(person1);
            person_repository.Add(person2);

            return new TaskDto()
            {
                TaskId = newTask.TaskId,
                TaskName = newTask.TaskName,
                Date = newTask.Date,
                RequesterName = newTask.RequesterName,
                RequesterMobile = newTask.RequesterMobile,
                RequesterAddress = newTask.RequesterAddress,
                ExecutorName = newTask.ExecutorName,
                ExecutorMobile = newTask.ExecutorMobile,
                ExecutorAddress = newTask.ExecutorAddress,
                isComplete = newTask.isComplete
            };
        }

        public TaskDto UpdateTask(UpdateTaskDto updateRequest)
        {
            var updateTask = new Task()
            {
                TaskId = updateRequest.TaskId,
                TaskName = updateRequest.TaskName,
                Date = updateRequest.Date,
                RequesterName = updateRequest.RequesterName,
                RequesterMobile = updateRequest.RequesterMobile,
                RequesterAddress = updateRequest.RequesterAddress,
                ExecutorName = updateRequest.ExecutorName,
                ExecutorMobile = updateRequest.ExecutorMobile,
                ExecutorAddress = updateRequest.ExecutorAddress,
                isComplete = updateRequest.isComplete
            };

            var person1 = new Person()
            {
                Name = updateRequest.RequesterName,
                Mobile = updateRequest.RequesterMobile,
                Address = updateRequest.RequesterAddress
            };

            var person2 = new Person()
            {
                Name = updateRequest.ExecutorName,
                Mobile = updateRequest.ExecutorMobile,
                Address = updateRequest.ExecutorAddress
            };

            task_repository.Update(updateTask);
            person_repository.Update(person1);
            person_repository.Update(person2);

            return new TaskDto()
            {
                TaskId = updateTask.TaskId,
                TaskName = updateTask.TaskName,
                Date = updateTask.Date,
                RequesterName = updateTask.RequesterName,
                RequesterMobile = updateTask.RequesterMobile,
                RequesterAddress = updateTask.RequesterAddress,
                ExecutorName = updateTask.ExecutorName,
                ExecutorMobile = updateTask.ExecutorMobile,
                ExecutorAddress = updateTask.ExecutorAddress,
                isComplete = updateTask.isComplete
            };
        }

        public void DeleteTask(int id)
        {
            person_repository.Delete(id);
            task_repository.Delete(id);
        }

       public List<TaskToDoDto> GetTaskToDo(string name)
        {
            var ts = task_repository.GetTaskToDo(name);

            List<TaskToDoDto> list = new List<TaskToDoDto>();

            foreach (var tt in ts)
            {
                TaskToDoDto taskDto = new TaskToDoDto()
                {
                    TaskName = tt.TaskName,
                    Date = tt.Date,
                    RequesterName = tt.RequesterName,
                    RequesterMobile = tt.RequesterMobile
                };

                list.Add(taskDto);
            }

            return list;
        }

        public List<RequestedTaskDto> GetRequestedTask(string name)
        {
            var ts = task_repository.GetRequestedTask(name);

            List<RequestedTaskDto> list = new List<RequestedTaskDto>();

            foreach (var tt in ts)
            {
                RequestedTaskDto taskDto = new RequestedTaskDto()
                {
                    TaskName = tt.TaskName,
                    Date = tt.Date,
                    ExecutorName = tt.ExecutorName,
                    ExecutorMobile = tt.ExecutorMobile
                };

                list.Add(taskDto);
            }

            return list;
        }

        public List<TaskDto> GetSearchByWord(string word)
        {
            var ts = task_repository.GetSearchByWord(word);

            List<TaskDto> list = new List<TaskDto>();

            foreach (var tt in ts)
            {
                TaskDto taskDto = new TaskDto()
                {
                    TaskId = tt.TaskId,
                    TaskName = tt.TaskName,
                    Date = tt.Date,
                    RequesterName = tt.RequesterName,
                    RequesterMobile = tt.RequesterMobile,
                    RequesterAddress = tt.RequesterAddress,
                    ExecutorName = tt.ExecutorName,
                    ExecutorMobile = tt.ExecutorMobile,
                    ExecutorAddress = tt.ExecutorAddress,
                    isComplete = tt.isComplete
                };

                list.Add(taskDto);
            }

            return list;
        }

        public List<string> GetListOfAllTask()
        {
            var ts = task_repository.GetListOfAllTask();

            return ts;
        }

        public List<string> GetListOfEveryone()
        {
            var ts = person_repository.GetListOfEveryone();

            return ts;
        }

        public PersonDto UpdatePerson(PersonDto person)
        {
            var updateperson = new Person
            {
                Name = person.Name,
                Mobile = person.Mobile,
                Address = person.Address
            };

            person_repository.Update(updateperson);
            task_repository.UpdateForPersonChange(updateperson);

            return new PersonDto
            {
                Name = updateperson.Name,
                Mobile = updateperson.Mobile,
                Address = updateperson.Address
            };
        }
        public List<CompletedTaskDto> GetCompletedTask(string name)
        {
            var ts = task_repository.GetCompletedTask(name);

            List<CompletedTaskDto> list = new List<CompletedTaskDto>();

            foreach (var tt in ts)
            {
                CompletedTaskDto taskDto = new CompletedTaskDto()
                {
                    TaskName = tt.TaskName,
                    Date = tt.Date,
                    RequesterName = tt.RequesterName,
                };

                list.Add(taskDto);
            }

            return list;
        }
    }
}
