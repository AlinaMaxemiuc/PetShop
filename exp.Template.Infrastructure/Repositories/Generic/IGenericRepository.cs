using System.Linq.Expressions;

namespace exp.Template.Infrastructure.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAllQuerable();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<int> AddRangeAsync(ICollection<T> t);
        Task<int> UpdateRangeAsync(ICollection<T> fields);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<int> DeleteAsync(T t);
        Task<bool> Exist(Expression<Func<T, bool>> expression);

    }
}
