using ElectronicDiary.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicDiary.Controllers
{
    public class StatisticsController: Controller
    {
        private readonly IStatisticsServices _statisticsServices;
        public StatisticsController(IStatisticsServices statisticsServices)
        {
            _statisticsServices = statisticsServices;
        }
        public async Task<IActionResult> GetStudent()
        {
            var student = await _statisticsServices.GetAll();
            return View("Studentlist", student);
        }

        public async Task<IActionResult> GetGrades(int studentId)
        {
            var student = await _statisticsServices.GetStudentGrades(studentId);
            ViewBag.studentId = student;
            return View("SelectedStudentGrades", student);
        }
    }
    }
