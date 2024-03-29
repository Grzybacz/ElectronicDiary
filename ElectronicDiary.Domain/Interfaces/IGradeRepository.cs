﻿using ElectronicDiary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Domain.Interfaces
{
    public interface IGradeRepository
    {
        Task<List<Subject>> GetAllSubjects();
        Task AddGrade(Grade grade);
        Task<List<Student>> GetAllStudents();
        Task<IEnumerable<GradeTemplate>> GetGradesTemplate();



    }
}
