using Application.Core.Entitys;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Infraestructure.Validators
{
    public class UserValidator:AbstractValidator<EUser>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotNull().Length(3,100);
            RuleFor(user => user.LastName).NotNull().Length(3, 100);
            RuleFor(user => user.Email).NotNull().Length(3, 100);
            RuleFor(user => user.date_of_birth).NotNull().LessThan(DateTime.Now);
        }
    }
}
