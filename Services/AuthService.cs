using studyProject.Data;
using task_manager.Models;
using task_manager.Repositories;
using task_manager.Utils;

namespace task_manager.Services
{
    public class AuthService : IAuth
    {
        public bool IsAuthenticated { get; set; }
        private readonly dataBaseContext _dataBaseContext;

        public AuthService(dataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public string Login(AuthModel auth)
        {
            try
            {
                string password = criptoPWD.encrypt(auth.vchPassword);

               var teste = _dataBaseContext.tUser.FirstOrDefault(user=>user.vchPassword == password);
                return null;
            } catch
            {
                return null;
            }
        }
    }
}