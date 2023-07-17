﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoho.DTOs;

namespace Zoho.API.Validation
{
    public class UpdateClientDtoValidation : AbstractValidator<UpdateClientDto>
    {
        public UpdateClientDtoValidation()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id should be greater than 0");
            RuleFor(x => x.ClientName).NotNull().Length(2, 20).Matches("^[A-Za-z]+$");
            RuleFor(x => x.FirstName).NotNull().Length(2, 20).Matches("^[A-Za-z]+$");
            RuleFor(x => x.LastName).NotNull().Length(2, 20).Matches("^[A-Za-z]+$");
            RuleFor(x => x.EmailId).EmailAddress().WithMessage("Please enter a valid email address");
            RuleFor(x => x.PhoneNumber).Matches(@"^\d{10}$").WithMessage("Please enter a 10-digit phone number");
            RuleFor(x => x.MobileNuber).Matches(@"^\d{10}$").WithMessage("Please enter a 10-digit phone number");
            RuleFor(x => x.FaxNumber).Matches(@"^\d{7}$").WithMessage("Please enter a 7-digit local fax number");
            RuleFor(x => x.CurrencyId).GreaterThan(0).WithMessage("CurrencyId should be greater than 0");
        }
    }
}
