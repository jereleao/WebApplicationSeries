namespace Series.Database.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public T Add(T item);
        public T Update(T item);
        public Task<T?> GetAsync(int id);
        public void SaveChanges();
    }
}
