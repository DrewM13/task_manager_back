using task_manager.Models;

namespace task_manager.Repositories
{
    public interface IAuth
    {
        public string Login(AuthModel auth);
    }
}
