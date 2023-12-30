
namespace ElectronicDiary.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task Create(Domain.Entities.Student student);
    }
}
