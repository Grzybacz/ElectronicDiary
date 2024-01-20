
using ElectronicDiary.Domain.Entities;

namespace ElectronicDiary.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task Create(Domain.Entities.Student student);
        Task<Domain.Entities.Student?> GetByName(string name);
        Task<Domain.Entities.Student?> GetBySurname(string surname);
        Task<IEnumerable<Domain.Entities.Student>> GetAll();
        Task<Student> GetDetails(int id);
        Task Edit(Student student);
        Task Delete(int id);
    }
}

