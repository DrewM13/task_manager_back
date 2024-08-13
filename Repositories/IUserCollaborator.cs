using task_manager.Models;

namespace task_manager.Repositories
{
    public interface IUserCollaborator
    {
        public List<UserCollaboratorModel> GetUserCollaborator();
        public UserCollaboratorModel GetUserCollaboratorByIDUser();
        public UserCollaboratorModel GetUserCollaboratorByIDCollaborator();
        public UserCollaboratorModel GetUserCollaboratorByID();
    }
}
