using EventManagerService.Application.Commands.AssignUser;
using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.AssignUserEvent
{
    public class AssignUserEventCommandHandler : IRequestHandler<AssignUserEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignUserEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AssignUserEventCommand request, CancellationToken cancellationToken)
        {
            User user = _unitOfWork.Users.Get(u => u.Id == request.UserId);
            if (user is null)
            {
                throw new UserNotFoundException(request.UserId);
            }
            UserEvent userEvent = _unitOfWork.UserEvents.Get(e => e.Id == request.EventId);
            if (userEvent is null)
            {
                throw new EventNotFoundException(request.EventId);
            }
            
            if(userEvent.DeadLine < DateTime.UtcNow)
            {
                throw new UserNotMetRequirementsException("event date");
            }
            if(userEvent.MaxAge != -1 && user.Age > userEvent.MaxAge ||
                user.Age < userEvent.MinAge)
            {
                throw new UserNotMetRequirementsException("age");
            }
            if (userEvent.MaxUsers != -1 && (userEvent.RegisteredUsers?.Count() ?? 0) >= userEvent.MaxUsers)
            {
                throw new UserNotMetRequirementsException("too many participants");
            }
            if(userEvent.GenderRules == GenderRules.MALE_ONLY && user.Gender == User.Genders.FEMALE)
            {
                throw new UserNotMetRequirementsException("male only");
            }
            if(userEvent.GenderRules == GenderRules.FEMALE_ONLY && user.Gender == User.Genders.MALE)
            {
                throw new UserNotMetRequirementsException("female only");
            }

            if (userEvent.RegisteredUsers is null)
            {
                userEvent.RegisteredUsers = new List<User>() { user };
            }
            else
            {
                if(userEvent.RegisteredUsers.FirstOrDefault(u => u.Id == user.Id) is not null)
                {
                    throw new UserAlreadySignedException(user.Id, userEvent.Id);
                }

                userEvent.RegisteredUsers.Append(user);
            }
            _unitOfWork.SaveChanges();
        }
    }
}
