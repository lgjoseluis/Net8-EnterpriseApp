namespace Pacagroup.Ecommerce.Application.Interface.Persistence;

public interface IGenericRepository<T> where T : class
{
    #region async methods
    Task<bool> InsertAsync(T entity);

    Task<bool> UpdateAsync(T entity);

    Task<bool> DeleteAsync(string id);

    Task<T?> GetAsync(string id);

    Task<IEnumerable<T>> GetAllAsync();
    #endregion
}
