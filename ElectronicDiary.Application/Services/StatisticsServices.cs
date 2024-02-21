using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Application.Services
{
    public class StatisticsServices : IStatisticsServices
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsServices(IStatisticsRepository statistic)
        {
            _statisticsRepository = statistic;
        }
        public async Task<List<Student>> GetAll()
        {
            var students = await _statisticsRepository.GetAll();
            return students;
        }

        public async Task<List<Grade>> GetStudentGrades(int studentId)
        {
            var students = await _statisticsRepository.GetStudentGrades(studentId);
            return students;
        }
    }
}
