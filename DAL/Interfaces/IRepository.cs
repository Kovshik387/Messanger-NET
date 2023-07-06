namespace DAL.Interfaces
{
    public interface IRepository <TContext> where TContext : class
    {
        public Task<IEnumerable<TContext>> GetAllAsync();
        public Task<TContext?> GetItemAsync(int id);
        public Task UpdateAsync(TContext item);
        public Task CreateAsync(TContext item);
        public Task SaveChangesAsync();
    }
}
