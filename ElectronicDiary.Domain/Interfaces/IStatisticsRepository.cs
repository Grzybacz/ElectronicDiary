using ElectronicDiary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Domain.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<List<Student>> GetAll();

        Task<List<Grade>> GetStudentGrades(int studentId);
    }
}
