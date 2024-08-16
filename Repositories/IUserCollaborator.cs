using task_manager.Models;

namespace task_manager.Repositories
{
    public interface IUserCollaborator
    {
        public List<TaskCollaboratorModel> GetUserCollaborator();
        public TaskCollaboratorModel GetUserCollaboratorByIDUser();
        public TaskCollaboratorModel GetUserCollaboratorByIDCollaborator();
        public TaskCollaboratorModel GetUserCollaboratorByID();
    }
}
