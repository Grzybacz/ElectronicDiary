using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string? NameCity { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public School School { get; set; }
        public int SchoolId { get; set; }
    }
}
