using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_manager.Models;
using task_manager.Repositories;
using task_manager.Services;

namespace task_manager.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTrackersController : ControllerBase
    {
        private readonly ITimeTrackers _ITimeTrackersService;
        public TimeTrackersController(ITimeTrackers ITimeTrackersService)
        {
            _ITimeTrackersService = ITimeTrackersService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                List<TimeTrackersModel> TimeTrackers = _ITimeTrackersService.GetAllTimeTracker();
                return Ok(TimeTrackers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(TimeTrackersModel TimeTrackers)
        {
            try
            {
                _ITimeTrackersService.CreateTimeTracker(TimeTrackers);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(TimeTrackersModel TimeTrackers)
        {
            try
            {
                 _ITimeTrackersService.UpdateTimeTracker(TimeTrackers);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{IDTimeTracker}")]
        public IActionResult Delete(long IDTimeTracker)
        {
            try
            {
                _ITimeTrackersService.DeleteTimeTracker(IDTimeTracker);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
