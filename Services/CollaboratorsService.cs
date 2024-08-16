using studyProject.Data;
using task_manager.Models;
using task_manager.Repositories;

namespace task_manager.Services
{
    public class CollaboratorsService:ICollaborators
    {
        private readonly dataBaseContext _dataBaseContext;

        public CollaboratorsService(dataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public List<CollaboratorsModel> GetAllCollaborators()
        {
            try
            {
                List<CollaboratorsModel> collaboratorsList = new List<CollaboratorsModel>();
                collaboratorsList = _dataBaseContext.tCollaborator.ToList();
                return collaboratorsList;
            } catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void CreateOrUpdateAssociationWithTask(TaskCollaboratorModel taskCollaboratorModel)
        {
            try
            {
                TaskCollaboratorModel taskCollaboratorModel1 = _dataBaseContext.tTaskCollaborator.Where(item=>item.IDTask == taskCollaboratorModel.IDTask).FirstOrDefault();
                if (taskCollaboratorModel1 != null)
                {
                    List<TimeTrackersModel> timeTrackersModel = _dataBaseContext.tTimeTracker.Where(item => item.IDTask == taskCollaboratorModel1.IDTask).ToList();
                    if (timeTrackersModel.Any())
                    {
                        _dataBaseContext.tTimeTracker.RemoveRange(timeTrackersModel);
                    }
                    taskCollaboratorModel1.IDCollaborator = taskCollaboratorModel.IDCollaborator;
                    _dataBaseContext.tTaskCollaborator.Update(taskCollaboratorModel1);  
                }
                else
                {
                    _dataBaseContext.tTaskCollaborator.Add(taskCollaboratorModel);
                }

                _dataBaseContext.SaveChanges();
            } catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        /*public List<CollaboratorsModel> GetCollaboratorsByIDUser(long IDUser)
        {
            try
            {
                List<CollaboratorsModel> collaboratorsList = new List<CollaboratorsModel>();
               List<long> auxList = _dataBaseContext.tUserCollaborator.Where(item=>item.IDUser.IDUser == IDUser).Select(item=>item.IDCollaborator.IDCollaborator).ToList();
                collaboratorsList = _dataBaseContext.tCollaborator.Where(item=> auxList.Contains(item.IDCollaborator)).ToList();
                return collaboratorsList;
            } catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }*/
        
        public CollaboratorsModel GetCollaboratorByID(long IDCollaborator)
        {
            try
            {
                CollaboratorsModel collaborator = new CollaboratorsModel();
                collaborator = _dataBaseContext.tCollaborator.Find(IDCollaborator);
                return collaborator;
            } catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
