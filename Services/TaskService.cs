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
                tasks.dtmUpdatedAt = DateTime.Now;
                _dataBaseContext.tTask.Update(tasks);
                _dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void CreateTask(TasksModel tasksModel)
        {
            try
            {
                tasksModel.dtmCreatedAt = DateTime.Now;
                _dataBaseContext.tTask.Add(tasksModel);
                _dataBaseContext.SaveChanges();

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
                var teste = _dataBaseContext.tTimeTracker.ToList();
                List<TimeTrackersModel> TimeTrackersList =  _dataBaseContext.tTimeTracker.ToList().Where(item => item.IDTask == IDTask).ToList();

                if (TimeTrackersList.Any())
                {
                    _dataBaseContext.tTimeTracker.RemoveRange(TimeTrackersList);
                }

                _dataBaseContext.tTask.Remove(Tasks);
                _dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
