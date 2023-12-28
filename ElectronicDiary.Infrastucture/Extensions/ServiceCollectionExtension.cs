﻿using ElectronicDiary.Infrastucture.Persistence;
using ElectronicDiary.Infrastucture.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Infrastucture.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ElectronicDiaryDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("MySchoolDiaryConnectionString")));

            services.AddScoped<ElectronicDiarySeeder>();
        }
    }
}
