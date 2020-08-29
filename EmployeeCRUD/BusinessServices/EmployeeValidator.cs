using EmployeeCRUD.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.BusinessServices
{
    public class EmployeeValidator:AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleSet("update", () =>
            {
                RuleFor(m => m.ID)
                 .NotNull()
                 .WithMessage("Employee ID cannot be blank.")
                 .GreaterThan(0)
                 .WithMessage("Employee ID must be greather than 0."); 
            });
            
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Employee Name cannot be blank.")
                .MinimumLength(3)
                .WithMessage("Employee name must be at least 3 characters long.")
                .MaximumLength(100)
                .WithMessage("Employee name cannot exceed more than 100 characters.");
            RuleFor(m => m.Address)
                .Length(0, 200)
                .WithMessage("Address cannot exceed more than 200 characters.");
            RuleFor(m => m.Role)
                .NotEmpty()
                .WithMessage("Role cannot be blank.")
                .MinimumLength(2)
                .WithMessage("Role must be at least 2 characters long.")
                .MaximumLength(100)
                .WithMessage("Role cannot exceed more than 100 characters.");
            RuleFor(m => m.Department)
                .NotEmpty()
                .WithMessage("Department cannot be blank.")
                .MinimumLength(3)
                .WithMessage("Department must be at least 3 characters long.")
                .MaximumLength(100)
                .WithMessage("Department cannot exceed more than 100 characters.");
            RuleFor(m => m.Skillsets)
                .NotEmpty()
                .WithMessage("Minimum one skill set is required.")
                .MinimumLength(2)
                .WithMessage("Skill set must be at least 2 characters long.")
                .MaximumLength(300)
                .WithMessage("Skill set cannot exceed more than 300 characters.");
            RuleFor(m => m.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of Birth cannot be blank")
                .Must(Validate_Age)
                .WithMessage("Age Must be 18 and should not exceed 60");
            RuleFor(m => m.DateOfJoining)
                .NotEmpty()
                .Must(BeAValidDate)
                .WithMessage("Date of Joining cannot be blank.")
                .LessThan(DateTime.Today)
                .WithMessage("You cannot enter a joining date in the future.");
            RuleFor(m => m.IsActive)
                .NotEmpty()
                .WithMessage("Is Active must be specified")
                .Must(x => x == false || x == true);


        }

        private bool Validate_Age(DateTime? Age)
        {
            DateTime Current = DateTime.Today;
            int age = Current.Year - Convert.ToDateTime(Age).Year;

            if (age < 18 || age > 60)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool BeAValidDate(DateTime date)
        {
            if (date == default(DateTime))
                return false;
            return true;
        }

        private bool BeAValidDate(DateTime? date)
        {
            if (date == default(DateTime))
                return false;
            return true;
        }
    }
}
