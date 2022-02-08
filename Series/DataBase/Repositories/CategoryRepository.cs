using Series.Database.Interfaces;
using Series.DataBase;
using Series.Models;

namespace Series.Database.Repositories
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SeriesContext context) : base(context)
        {
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
