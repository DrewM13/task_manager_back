﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_manager.Models;
using task_manager.Repositories;
using task_manager.Services;

namespace task_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITask _ITaskService;
        public TaskController(ITask TaskService)
        {
            _ITaskService = TaskService;
        }  
        
        [HttpGet]
        [Route("Get/{IDTask}")]
        public IActionResult GetByID(long IDTask)
        {
            try
            {
               TasksModel task = _ITaskService.GetTaskByID(IDTask);
                return Ok(task);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("GetByIDProject/{IDProject}")]
        public IActionResult GetByIDProject(long IDProject)
        {
            try
            {
                List<viewTaskCollaborator> task = _ITaskService.viewListTask(IDProject);
                return Ok(task);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(TasksModel Task)
        {
            try
            {
                TasksModel newTask = _ITaskService.CreateTask(Task);
                return Ok(newTask);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(TasksModel Task)
        {
            try
            {
                _ITaskService.UpdateTask(Task);
                return NoContent();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete]
        [Route("Delete/{IDTask}")]
        public IActionResult Delete(long IDTask)
        {
            try
            {
                _ITaskService.DeleteTask(IDTask);
                return NoContent();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
