
using Microsoft.AspNetCore.Mvc;
using task_manager.Models;
using task_manager.Repositories;

namespace task_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _IAuthService;
        public AuthController(IAuth AuthService)
        {
            _IAuthService = AuthService;
        }

        [HttpPost]
        public IActionResult Login(AuthModel Auth)
        {
            try
            {
                string token = _IAuthService.Login(Auth);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
    
      
    }
}
