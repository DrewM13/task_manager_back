using System.ComponentModel.DataAnnotations;

namespace task_manager.Models
{
    public class ProjectModel
    {
        [Key]
        public long IDProject {  get; set; }
        [Required]
        [StringLength(250)]
        public string vchProjectName { get; set; }
        public DateTime dtmCreatedAt { get; set; }
        public DateTime? dtmUpdatedAt { get; set; }
        public DateTime? dtmDeletedAt { get; set; }
    }
}
