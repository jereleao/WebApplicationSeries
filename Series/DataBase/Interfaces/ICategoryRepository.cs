using Series.Models;

namespace Series.Database.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IEnumerable<Category> GetAll();
    }
}
