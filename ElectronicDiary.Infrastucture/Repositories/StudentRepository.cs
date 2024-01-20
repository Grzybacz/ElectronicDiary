using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Domain.Interfaces;
using ElectronicDiary.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;


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
            bool beUnique = await _dbcontext.Students.AnyAsync(x => x.StudentSurname == student.StudentSurname);
            if (!beUnique)
            {
                _dbcontext.Add(student);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAll()
        => await _dbcontext.Students.ToListAsync();

        public Task<Student?> GetByName(string name)
        => _dbcontext.Students.FirstOrDefaultAsync(cw => cw.StudentName.ToLower() == name.ToLower() );

        public Task<Student?> GetBySurname(string surname)
       => _dbcontext.Students.FirstOrDefaultAsync(cw => cw.StudentSurname.ToLower() == surname.ToLower());

        public async Task<Student> GetDetails(int id)
        {            
            var studentDetails = await _dbcontext.Students.Include(a => a.Address)
                .FirstOrDefaultAsync(x => x.Id == id);      
            return studentDetails;
        }

        public async Task Edit(Student student)
        {            
            _dbcontext.Update(student);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var student = await _dbcontext.Students.FirstOrDefaultAsync(a => a.Id == id);
            var studentAddress = await _dbcontext.Addresses.FirstOrDefaultAsync(a => a.Student.Id == id);
            _dbcontext.Addresses.Remove(studentAddress);
            _dbcontext.Students.Remove(student);            
            await _dbcontext.SaveChangesAsync();
        }
    }
}
