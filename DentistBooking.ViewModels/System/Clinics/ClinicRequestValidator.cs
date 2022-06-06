using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.ViewModels.System.Clinics
{
    public class ClinicRequestValidator : AbstractValidator<ClinicRequest>
    {

        public ClinicRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(10);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(30);
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(15);
        }
    }
}

