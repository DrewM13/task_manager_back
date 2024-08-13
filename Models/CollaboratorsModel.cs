using System.ComponentModel.DataAnnotations;

namespace task_manager.Models
{
    public class CollaboratorsModel
    {
        [Key]
        public long IDCollaborator { get; set; }
        [Required]
        [StringLength(250)]
        public string vchCollaboratorName { get; set; }
        public DateTime dtmCreatedAt { get; set; } = DateTime.Now;
        public DateTime? dtmUpdatedAt { get; set; }
        public DateTime? dtmDeletedAt { get; set; }
    }
}
