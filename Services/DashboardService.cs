using Microsoft.CodeAnalysis;
using studyProject.Data;
using System.Collections.Generic;
using task_manager.Models;
using task_manager.Repositories;

namespace task_manager.Services
{
    public class DashboardService: IDashboard
    {
        private readonly dataBaseContext _dataBaseContext;

        public DashboardService(dataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public List<DashboardModel> GetDashboard(ReqDashboard reqDashboard)
        {
            try
            {
                List<DashboardModel> listDashboardModel = new List<DashboardModel>();
                DashboardModel DashboardModel = new DashboardModel();
                var query = from t in _dataBaseContext.tTask
                            join p in _dataBaseContext.tProject on t.IDProject equals p.IDProject
                            join tc in _dataBaseContext.tTaskCollaborator on t.IDTask equals tc.IDTask into taskCollaboratorGroup
                            from tc in taskCollaboratorGroup.DefaultIfEmpty()
                            join c in _dataBaseContext.tCollaborator on tc.IDCollaborator equals c.IDCollaborator into collaboratorGroup
                            from c in collaboratorGroup.DefaultIfEmpty()
                            join tt in _dataBaseContext.tTimeTracker on new { tc.IDCollaborator, t.IDTask } equals new { tt.IDCollaborator, tt.IDTask } into timeTrackerGroup
                            from tt in timeTrackerGroup.DefaultIfEmpty()
                            where (reqDashboard.IDProject == null || p.IDProject == reqDashboard.IDProject)
                                  && (reqDashboard.IDCollaborator == null || c.IDCollaborator == reqDashboard.IDCollaborator)
                            select new
                            {
                                IDProject = p.IDProject,
                                vchProjectName = p.vchProjectName,
                                IDTaskCollaborator = tc == null ? (long?)null : tc.IDTaskCollaborator,
                                t.IDTask,
                                t.vchTaskName,
                                t.vchDescription,
                                IDCollaborator = c == null ? (long?)null : c.IDCollaborator,
                                vchCollaboratorName = c == null ? null : c.vchCollaboratorName,
                                IDTimeTracker = tt == null ? (long?)null : tt.IDTimeTracker,
                                dtmStart = tt == null ? (DateTime?)null : tt.dtmStart,
                                dtmEnd = tt == null ? (DateTime?)null : tt.dtmEnd,
                                vchTimeZoneID = tt.vchTimeZoneID
                            };
                foreach (var item in query.ToList().GroupBy(item => item.IDProject))
                {

                    List<TaskCollaborator> listTaskCollaborator = new List<TaskCollaborator>();
                    
                    foreach (var item2 in item.GroupBy(item=>item.IDTask))
                    {
                        List<TimeTracked> listTimeTracked = new List<TimeTracked>();
                        foreach (var item3 in item2)
                        {
                            TimeTracked timeTracked = new TimeTracked()
                            {
                                IDTimeTracked = item3.IDTimeTracker,
                                dtmStart = item3.dtmStart,
                                dtmEnd = item3.dtmEnd,
                                vchTimeZoneID = item3.vchTimeZoneID
                            };
                            listTimeTracked.Add(timeTracked);
                        }
                        TaskCollaborator taskCollaborator = new TaskCollaborator()
                        {
                            IDTask = item2.First().IDTask,
                            vchTaskName = item2.First().vchTaskName,
                            vchDescription = item2.First().vchDescription,
                            vchCollaboratorName = item2.First().vchCollaboratorName,
                            IDCollaborator = item2.First().IDCollaborator,
                            timeTrackeds = listTimeTracked
                        };

                        listTaskCollaborator.Add(taskCollaborator);
                    }
                    
                    
                    DashboardModel = new DashboardModel()
                    {
                        IDProject = item.First().IDProject,
                        vchProjectName = item.First().vchProjectName,
                        TaskCollaborator = listTaskCollaborator
                    };
                    listDashboardModel.Add(DashboardModel);
                }
                return listDashboardModel;
            } catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
