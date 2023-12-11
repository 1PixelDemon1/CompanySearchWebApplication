using EventManagerService.Application.Commands.CreateUserEvent;
using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using FluentValidation;
using MediatR;
namespace EventManagerService.Application.Commands.UpdateCommercialEvent
{
    public class UpdateCommercialEventCommandHandler : IRequestHandler<UpdateCommercialEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommercialEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCommercialEventCommand request, CancellationToken cancellationToken)
        {         
            CommercialEvent commercialEvent = _unitOfWork.CommercialEvents.Get(e => e.Id == request.Id);
            if (commercialEvent is null)
            {
                throw new EventNotFoundException(request.Id);
            }

            commercialEvent.Creator = _unitOfWork.Users.Get(u => u.Id == request.CreatorId);
            commercialEvent.UpdateTime = DateTime.UtcNow;
            commercialEvent.EventDuration = request.EventDuration;
            commercialEvent.EventDateTime = request.EventDateTime;
            commercialEvent.Location = request.Location;
            commercialEvent.Description = request.Description;
            commercialEvent.DeadLine = request.DeadLine;
            commercialEvent.GenderRules = request.GenderRules;
            commercialEvent.MinUsers = request.MinUsers;
            commercialEvent.MaxUsers = request.MaxUsers;
            commercialEvent.MinAge = request.MinAge;
            commercialEvent.MaxAge = request.MaxAge;
            commercialEvent.Price = request.Price;

            commercialEvent.Categories = (request.CategoryIds is not null) ? _unitOfWork.Categories.Where(c => request.CategoryIds.Contains(c.Id)) : null;
            commercialEvent.CommercialEvents = (request.CommercialEventIds is not null) ? _unitOfWork.CommercialEvents.Where(e => request.CommercialEventIds.Contains(e.Id)) : null;

            _unitOfWork.SaveChanges();
        }
    }
}
