using System.ComponentModel.DataAnnotations;

namespace task_manager.Models
{
    public class UserModel
    {
        [Key]
        public long IDUser { get; set; }
        [Required]
        [StringLength(250)]
        public string vchUserName { get; set; }
        [Required]
        [StringLength(512)]
        public string vchPassword { get; set; }
        public DateTime dtmCreatedAt { get; set; } = DateTime.Now;
        public DateTime? dtmUpdatedAt { get; set; }
        public DateTime? dtmDeletedAt { get; set; }
    }
}
