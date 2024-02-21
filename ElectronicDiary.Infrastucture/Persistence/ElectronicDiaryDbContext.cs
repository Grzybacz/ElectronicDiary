using ElectronicDiary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
        public DbSet<Subject> Subjects { get; set; }        
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GradeTemplate> GradeTemplates { get; set; }
        //public DbSet<GradeSubject> GradesSubjects { get; set; }



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

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Grade)
                .WithOne(g => g.Student)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Grade>()
            .HasOne(g => g.Subject)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.SubjectId);


            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Template)
                .WithMany(t => t.Grades)
                .HasForeignKey(g => g.GradeTemplateId);


        }

    }
}
