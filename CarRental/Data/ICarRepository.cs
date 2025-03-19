using CarRental.Data.DataAccess;
using CarRental.Model;
using System.Reflection;

namespace CarRental.Data
{
    public interface ICarRepository: IRepositoryBase<Car>
    {
        
        IEnumerable<Car> GetCarsWithCarTypeQueryOptions(CarQueryOptions<Car> options);
    }
}
