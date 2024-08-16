using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_manager.Models;
using task_manager.Repositories;
using task_manager.Services;

namespace task_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaborators _ICollaboratorsService;
        public CollaboratorController(ICollaborators ICollaboratorsService)
        {
            _ICollaboratorsService = ICollaboratorsService;
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                List<CollaboratorsModel> Collaborators = _ICollaboratorsService.GetAllCollaborators();
                return Ok(Collaborators);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get/{IDCollaborator}")]
        public IActionResult GetByID(long IDCollaborator)
        {
            try
            {
                CollaboratorsModel Collaborator = _ICollaboratorsService.GetCollaboratorByID(IDCollaborator);
                return Ok(Collaborator);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateAssociationWithTask(TaskCollaboratorModel taskCollaboratorModel)
        {
            try
            {
                _ICollaboratorsService.CreateOrUpdateAssociationWithTask(taskCollaboratorModel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        /*[HttpGet]
        [Route("Get/iduser/{IDUser}")]
        public IActionResult GetByIDUser(long IDUser)
        {
            try
            {
                List<CollaboratorsModel> Collaborator = _ICollaboratorsService.GetCollaboratorsByIDUser(IDUser);
                return Ok(Collaborator);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}
