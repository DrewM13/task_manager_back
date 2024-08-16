using task_manager.Models;
using task_manager.Repositories;

namespace task_manager.Models
{
    public class viewDashboard
    {
        public long IDTask { get; set; }
        public long IDProject { get; set; }
        public long? IDTaskCollaborator { get; set; }
        public long? IDCollaborator { get; set; }
        public long? IDTimeTracker { get; set; }
        public string vchTaskName { get; set; }
        public string vchProjectName { get; set; }
        public string vchDescription { get; set; }
        public string vchCollaboratorName { get; set; }
        public DateTime? dtmStart { get; set; }
        public DateTime? dtmEnd { get; set; }
        public string vchTimeZoneID { get; set; }
    }
}