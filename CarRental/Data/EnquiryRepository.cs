using CarRental.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CarRental.Data
{
    public class EnquiryRepository:RepositoryBase<Enquiry>, IEnquiryRepository
    {
        public EnquiryRepository(CarDbContext carDbContext):base(carDbContext)
        {
            
        }
    }
}
