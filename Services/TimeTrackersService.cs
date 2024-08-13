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
        public List<TimeTrackersModel> GetAllTimeTracker()
        {
            try
            {
                List<TimeTrackersModel> TimeTrackersList = new List<TimeTrackersModel>();
                TimeTrackersList = _dataBaseContext.tTimeTracker.ToList();
                return TimeTrackersList;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void UpdateTimeTracker(TimeTrackersModel timeTrackersModel)
        {
            try
            {
                TimeTrackersModel timeTrackers = _dataBaseContext.tTimeTracker.Find(timeTrackersModel.IDTimeTracker);
                timeTrackers.dtmUpdatedAt = DateTime.Now;
                _dataBaseContext.tTimeTracker.Update(timeTrackers);
                _dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void CreateTimeTracker(TimeTrackersModel timeTrackersModel)
        {
            try
            {
                timeTrackersModel.dtmCreatedAt = DateTime.Now;
                 _dataBaseContext.tTimeTracker.Update(timeTrackersModel);
                _dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void DeleteTimeTracker(long IDTimeTracker)
        {
            try
            {
                TimeTrackersModel timeTrackersModel =_dataBaseContext.tTimeTracker.Where(item => item.IDTimeTracker == IDTimeTracker).First();
                if(timeTrackersModel == null)
                {
                    throw new ArgumentException("O IDTimeTracker informado não existe");
                }
               _dataBaseContext.tTimeTracker.Remove(timeTrackersModel);
                _dataBaseContext.SaveChanges();    
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }
}
