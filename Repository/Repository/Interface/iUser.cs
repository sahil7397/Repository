using Repository.Models;

namespace Repository.Repository.Interface
{
    public interface iUser
    {
        Task<IEnumerable<User>> Getusers();
        Task<int> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<bool>UpdateRecord(User user);
    }
}
