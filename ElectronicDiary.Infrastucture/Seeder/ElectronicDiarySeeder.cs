using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
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
                if(!_dbcontext.Schools.Any() && !_dbcontext.Addresses.Any())
                {
                    var school = new Domain.Entities.School()
                    {
                        Name = "Magnum School",
                        Type = "primary school",

                        Address = new()
                        {
                            NameCity = "Kraków",
                            Street = "Gimnazjalna",
                            PostalCode = "31-100",                            
                          
                        }                       
                                             
                    };

                    _dbcontext.Schools.Add(school);
                    await _dbcontext.SaveChangesAsync();                    

                }

                if (!_dbcontext.Subjects.Any() )
                {
                    var subjects = new[]
                    {
                        new Domain.Entities.Subject
                        {
                        Name = "Matematyka"
                        },
                        new Domain.Entities.Subject
                        {
                        Name = "Biologia"
                        },
                        new Domain.Entities.Subject
                        {
                        Name = "Geografia"
                        },
                        new Domain.Entities.Subject
                        {
                        Name = "Język polski"
                        },
                        new Domain.Entities.Subject
                        {
                        Name = "Chemia"
                        },
                        new Domain.Entities.Subject
                        {
                        Name = "Fizyka"
                        },

                    };
                    _dbcontext.Subjects.AddRange(subjects);
                    await _dbcontext.SaveChangesAsync();                   
                   
                }

                if (!_dbcontext.GradeTemplates.Any())
                {
                    var gradeTemplate = new[]
                    {
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "1-",
                        GradeValue = 0.75
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "1",
                        GradeValue = 1
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "1+",
                        GradeValue = 1.75
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "2-",
                        GradeValue = 1.75
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "2",
                        GradeValue = 2
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "2+",
                        GradeValue = 2.75
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "3-",
                        GradeValue = 2.75
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "3",
                        GradeValue = 3
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "3+",
                        GradeValue = 3.75
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "4-",
                        GradeValue = 3.75
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "4",
                        GradeValue = 4
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "4+",
                        GradeValue = 4.75
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "5-",
                        GradeValue = 4.75
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "5",
                        GradeValue = 5
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "6-",
                        GradeValue = 5.75
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "6",
                        GradeValue = 6
                        },
                        new Domain.Entities.GradeTemplate
                        {
                        GradeSign = "6+",
                        GradeValue = 6.75
                        },


                    };
                    _dbcontext.GradeTemplates.AddRange(gradeTemplate);
                    await _dbcontext.SaveChangesAsync();



                }

            };            
                        

                   

                

            
        }
    }
}
