using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Domain.Interfaces;
using ElectronicDiary.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectronicDiary.Infrastucture.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ElectronicDiaryDbContext _dbcontext;
        public GradeRepository(ElectronicDiary.Infrastucture.Persistence.ElectronicDiaryDbContext graderepository)
        {
            _dbcontext = graderepository;
        }
        public Task<List<Subject>> GetAllSubjects()        
        =>  _dbcontext.Subjects.ToListAsync();

        public async Task AddGrade(Grade grade, GradeSubject gradeSubject)
        {
            _dbcontext.Grades.Add(grade);
            await _dbcontext.SaveChangesAsync();
            var gradeSub = new GradeSubject
            {
                GradeId = grade.Id,
                SubjectId = gradeSubject.SubjectId
            };
           
            _dbcontext.GradesSubjects.Add(gradeSub);
            await _dbcontext.SaveChangesAsync();

            
        }
        public Task<List<Student>> GetAllStudents()
        => _dbcontext.Students.ToListAsync();

    }
}
