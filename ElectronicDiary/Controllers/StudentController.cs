using ElectronicDiary.Application.Services;
using ElectronicDiary.Application.Validator;
using ElectronicDiary.Domain.Entities;
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

        public async Task<IActionResult> Index()
        {
            var student = await _studentServices.GetAll();
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            await _studentServices.Create(student);
            return RedirectToAction(nameof(Index)); //ToDo refactor
        }

        [Route("Student/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
           var studentDetails = await _studentServices.GetDetails(id);
            return View(studentDetails);
        }

        [Route("Student/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var editStudent = await _studentServices.GetDetails(id);
            return View(editStudent);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(Student student)
        {

            if (!ModelState.IsValid)
            {
                return View(student);
            }
            await _studentServices.Edit(student);
            return RedirectToAction(nameof(Index)); //ToDo refactor

        }

        [Route("Student/{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteStudent = await _studentServices.GetDetails(id);
            return View(deleteStudent);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {            
            await _studentServices.Delete(id);
            return RedirectToAction(nameof(Index)); //ToDo refactor
        }
    }
}
