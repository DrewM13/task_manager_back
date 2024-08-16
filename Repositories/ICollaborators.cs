using task_manager.Models;

namespace task_manager.Repositories
{
    public interface ICollaborators
    {
        public List<CollaboratorsModel> GetAllCollaborators();
        /* public List<CollaboratorsModel> GetCollaboratorsByIDUser(long IDUser);*/
        public CollaboratorsModel GetCollaboratorByID(long IDCollaborator);
        public void CreateOrUpdateAssociationWithTask(TaskCollaboratorModel taskCollaboratorModel);
    }
}
