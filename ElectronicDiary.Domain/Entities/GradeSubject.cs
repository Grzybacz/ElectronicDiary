using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Domain.Entities
{
    public class GradeSubject
    {
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public DateTime PublicationDate { get; set; }

    }
}
