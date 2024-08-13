using System.ComponentModel.DataAnnotations;

namespace task_manager.Models
{
    public class AuthModel
    {
        [Required]
        public string vchUserName { get; set; }
        [Required]
        public string vchPassword { get; set; }
    }
}
