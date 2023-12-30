namespace ElectronicDiary.Application.Services
{
    public interface IStudentServices
    {
        Task Create (Domain.Entities.Student student);
    }
}