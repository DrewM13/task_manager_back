using System.Threading.Tasks;
using task_manager.Models;

namespace task_manager.Repositories
{
    public interface ITimeTrackers
    {
        public List<TimeTrackersModel> GetAllTimeTracker();
        public List<TimeTrackersModel> GetByIDTaskTimeTracker(long IDTask);
        public void CreateTimeTracker(List<TimeTrackersModel> timeTrackersModel);
        public void DeleteTimeTracker(List<TimeTrackersModel> timeTrackersModel);

    }
}
