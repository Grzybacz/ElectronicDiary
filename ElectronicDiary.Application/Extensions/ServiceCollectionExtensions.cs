using ElectronicDiary.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace ElectronicDiary.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IStudentServices, StudentServices >();
        }
            
    }
}
