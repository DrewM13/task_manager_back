using task_manager.Models;

namespace task_manager.Repositories
{
    public interface IProject
    {
        public List<ProjectModel> GetAllProject();
        public ProjectModel GetProjectByID(long IDProject);
        public void UpdateProject(ProjectModel projectModel);
        public void CreateProject(ProjectModel projectModel);
        public void DeleteProject(long IDProject);
    }
}
