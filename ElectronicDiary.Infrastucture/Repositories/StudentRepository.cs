using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Domain.Interfaces;
using ElectronicDiary.Infrastucture.Persistence;


namespace ElectronicDiary.Infrastucture.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ElectronicDiaryDbContext _dbcontext;
        public StudentRepository(ElectronicDiary.Infrastucture.Persistence.ElectronicDiaryDbContext studentrepository)
        {
            _dbcontext = studentrepository;
        }
        public async Task Create(Student student)
        {
            _dbcontext.Add(student);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
