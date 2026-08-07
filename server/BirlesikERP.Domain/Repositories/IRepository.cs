namespace BirlesikERP.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<int> CountAsync();
        Task DeleteAllAsync();
    }
}
