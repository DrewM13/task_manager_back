using Microsoft.AspNetCore.Mvc;
using task_manager.Models;
using task_manager.Repositories;

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
        [Route("GetByIDTask/{IDTask}")]
        public IActionResult GetByIDTask(long IDTask)
        {
            try
            {
                List<TimeTrackersModel> TimeTrackers = _ITimeTrackersService.GetByIDTaskTimeTracker(IDTask);
                return Ok(TimeTrackers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(List<TimeTrackersModel> TimeTrackers)
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

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(List<TimeTrackersModel> timeTrackersModel)
        {
            try
            {
                _ITimeTrackersService.DeleteTimeTracker(timeTrackersModel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
