
using Series.Database.Interfaces;
using Series.DataBase;
using Series.Models;

namespace Series.Database.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly SeriesContext _context;
        public BaseRepository(SeriesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context ));
        }
        public T Add(T item)
        {
            item.createdAt = DateTime.Now;
            return _context.Set<T>().Add(item).Entity;
        }
        public T Update(T item)
        {
            item.updatedAt = DateTime.Now;
            return _context.Update(item).Entity;
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
