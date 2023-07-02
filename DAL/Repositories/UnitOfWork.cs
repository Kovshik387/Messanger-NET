
using DAL.Interfaces;

namespace DAL.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IChatRepository _chatRepository = default!;
        private IUserRepository _userRepository = default!;
        private IRoleRepository _roleRepository = default!;

        private readonly MessagerContext _messagerContext = default!;

        public UnitOfWork(MessagerContext messagerContext) : base() => _messagerContext = messagerContext;

        public IChatRepository ChatRepository
        {
            get
            {
                if (_chatRepository == null) _chatRepository = new ChatRepositrory(_messagerContext);
                return _chatRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null) _userRepository = new UserRepository(_messagerContext);
                return _userRepository;
            }
        }

		public IRoleRepository RoleRepository
		{
			get
			{
				if (_roleRepository == null) _roleRepository = new RoleRepository(_messagerContext);
				return _roleRepository;
			}
		}

		public async Task SaveChangesAsync() => await _messagerContext.SaveChangesAsync();
    }
}
