using ElectronicDiary.Application.Services;
using ElectronicDiary.Application.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace ElectronicDiary.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IStudentServices, StudentServices >();
            
            services.AddValidatorsFromAssemblyContaining<ElectronicDiaryValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
            
    }
}
