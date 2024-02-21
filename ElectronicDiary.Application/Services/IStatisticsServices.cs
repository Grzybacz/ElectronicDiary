using ElectronicDiary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Application.Services
{
    public interface IStatisticsServices
    {
        public Task<List<Student>> GetAll();

        public Task<List<Grade>> GetStudentGrades(int studentId);
    }
}
