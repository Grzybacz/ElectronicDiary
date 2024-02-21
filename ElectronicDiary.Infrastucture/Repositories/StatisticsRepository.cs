using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Domain.Interfaces;
using ElectronicDiary.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicDiary.Infrastucture.Repositories
{
    public class StatisticsRepository :IStatisticsRepository
    {
        private readonly ElectronicDiaryDbContext _dbcontext;
        public StatisticsRepository(ElectronicDiary.Infrastucture.Persistence.ElectronicDiaryDbContext statisticsrepository)
        {
            _dbcontext = statisticsrepository;
        }
        public Task<List<Student>> GetAll()
         => _dbcontext.Students.ToListAsync();

        public async Task<List<Grade>> GetStudentGrades(int studentId)
        {
            Student student = await _dbcontext.Students.FirstOrDefaultAsync(s => s.Id == studentId);
            List<Grade> grades = _dbcontext.Grades
                .Include(g => g.Subject)
                .Where(s => s.Student.Id == student.Id).ToList();            

            return (grades);
        }


    }
}
