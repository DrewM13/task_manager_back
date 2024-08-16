using Microsoft.AspNetCore.Mvc;
using task_manager.Models;
using task_manager.Repositories;

namespace task_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IDashboard _IDashboard;
        public DashboardController(IDashboard IDashboard)
        {
            _IDashboard = IDashboard;
        }

        [HttpPost]
        [Route("GetDashboard")]
        public IActionResult GetDashboard(ReqDashboard reqDashboard)
        {
            try
            {
                List<DashboardModel> dashboardModels = _IDashboard.GetDashboard(reqDashboard);
                return Ok(dashboardModels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
