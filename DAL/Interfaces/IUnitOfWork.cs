namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IChatRepository ChatRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public Task SaveChangesAsync();
    }
}
