using studyProject.Data;
using task_manager.Models;
using task_manager.Repositories;

namespace task_manager.Services
{
    public class ProjectService:IProject
    {
        private readonly dataBaseContext _dataBaseContext;

        public ProjectService(dataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public List<ProjectModel> GetAllProject()
        {
            try
            {
                List<ProjectModel> ProjectList = new List<ProjectModel>();
                ProjectList = _dataBaseContext.tProject.ToList();
                return ProjectList;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public ProjectModel GetProjectByID(long IDProject)
        {
            try
            {
                ProjectModel Project = new ProjectModel();
                Project = _dataBaseContext.tProject.Find(IDProject);
                return Project;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void UpdateProject(ProjectModel projectModel)
        {
            try
            {
                ProjectModel project = _dataBaseContext.tProject.Find(projectModel.IDProject);
                project.dtmUpdatedAt = DateTime.Now;
                 _dataBaseContext.tProject.Update(project);
                 _dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void CreateProject(ProjectModel projectModel)
        {
            try
            {
                projectModel.dtmCreatedAt = DateTime.Now;
                _dataBaseContext.tProject.Add(projectModel);
                _dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void DeleteProject(long IDProject)
        {
            try
            {
                ProjectModel project = _dataBaseContext.tProject.Find(IDProject);
                if(project == null)
                {
                    throw new ArgumentException("O IDProject informado não existe");
                }
                List<TasksModel> TasksList = _dataBaseContext.tTask.Where(item=>item.IDProject == IDProject).ToList();
                if (TasksList.Any())
                {
                     foreach (TasksModel task in TasksList)
                     {
                         List<TimeTrackersModel> timeTrackersList = _dataBaseContext.tTimeTracker.Where(item=>item.IDTask==task.IDTask).ToList();
                         _dataBaseContext.tTimeTracker.RemoveRange(timeTrackersList);
                     }
                        _dataBaseContext.tTask.RemoveRange(TasksList);
                }

                _dataBaseContext.tProject.Remove(project);
                _dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
