using ElectronicDiary.Domain.Entities;
using ElectronicDiary.Domain.Interfaces;
using FluentValidation;



namespace ElectronicDiary.Application.Validator
{
    public class ElectronicDiaryValidator : AbstractValidator<ElectronicDiary.Domain.Entities.Student>
    {
        public bool BeUniqueStudent(string name, List<Student> existingStudent)
        {

            return existingStudent.All(p => p.StudentName != name);
        }

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
                      

            RuleFor(c => c.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("The date must be in the past");



        }

       

    }




    
}
