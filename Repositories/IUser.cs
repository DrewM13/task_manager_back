using task_manager.Models;

namespace task_manager.Repositories
{
    public interface IUser
    {
        public UserModel GetUser(long IDUser);
    }
}
