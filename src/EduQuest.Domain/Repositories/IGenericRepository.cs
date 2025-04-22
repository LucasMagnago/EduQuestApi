using System.Linq.Expressions;

namespace EduQuest.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> SaveAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<bool> ExistsWithIdAsync(int id);

        T? GetById(int id);
        Task<T?> GetByIdAsync(int id);
        Task<T?> FindAsync(Expression<Func<T, bool>> entity);
        IEnumerable<T> GetAll();
        Task<List<T>> GetAllAsync();
        Task<List<T>> Get(Expression<Func<T, bool>>? filter = null,
                          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                          params Expression<Func<T, object>>[] includes);
        Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> Query(Expression<Func<T, bool>>? filter = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

        public Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
    }
}
