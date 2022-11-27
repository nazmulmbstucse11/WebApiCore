using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using WebApiFirst.DTO;
using WebApiFirst.Models;
using WebApiFirst.Services;

namespace WebApiFirst.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService; 
        }

        [HttpPost("CreateTask")]
        public IActionResult CreateTask(CreateTaskDto taskRequest)
        {
            try
            {
                return Ok(_taskService.CreateTask(taskRequest));
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateTask")]
        public IActionResult UpdateTask(UpdateTaskDto updateRequest)
        {
            try
            {
                return Ok(_taskService.UpdateTask(updateRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteById/{id:int}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                _taskService.DeleteTask(id);
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("TaskToDo/{name}")]
        public IActionResult GetTaskToDo(string name)
        {
            try
            {
                return Ok(_taskService.GetTaskToDo(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("RequestedTask/{name}")]
        public IActionResult GetRequestedTask(string name)
        {
            try
            {
                return Ok(_taskService.GetRequestedTask(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SearchByWord/{word}")]
        public IActionResult GetSearchByWord(string word)
        {
            try
            {
                return Ok(_taskService.GetSearchByWord(word));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListOfAllTask")]
        public IActionResult GetListOfAllTask()
        {
            try
            {
                return Ok(_taskService.GetListOfAllTask());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListOfEveryone")]
        public IActionResult GetListOfEveryone()
        {
            try
            {
                return Ok(_taskService.GetListOfEveryone());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePerson(PersonDto updateRequest)
        {
            try
            {
                return Ok(_taskService.UpdatePerson(updateRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CompletedTask/{name}")]
        public IActionResult GetCompletedTask(string name)
        {
            try
            {
                return Ok(_taskService.GetCompletedTask(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
