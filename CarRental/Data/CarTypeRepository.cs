using CarRental.Model;

namespace CarRental.Data
{
    public class CarTypeRepository:RepositoryBase<CarType>, ICarTypeRepository
    {
        public CarTypeRepository(CarDbContext carDbContext):base(carDbContext)
        {
            
        }
    }
}
