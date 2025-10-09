using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators;

// https://docs.fluentvalidation.net/en/latest/
// dotnet add package FluentValidation (nuget)
public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(p => p.Name).NotEmpty().Length(3, 10);
        RuleFor(p => p.Email).EmailAddress();
    }
}
