using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Infrastucture.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Infrastucture.Seeder
{
    public class ElectronicDiarySeeder
    {
        private readonly ElectronicDiaryDbContext _dbcontext;
        public ElectronicDiarySeeder(ElectronicDiaryDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Seed()
        {
            if (await _dbcontext.Database.CanConnectAsync())
            {
                if(!_dbcontext.Schools.Any())
                {
                    var school = new Domain.Entities.School()
                    {
                        Name = "Carolinum",
                        Type = "primary school",

                        Address = new()
                    {
                            NameCity = "Kraków",
                            Street = "Gimnazjalna",
                            PostalCode = "31-100"

                        }
                    };
                    _dbcontext.Schools.Add(school);
                    await _dbcontext.SaveChangesAsync();
                
                }

            }
        }
    }
}
