using CarRental.Data;
using CarRental.Model;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class EnquiryController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public EnquiryController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
       
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Enquiry enquiry)
        {
            enquiry.EnquiryDate = DateTime.Now;
            if (ModelState.IsValid) 
            {
                _repositoryWrapper.Enquiry.Add(enquiry);
                TempData["Message"] = $" Thanks {enquiry.Name}, an enquiry has been added";
                _repositoryWrapper.Save();
                return RedirectToAction("List");
            }
            else
            {
                return View(enquiry);
            }
        }
        public IActionResult List()
        {
            var Enquiries = _repositoryWrapper.Enquiry.FindAll().OrderBy(e=>e.EnquiryDate);
            return View(Enquiries);
        }
    }
}
