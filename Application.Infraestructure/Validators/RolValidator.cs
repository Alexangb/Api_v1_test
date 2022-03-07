using Application.Core.Entitys;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Infraestructure.Validators
{
    public class RolValidator:AbstractValidator<ERol>
    {
        public RolValidator()
        {
            RuleFor(user => user.Rol).NotNull().Length(3, 100);
           
        }
    }
}
