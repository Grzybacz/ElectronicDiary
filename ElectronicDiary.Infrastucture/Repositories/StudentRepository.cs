using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Domain.Interfaces;
using ElectronicDiary.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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

        public async Task<IEnumerable<Student>> GetAll()
        => await _dbcontext.Students.ToListAsync();

        public Task<Student?> GetByName(string name)
        => _dbcontext.Students.FirstOrDefaultAsync(cw => cw.StudentName.ToLower() == name.ToLower() );

        public Task<Student?> GetBySurname(string surname)
       => _dbcontext.Students.FirstOrDefaultAsync(cw => cw.StudentSurname.ToLower() == surname.ToLower());
    }
}
