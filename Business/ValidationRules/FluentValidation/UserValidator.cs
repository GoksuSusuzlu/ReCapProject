using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress().WithMessage("Invalid email address");
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(6);
            RuleFor(u => u.Password).Must(validPassword).WithMessage("Incorrect password format");

        }

        private bool validPassword(string arg)
        {
            return arg.Any(char.IsUpper) && arg.Any(char.IsDigit) && arg.Any(char.IsPunctuation);
        }

        //private bool ValidAddress(string arg)
        //{
        //    return arg.Contains("@hotmail") || arg.Contains("@gmail");
        //}

    }
}
