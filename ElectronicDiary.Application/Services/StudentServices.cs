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
    }
}
