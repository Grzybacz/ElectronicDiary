using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Domain.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;


namespace ElectronicDiary.Application.Validator
{
    public class ElectronicDiaryValidator : AbstractValidator<ElectronicDiary.Domain.Entities.Student>
    {
        public ElectronicDiaryValidator(IStudentRepository repository)
        {
            RuleFor(c => c.StudentName)
           .NotEmpty()
           .MinimumLength(2).WithMessage("Name should have atleast 3 characters")
           .MaximumLength(20).WithMessage("Name should have maximum of 20 characters");           

            RuleFor(c => c.StudentSurname)
           .NotEmpty()
           .MinimumLength(2).WithMessage("Surname should have atleast 2 characters")
           .MaximumLength(20).WithMessage("Surname should have maximum of 20 characters");


            RuleFor(x => new { x.StudentName, x.StudentSurname })
               .Custom((value, context) =>
               {
                   var existingStudentName = repository.GetByName(value.StudentName).Result;
                   var existingStudentSurname = repository.GetBySurname(value.StudentSurname).Result;
                   
                   if (existingStudentName != null && existingStudentSurname != null)
                   {
                      
                       context.AddFailure($"{value.StudentSurname} is not unique name for student");

                   }
               });

            RuleFor(c => c.DateOfBirth)
                .LessThan(p => DateTime.Now).WithMessage("The date must be in the past");



        }

       

    }




    
}
