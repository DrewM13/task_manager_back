using task_manager.Models;

namespace task_manager.Repositories
{
    public interface ITask
    {
        public TasksModel GetTaskByID(long IDTask);
        public List<viewTaskCollaborator> viewListTask(long IDTask);
        public void UpdateTask(TasksModel tasksModel);
        public TasksModel CreateTask(TasksModel tasksModel);
        public void DeleteTask(long IDTask);
    }
}
