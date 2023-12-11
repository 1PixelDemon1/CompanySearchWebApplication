using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.CreateCommercialEvent
{
    public class CreateCommercialEventCommandValidator : AbstractValidator<CreateCommercialEventCommand>
    {
        public CreateCommercialEventCommandValidator()
        {
            RuleFor(command => new { Min = command.MinUsers, Max = command.MaxUsers })
                .Custom((MinMaxUsers, context) => {
                    if (MinMaxUsers.Min < 0 || MinMaxUsers.Max < -1)
                    {
                        context.AddFailure("MaxUsers", "Number of participants must be more than 0.");
                    }
                    if (MinMaxUsers.Max != -1 && MinMaxUsers.Max < MinMaxUsers.Min)
                    {
                        context.AddFailure("MaxUsers", "Maximum number of participants must be more or equal to its minimum.");
                    }
                });

            RuleFor(command => new { Min = command.MinAge, Max = command.MaxAge })
                .Custom((MinMaxAge, context) => {
                    if (MinMaxAge.Min < 0 || MinMaxAge.Max < -1)
                    {
                        context.AddFailure("MaxAge", "Age must be more than 0.");
                    }
                    if (MinMaxAge.Max != -1 && MinMaxAge.Max < MinMaxAge.Min)
                    {
                        context.AddFailure("MaxAge", "Maximum age must be more or equal to its minimum.");
                    }
                });
            RuleFor(command => command.EventDateTime).GreaterThanOrEqualTo(DateTime.UtcNow);
            RuleFor(command => command.Price).GreaterThanOrEqualTo(0);
        }
    }
}
