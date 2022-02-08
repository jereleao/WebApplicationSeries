
using Series.Database.Interfaces;
using Series.DataBase;

namespace Series.Database.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly SeriesContext _context;
        public BaseRepository(SeriesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context ));
        }
        public T Add(T item)
        {
            return _context.Set<T>().Add(item).Entity;
        }
        public T Update(T item)
        {
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
