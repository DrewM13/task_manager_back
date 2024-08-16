namespace task_manager.Models
{
    public class DashboardModel
    {
        public long IDProject { get; set; }
        public string vchProjectName { get; set; }
        public List<TaskCollaborator> TaskCollaborator { get; set; }
    }
    public class TaskCollaborator
    {
        public long? IDTask { get; set; }
        public long? IDCollaborator { get; set; }
        public string vchTaskName { get; set; }
        public string vchDescription { get; set; }
        public string vchCollaboratorName { get; set; }
        public List<TimeTracked> timeTrackeds { get; set; }

    }
    public class TimeTracked
    {
        public long? IDTimeTracked { get; set; }
        public DateTime? dtmStart { get; set; }
        public DateTime? dtmEnd { get; set; }
        public string vchTimeZoneID { get; set; }
    }
    public class ReqDashboard
    {
        public long? IDProject { get; set; }
        public long? IDCollaborator { set; get; }
    }
}
