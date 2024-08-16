using task_manager.Models;

namespace task_manager.Repositories
{
    public interface IDashboard
    {
        public List<DashboardModel> GetDashboard(ReqDashboard reqDashboard);
    }
}
