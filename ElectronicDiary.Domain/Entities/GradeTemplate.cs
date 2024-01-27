using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Domain.Entities
{
    public class GradeTemplate
    {
        public int Id { get; set; }

        public string GradeSign { get; set; }

        public double GradeValue { get; set; }

        public IEnumerable<Grade> Grades { get; set; }
    }
}
