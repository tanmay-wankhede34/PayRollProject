using Microsoft.AspNetCore.Mvc;
using PayRoll.Domain.Entities;
using PayRoll.Domain.UseCases;
using PayRoll.Presentation.ViewModels;

namespace PayRoll.Presentation.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public IActionResult Index()
        {

            var emp = _employeeRepo.GetAll();
            var vm = new List<EmployeeListViewModel>();
            foreach(var item in emp)
            {
                vm.Add(new EmployeeListViewModel
                {
                    Id = item.Id,
                    EmployeeNumber = item.EmployeeNumber,
                    FullName = item.FullName,
                    Gender = item.Gender,
                    ImageURL = item.ImageURL,
                    DateOfBirth=item.DateOfBirth,
                    DateOfJoined=item.DateOfJoined,
                    PhoneNumber=item.PhoneNumber,
                    Email=item.Email,
                    Address=item.Address,
                    City=item.City,
                    PostalCode=item.PostalCode,
                    Designation=item.Designation,
                    PaymentMethod = item.PaymentMethod,
                    StudentLoan=item.StudentLoan

                });
            }
            
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeViewModel vm)
        {
            var model = new Employee()
            {
                EmployeeNumber = vm.EmployeeNumber,
                FullName = vm.FullName,
                Gender = vm.Gender,
                ImageURL = vm.ImageURL,
                DateOfBirth = vm.DateOfBirth,
                DateOfJoined = vm.DateOfJoined,
                PhoneNumber = vm.PhoneNumber,
                Email = vm.Email,
                Address = vm.Address,
                City = vm.City,
                PostalCode = vm.PostalCode,
                Designation = vm.Designation,
                PaymentMethod = vm.PaymentMethod,
                StudentLoan = vm.StudentLoan

            };

            _employeeRepo.Add(model);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

        var model = _employeeRepo.GetById(id);

            var vm = new EditEmployeeViewModel
            {
                Id = model.Id,
                EmployeeNumber = model.EmployeeNumber,
                FullName = model.FullName,
                Gender = model.Gender,
                ImageURL = model.ImageURL,
                DateOfBirth = model.DateOfBirth,
                DateOfJoined = model.DateOfJoined,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                City = model.City,
                PostalCode = model.PostalCode,
                Designation = model.Designation,
                PaymentMethod = model.PaymentMethod,
                StudentLoan = model.StudentLoan


            };

            return View(vm);
        }

        [HttpPost]

        public IActionResult Edit(EditEmployeeViewModel vm)
        {
            var model = new Employee
            {
                Id = vm.Id,
                EmployeeNumber = vm.EmployeeNumber,
                FullName = vm.FullName,
                Gender = vm.Gender,

                ImageURL = vm.ImageURL,
                DateOfBirth = vm.DateOfBirth,
                DateOfJoined = vm.DateOfJoined,
                PhoneNumber = vm.PhoneNumber,

                Email = vm.Email,
                Address = vm.Address,
                City = vm.City,
                PostalCode = vm.PostalCode,
                Designation = vm.Designation,
                PaymentMethod = vm.PaymentMethod,
                StudentLoan = vm.StudentLoan

            };

            _employeeRepo.Update(model);
            return RedirectToAction("Index");

        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var emp = _employeeRepo.GetById(id);
            _employeeRepo.Delete(emp);

            return RedirectToAction("Index");
        }
    }
}
