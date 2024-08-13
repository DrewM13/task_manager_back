using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_manager.Models
{
    public class UserCollaboratorModel
    {
        [Key]
        public long IDUserCollaborator {  get; set; }
        [Required]
        [ForeignKey("tUser")]
        public virtual UserModel IDUser { get; set; }
        [Required]
        [ForeignKey("tCollaborator")]
        public virtual CollaboratorsModel IDCollaborator { get; set; }
    }
}
