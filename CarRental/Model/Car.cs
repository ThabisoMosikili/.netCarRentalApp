using System.ComponentModel.DataAnnotations;

namespace CarRental.Model
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter car name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the price per kilometer.")]
        public decimal PricePerKM  { get; set; }
        [Required]
        public DateTime PickUpDate  { get; set; }
        [Range(typeof(DateTime), "2023/04/16", "2023/12/25")]
        [Required(ErrorMessage = "Please specify the return date.")]
        public DateTime ReturnDate { get; set; }
        [Required(ErrorMessage = "Please enter car description.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please choose the type of the car.")]
        public int ModelNo { get; set; }
        public int CarTypeId { get; set; }
        //Navigation property
        public string Slug =>
            Name?.Replace(' ', '-').ToLower() + '-' + ModelNo.ToString();

        public CarType CarType { get; set; }
    }
}
