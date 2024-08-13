using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_manager.Models;
using task_manager.Repositories;
using task_manager.Services;

namespace task_manager.Controllers
{
    
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProject _IProjectService;
        public ProjectController(IProject IProjectService)
        {
            _IProjectService = IProjectService;
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                List<ProjectModel> Projects = _IProjectService.GetAllProject();
                return Ok(Projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get/{IDProject}")]
        public IActionResult GetByID(long IDProject)
        {
            try
            {
                ProjectModel Project = _IProjectService.GetProjectByID(IDProject);
                return Ok(Project);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ProjectModel Project)
        {
            try
            {
                 _IProjectService.CreateProject(Project);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(ProjectModel Project)
        {
            try
            {
                _IProjectService.UpdateProject(Project);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{IDProject}")]
        public IActionResult Delete(long IDProject)
        {
            try
            {
                _IProjectService.DeleteProject(IDProject);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
