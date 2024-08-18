using studyProject.Data;
using task_manager.Models;
using task_manager.Repositories;

namespace task_manager.Services
{
    public class TimeTrackersService:ITimeTrackers
    {
        private readonly dataBaseContext _dataBaseContext;

        public TimeTrackersService(dataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public List<TimeTrackersModel> GetByIDTaskTimeTracker(long IDTask)
        {
            try
            {
                List<TimeTrackersModel> TimeTrackersList = new List<TimeTrackersModel>();
                TimeTrackersList = _dataBaseContext.tTimeTracker.Where(item=> item.IDTask == IDTask).ToList();
                return TimeTrackersList;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void CreateTimeTracker(List<TimeTrackersModel> timeTrackersModel)
        {
            try
            {
                List<TimeTrackersModel> auxTimeTrackersModel = timeTrackersModel.Select(item =>
                {
                    item.dtmCreatedAt = DateTime.Now;
                    return item;
                }).ToList();
                _dataBaseContext.tTimeTracker.AddRange(auxTimeTrackersModel);
                _dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void DeleteTimeTracker(List<TimeTrackersModel> timeTrackersModel)
        {
            try
            {
               
                _dataBaseContext.tTimeTracker.RemoveRange(timeTrackersModel);
                _dataBaseContext.SaveChanges();    
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }
}
