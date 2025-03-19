using CarRental.Model;

namespace CarRental.Data
{
    public interface IEnquiryRepository
    {
        IQueryable<Enquiry> GetAll { get; }
        void AddEnquiry(Enquiry enquiry);
        void SaveChanges();
    }
}
