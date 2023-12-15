using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EventManagerService.Application.Commands.AssignUserCommercialEvent
{
    public class AssignUserCommercialEventCommandHandler : IRequestHandler<AssignUserCommercialEventCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public AssignUserCommercialEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AssignUserCommercialEventCommand request, CancellationToken cancellationToken)
        {
            User user = _unitOfWork.Users.Get(u => u.Id == request.UserId);
            if(user is null)
            {
                throw new UserNotFoundException(request.UserId);
            }
            CommercialEvent commercialEvent = _unitOfWork.CommercialEvents.Get(e => e.Id == request.EventId);
            if (commercialEvent is null)
            {
                throw new EventNotFoundException(request.EventId);
            }

            if (commercialEvent.DeadLine < DateTime.UtcNow)
            {
                throw new UserNotMetRequirementsException("event date");
            }
            if (commercialEvent.MaxAge != -1 && user.Age > commercialEvent.MaxAge ||
                user.Age < commercialEvent.MinAge)
            {
                throw new UserNotMetRequirementsException("age");
            }
            if (commercialEvent.MaxUsers != -1 && (commercialEvent.RegisteredUsers?.Count() ?? 0) < commercialEvent.MaxUsers)
            {
                throw new UserNotMetRequirementsException("too many participants");
            }
            if (commercialEvent.GenderRules == GenderRules.MALE_ONLY && user.Gender == User.Genders.FEMALE)
            {
                throw new UserNotMetRequirementsException("male only");
            }
            if (commercialEvent.GenderRules == GenderRules.FEMALE_ONLY && user.Gender == User.Genders.MALE)
            {
                throw new UserNotMetRequirementsException("female only");
            }

            if (commercialEvent.RegisteredUsers is null)
            {
                commercialEvent.RegisteredUsers = new List<User>() { user };
            }
            else
            {
                if (commercialEvent.RegisteredUsers.FirstOrDefault(u => u.Id == user.Id) is not null)
                {                    
                    throw new UserAlreadySignedException(user.Id, commercialEvent.Id);
                }
                (commercialEvent.RegisteredUsers as ICollection<User>).Add(user);
            }
            _unitOfWork.SaveChanges();
        }
    }
}
