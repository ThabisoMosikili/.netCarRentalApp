namespace CarRental.Data
{
    public abstract class RepositoryBase<T>:IRepositoryBase<T> where T : class
    {
        protected CarDbContext _carDbContext;
        public RepositoryBase(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }

        public void Add(T entity)
        {
            _carDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _carDbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return _carDbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _carDbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _carDbContext.Set<T>().Update(entity);
        }
    }
}
