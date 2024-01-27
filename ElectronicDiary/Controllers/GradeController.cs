using ElectronicDiary.Application.Services;
using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Infrastucture.Migrations;
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
           
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> AddGrade(int subjectId, string writeGrade)
        {
           
            Grade grade = new Grade
            {
                WriteGrade = writeGrade, 
                StudentId = 4,
                GradeTemplateId =1,
                CreatedAt = DateTime.UtcNow,
                
            };

            var gradeSubject = new Domain.Entities.GradeSubject
            {
                SubjectId = subjectId,                
                PublicationDate = DateTime.UtcNow
            };

            await _gradeServices.AddGrade( grade, gradeSubject);

            return RedirectToAction("Index");
        }
    }
}
