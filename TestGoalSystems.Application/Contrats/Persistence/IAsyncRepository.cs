using System.Linq.Expressions;
using TestGoalSystems.Domain.Common;

namespace TestGoalSystems.Application.Contrats.Persistence
{
    /// <summary>
    /// Generic repository methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        /// <summary>
        /// List of items
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// List of items by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// List of items by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeString"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        string? includeString = null,
                                        bool disableTracking = true);

        /// <summary>
        /// List of items by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <param name="disableTracking"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        List<Expression<Func<T, object>>>? includes = null,
                                        bool disableTracking = true);

        /// <summary>
        /// Item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Add entity in memory
        /// </summary>
        /// <param name="entity"></param>
        void AddEntity(T entity);

        /// <summary>
        /// Update entity in memory
        /// </summary>
        /// <param name="entity"></param>
        void UpdateEntity(T entity);

        /// <summary>
        /// Delete entiry en memory
        /// </summary>
        /// <param name="entity"></param>
        void DeleteEntity(T entity);
    }
}
