using Series.Models;

namespace Series.Database.Interfaces
{
    public interface ISerieRepository : IBaseRepository<Serie>
    {
        Task<IEnumerable<Serie>> GetAll();
        Task<IEnumerable<Serie>> GetSeriesByCategory(int id);
        bool Delete(int id);
    }
}
