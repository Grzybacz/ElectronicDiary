using ElectronicDiary.Application.Services;
using ElectronicDiary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace ElectronicDiary.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeServices _gradeServices;
        public GradeController(IGradeServices gradeServices)
        {
            _gradeServices = gradeServices;
        }
        public async Task<IActionResult> Index()
        {
            var subjects = await _gradeServices.GetAllSubjects();
            return View(subjects);
        }

        public async Task<IActionResult> AddGrade(int subjectId)
        {
            ViewBag.SubjectId = subjectId;
            var student = await _gradeServices.GetAllStudents();

            return View("ListStudents", student);
        }

        public async Task<IActionResult> AddGradeStudent(int subjectId, int studentId)
        {
            ViewBag.SubjectId = subjectId;
            ViewBag.StudentId = studentId;
            var gradesign = await _gradeServices.GetGradesTemplate();

            return View("Create", gradesign);
        }

        [HttpPost]
        public async Task<IActionResult> AddGrade(int subjectId, string selectedGrade, int studentId)
        {
           
            Grade grade = new Grade
            {
                WriteGrade = selectedGrade, 
                StudentId = studentId,  
                SubjectId = subjectId,
                CreatedAt = DateTime.UtcNow,
                
            };

            

            await _gradeServices.AddGrade( grade);

            return RedirectToAction("Index");
        }
    }
}
