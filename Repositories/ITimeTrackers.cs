using task_manager.Models;

namespace task_manager.Repositories
{
    public interface ITimeTrackers
    {
        public List<TimeTrackersModel> GetAllTimeTracker();
        public void UpdateTimeTracker(TimeTrackersModel timeTrackersModel);
        public void CreateTimeTracker(TimeTrackersModel timeTrackersModel);
        public void DeleteTimeTracker(long IDTimeTracker);

    }
}
