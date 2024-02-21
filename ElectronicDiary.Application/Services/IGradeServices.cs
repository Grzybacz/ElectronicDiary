using ElectronicDiary.Domain.Entities;


namespace ElectronicDiary.Application.Services
{
    public interface IGradeServices
    {
        public Task<List<Subject>> GetAllSubjects();

        public Task AddGrade(Grade grade);

        public Task<List<Student>> GetAllStudents();

        public Task<IEnumerable<GradeTemplate>> GetGradesTemplate();
    }
}
