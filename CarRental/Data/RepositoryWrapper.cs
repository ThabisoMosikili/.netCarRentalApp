namespace CarRental.Data
{
    public class RepositoryWrapper:IRepositoryWrapper
    {
        private ICarRepository _carRepository;
        private ICarTypeRepository _carTypeRepository;
        private IEnquiryRepository _enquiryRepository;
        private CarDbContext _carDbContext;
        public RepositoryWrapper(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }

        public ICarRepository Car
        {
            get
            {
                if(_carRepository==null)
                {
                    _carRepository = new CarRepository(_carDbContext);
                }
                return _carRepository;
            }
        }

        public ICarTypeRepository CarType
        {
            get
            {
                if (_carTypeRepository == null)
                {
                    _carTypeRepository = new CarTypeRepository(_carDbContext);
                }
                return _carTypeRepository;
            }
        }

        public IEnquiryRepository Enquiry
        {
            get
            {
                if (_enquiryRepository == null)
                {
                    _enquiryRepository = new EnquiryRepository(_carDbContext);
                }
                return _enquiryRepository;
            }
        }

        public void Save()
        {
            _carDbContext.SaveChanges();
        }
    }
}
