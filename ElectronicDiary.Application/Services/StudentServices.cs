using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Domain.Interfaces;

namespace ElectronicDiary.Application.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;
        public StudentServices(IStudentRepository student)
        {
                _studentRepository = student;
        }

        public async Task Create(Domain.Entities.Student student)
        {
            
            await _studentRepository.Create(student);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            var students = await _studentRepository.GetAll();
            return students;
        }

        public async Task<Student> GetDetails(int id)
        {
            var studentDetails = await _studentRepository.GetDetails(id);
            return studentDetails;
        }
        public async Task Edit(Student student)
        {

            await _studentRepository.Edit(student);
        }

        public async Task Delete(int id)
        {
            await _studentRepository.Delete(id);
        }
    }
}
