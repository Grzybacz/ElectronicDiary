using ElectronicDiary.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicDiary.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;  
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Domain.Entities.Student student)
        {
            await _studentServices.Create(student);
            return RedirectToAction(nameof(Create)); //ToDo refactor
        }
    }
}
