using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_manager.Models
{
    public class TimeTrackersModel
    {
        [Key]
        public long IDTimeTracker { get; set; }
        [Required]
        public DateTime dtmStart { get; set; }
        [Required]
        public DateTime dtmEnd { get; set; }
        [Required]
        [StringLength(200)]
        public string vchTimeZoneID { get; set; }
        [Required]
        public long IDTask { get; set; }
        [Required]
        public long IDCollaborator { get; set; }
        public DateTime dtmCreatedAt { get; set; }
        public DateTime? dtmUpdatedAt { get; set; }
        public DateTime? dtmDeletedAt { get; set; }
    }
}
