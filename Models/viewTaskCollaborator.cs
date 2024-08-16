namespace task_manager.Models
{
    public class viewTaskCollaborator
    {
        public long IDTask {  get; set; }
        public long? IDTaskCollaborator {  get; set; }
        public long? IDCollaborator {  get; set; }
        public string vchTaskName { get; set; }
        public string vchDescription { get; set; }
        public string vchCollaboratorName { get; set; }
        public string vchTimeTracked { get; set; }
    }
}
