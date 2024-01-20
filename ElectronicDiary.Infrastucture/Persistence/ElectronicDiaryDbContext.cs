using ElectronicDiary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicDiary.Infrastucture.Persistence
{
    public class ElectronicDiaryDbContext : DbContext
    {
        public ElectronicDiaryDbContext(DbContextOptions<ElectronicDiaryDbContext> options) : base(options)
        {
        }
        public DbSet<School> Schools { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .HasOne(u => u.Address)
                .WithOne(a => a.School)
                .HasForeignKey<Address>(u => u.SchoolId);

            modelBuilder.Entity<Student>()
              .Property(m => m.Id)
              .ValueGeneratedOnAdd(); 
            
            modelBuilder.Entity<Student>()
               .HasOne(u => u.Address)
               .WithOne(a => a.Student)
               .HasForeignKey<Student>(u => u.AddressId);


              
        }

    }
}
