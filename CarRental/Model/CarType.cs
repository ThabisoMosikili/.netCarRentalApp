using System.ComponentModel.DataAnnotations;

namespace CarRental.Model
{
    public class CarType
    {
        public int CarTypeId { get; set; }

        [Required]
        public string CarTypeName { get; set; }

        //Navigation property
        public List<Car> Car { get; set; }
    }
}
