using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Domain.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public string WriteGrade { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Student? Student { get; set; }
        public int StudentId { get; set; }
        public List<Subject> Subjects { get; set; }
        public GradeTemplate Template { get; set; }
        public int GradeTemplateId { get; set; }
    }
}
