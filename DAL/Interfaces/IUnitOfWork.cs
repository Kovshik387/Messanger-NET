namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IChatRepository ChatRepository { get; }
        public IRoleRepository RoleRepository { get; }
		public IMessageRepository MessageRepository{ get; }
		public IUserChatsRepository UserChatsRepository{ get; }
        public ITaskRepository TaskRepository { get; }

		public Task SaveChangesAsync();
    }
}
