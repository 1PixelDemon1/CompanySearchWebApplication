using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using FluentValidation;
using MediatR;
using static System.Net.Mime.MediaTypeNames;

namespace EventManagerService.Application.Commands.UpdateUserEvent
{
    public class UpdateUserEventCommandHandler : IRequestHandler<UpdateUserEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateUserEventCommand request, CancellationToken cancellationToken)
        {
            UserEvent userEvent = _unitOfWork.UserEvents.Get(e => e.Id == request.Id);
            if (userEvent is null)
            {
                throw new EventNotFoundException(request.Id);
            }

            userEvent.Creator = _unitOfWork.Users.Get(u => u.Id == request.CreatorId);
            userEvent.UpdateTime = DateTime.UtcNow;
            userEvent.EventDuration = request.EventDuration;
            userEvent.EventDateTime = request.EventDateTime;
            userEvent.Location = request.Location;
            userEvent.Description = request.Description;
            userEvent.DeadLine = request.DeadLine;
            userEvent.GenderRules = request.GenderRules;
            userEvent.MinUsers = request.MinUsers;
            userEvent.MaxUsers = request.MaxUsers;
            userEvent.MinAge = request.MinAge;
            userEvent.MaxAge = request.MaxAge;
            
            userEvent.Categories = (request.CategoryIds is not null) ? _unitOfWork.Categories.Where(c => request.CategoryIds.Contains(c.Id)).ToList() : null;
            userEvent.UserEvents = (request.UserEventIds is not null) ? _unitOfWork.UserEvents.Where(e => request.UserEventIds.Contains(e.Id)).ToList() : null;
            userEvent.CommercialEvents = (request.CommercialEventIds is not null) ? _unitOfWork.CommercialEvents.Where(e => request.CommercialEventIds.Contains(e.Id)).ToList() : null;

            _unitOfWork.SaveChanges();
        }
    }
}
