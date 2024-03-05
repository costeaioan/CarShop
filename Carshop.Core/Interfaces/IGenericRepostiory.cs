using Carshop.Core.Entities;

namespace CarShop.Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        //Task<IReadOnlyList<T>> GetAllAsync();
        //Task<T> GetByIdAsync(int id);

        //void DeleteAsync(T entity);
        //void UpdateAsync(T entity);

        //void Add(T entity);
        //void Update(T entity);
        //void Delete(T entity);

        public IEnumerable<T> GetAll();
        public T GetByID(int id);
        public void Delete(int id);
        public void Update(T entity);
        public void Add(T entity);

        public void SaveChanges();


    }
}
