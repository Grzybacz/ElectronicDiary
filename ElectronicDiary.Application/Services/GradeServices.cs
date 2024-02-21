using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Application.Services
{
    public class GradeServices : IGradeServices
    {
        private readonly IGradeRepository _gradeRepository;
        public GradeServices(IGradeRepository grade)
        {
            _gradeRepository = grade;
        }
        public async Task<List<Subject>> GetAllSubjects()
        {
            var subjects = await _gradeRepository.GetAllSubjects();
            return subjects;
        }

        public async Task AddGrade(Grade grade)
        {
            await _gradeRepository.AddGrade(grade);
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var students = await _gradeRepository.GetAllStudents();
            return students;
        }

        public async Task<IEnumerable<GradeTemplate>> GetGradesTemplate()
        {
            var gradesign = await _gradeRepository.GetGradesTemplate();
            return gradesign;
        }
    }
}
