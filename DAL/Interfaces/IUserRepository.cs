using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User?> GetUserByLoginAsync(string login, string password);
        //public System.Threading.Tasks.Task CreateUserAsync(string login, string password, int profile_type, User user);
        public Task<IEnumerable<User?>> GetUsersByName(string name, string surname);
    }
}
