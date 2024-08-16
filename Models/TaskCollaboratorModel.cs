using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_manager.Models
{
    public class TaskCollaboratorModel
    {
        [Key]
        public long IDTaskCollaborator {  get; set; }
        [Required]
        public long IDTask { get; set; }
        [Required]
        public long IDCollaborator { get; set; }
    }
}
