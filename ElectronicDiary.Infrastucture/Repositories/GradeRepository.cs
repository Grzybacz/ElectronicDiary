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

        public async Task AddGrade(Grade grade)
        {
            var idtemplate = _dbcontext.GradeTemplates.FirstOrDefault(x => x.GradeSign == grade.WriteGrade);
            if (idtemplate != null)
            {
                grade.GradeTemplateId = idtemplate.Id; // Przypisz wartość do właściwości obiektu Grade.
            }
            _dbcontext.Grades.Add(grade);
            await _dbcontext.SaveChangesAsync();
            

            
        }
        public Task<List<Student>> GetAllStudents()
        => _dbcontext.Students.ToListAsync();

        public async Task<IEnumerable<GradeTemplate>> GetGradesTemplate()
       => await _dbcontext.GradeTemplates.ToListAsync();

    }
}
