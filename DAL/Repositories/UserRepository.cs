using DAL.Common;
using DAL.Interfaces;
using DAL.Models;
using DAL.TemporalContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MessagerContext _dbContext;

        public UserRepository(MessagerContext dbContext) => _dbContext = dbContext;

        public Task<User?> AddChats(User user)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task CreateUserAsync(string login, string password,int profile_type, User user)
        {
            if (await _dbContext.Authorizes.FirstOrDefaultAsync(item => item.Login == login) != null)
                throw new RepositoryException("Login already in use");

            user.IdAuthorizeNavigation = new Authorize()
            {
                Login = login,
                Password = password,
                IdRole = profile_type
            };

            await _dbContext.Users.AddAsync(user);
        }
        public async System.Threading.Tasks.Task CreateUserAsync(User user, Authorize authorize)
        {
            if (user == null || authorize == null) throw new RepositoryException("Null");

            user.Datestartwork = DateOnly.FromDateTime(DateTime.UtcNow);
            user.Active = true; user.IdAuthorizeNavigation = authorize;

            await _dbContext.Users.AddAsync(user);
        }

        public Task<IEnumerable<User>> FindAsync(int id_item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetItemAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByLoginAsync(string login, string password)
        {
            return await _dbContext.Users.Include(a => a.IdAuthorizeNavigation).ThenInclude(r => r.IdRoleNavigation).
                FirstOrDefaultAsync(item => item.IdAuthorizeNavigation.Login == login &&
                item.IdAuthorizeNavigation.Password == password);
        }

        public async Task<IEnumerable<User?>> GetUsersByName(string name, string surname)
        {
            return await _dbContext.Users.Where(user =>
                EF.Functions.Like(user.Name, $"%{name}%") || EF.Functions.Like(user.Surname, $"%{surname}%")).
                DistinctBy(user => user.IdUser).ToListAsync(); // What is this?????
        }

        public async System.Threading.Tasks.Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public System.Threading.Tasks.Task UpdateAsync(User item) => System.Threading.Tasks.
            Task.FromResult(_dbContext.Users.Update(item));

        public async System.Threading.Tasks.Task CreateAsync(User user)
        {
			user.Datestartwork = DateOnly.FromDateTime(DateTime.UtcNow);
			user.Active = true;

            var profile = user.IdAuthorizeNavigation;

            await _dbContext.Authorizes.AddAsync(profile);

            user.IdAuthorize = profile.IdAuthorize;

			await _dbContext.Users.AddAsync(user);
		}
    }
}
