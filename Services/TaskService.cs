using Microsoft.CodeAnalysis;
using studyProject.Data;
using task_manager.Models;
using task_manager.Repositories;

namespace task_manager.Services
{
    public class TaskService: ITask
    {
        private readonly dataBaseContext _dataBaseContext;

        public TaskService(dataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public List<TasksModel> GetAllTask()
        {
            try
            {
                List<TasksModel> tasksList = new List<TasksModel>();
                tasksList = _dataBaseContext.tTask.ToList();
                return tasksList;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public TasksModel GetTaskByID(long IDTask)
        {
            try
            {
                TasksModel tasks = new TasksModel();
                tasks = _dataBaseContext.tTask.Where(item=>item.IDTask == IDTask).First();
                return tasks;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void UpdateTask(TasksModel tasksModel)
        {
            try
            {
                TasksModel tasks = _dataBaseContext.tTask.Find(tasksModel.IDTask);
                if(tasks != null)
                {
                    tasks.vchTaskName = tasksModel.vchTaskName;
                    tasks.vchDescription = tasksModel.vchDescription;
                    tasks.dtmUpdatedAt = DateTime.Now;
                    _dataBaseContext.tTask.Update(tasks);
                    _dataBaseContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public TasksModel CreateTask(TasksModel tasksModel)
        {
            try
            {
                tasksModel.dtmCreatedAt = DateTime.Now;
                _dataBaseContext.tTask.Add(tasksModel);
                _dataBaseContext.SaveChanges();
                return tasksModel;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void DeleteTask(long IDTask)
        {
            try
            {
                TasksModel Tasks = _dataBaseContext.tTask.Find(IDTask);
                if (Tasks == null)
                {
                    throw new ArgumentException("O IDTask informado não existe");
                }
                List<TimeTrackersModel> TimeTrackersList =  _dataBaseContext.tTimeTracker.ToList().Where(item => item.IDTask == IDTask).ToList();

                if (TimeTrackersList.Any())
                {
                    _dataBaseContext.tTimeTracker.RemoveRange(TimeTrackersList);
                }
               var TaskCollaborator = _dataBaseContext.tTaskCollaborator.Where(item => item.IDTask == IDTask);
                _dataBaseContext.tTaskCollaborator.RemoveRange(TaskCollaborator);
                _dataBaseContext.tTask.Remove(Tasks);
                _dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public List<viewTaskCollaborator> viewListTask(long IDProject)
        {
            try
            {
                viewTaskCollaborator vTaskCollaborator = new viewTaskCollaborator();
                List<viewTaskCollaborator> vListTaskCollaborator = new List<viewTaskCollaborator>();
                var query = from t in _dataBaseContext.tTask
                            join p in _dataBaseContext.tProject on t.IDProject equals p.IDProject
                            join tc in _dataBaseContext.tTaskCollaborator on t.IDTask equals tc.IDTask into taskCollaboratorGroup
                            from tc in taskCollaboratorGroup.DefaultIfEmpty()
                            join c in _dataBaseContext.tCollaborator on tc.IDCollaborator equals c.IDCollaborator into collaboratorGroup
                            from c in collaboratorGroup.DefaultIfEmpty()
                            where p.IDProject == IDProject
                            select new
                            {
                                IDTaskCollaborator = tc == null ? (long?)null : tc.IDTaskCollaborator,
                                t.IDTask,
                                t.vchTaskName,
                                t.vchDescription,
                                IDCollaborator = c == null ? (long?)null : c.IDCollaborator,
                                vchCollaboratorName = c == null ? null : c.vchCollaboratorName
                            };
                query.ToList().ForEach(item =>
                {
                    vTaskCollaborator = new viewTaskCollaborator()
                    {
                        IDCollaborator = item.IDCollaborator,
                        IDTask = item.IDTask,
                        IDTaskCollaborator = item.IDTaskCollaborator,
                        vchTaskName = item.vchTaskName,
                        vchDescription = item.vchDescription,
                        vchCollaboratorName = item.vchCollaboratorName
                    };
                    vListTaskCollaborator.Add(vTaskCollaborator);
                });
                
                return vListTaskCollaborator;

            }
            catch (Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
