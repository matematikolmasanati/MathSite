using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
            //RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
           // RuleFor(u=> u.UserName)
        }
    }
}
