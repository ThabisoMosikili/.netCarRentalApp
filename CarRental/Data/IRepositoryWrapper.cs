namespace CarRental.Data
{
    public interface IRepositoryWrapper
    {
        ICarRepository Car { get; }
        ICarTypeRepository CarType { get; }
        IEnquiryRepository Enquiry { get; }
        void Save();
    }
}
