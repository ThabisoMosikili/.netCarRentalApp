using CarRental.Data.DataAccess;
using CarRental.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace CarRental.Data
{
    public class CarRepository:RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(CarDbContext carDbContext):base(carDbContext)
        { 
        }

        public IEnumerable<Car> GetCarsWithCarTypeDetails()
        {
            return _carDbContext.Cars
                .Include(c => c.CarType);
        }

        public IEnumerable<Car> GetCarsWithCarTypeQueryOptions(CarQueryOptions<Car> options)
        {
            IQueryable<Car> query = _carDbContext.Cars
                .Include(c => c.CarType);

            if (options.HasWhere)
                query = query.Where(options.Where);

            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "asc")
                    query = query.OrderBy(options.OrderBy);
                else
                    query = query.OrderByDescending(options.OrderBy);
            }

            return query.ToList();
        }
    }
}
