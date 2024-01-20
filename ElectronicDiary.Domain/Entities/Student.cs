using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }        
        public string? StudentName { get; set;}             
        public string? StudentSurname { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;      
        public DateTime DateOfBirth { get; set; } 
        public Address? Address { get; set; }
        public int AddressId { get; set; }


    }
}
