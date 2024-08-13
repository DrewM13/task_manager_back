using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_manager.Models
{
    [Table("tTask")]
    public class TasksModel
    {
        [Key]
        public long IDTask { get; set; }
        [Required]
        [StringLength(250)]
        public string vchTaskName { get; set; }
        [Required]
        public long IDProject { get; set; }
        public DateTime dtmCreatedAt { get; set; }
        public DateTime? dtmUpdatedAt { get; set; }
        public DateTime? dtmDeletedAt { get; set; }
    }

}
