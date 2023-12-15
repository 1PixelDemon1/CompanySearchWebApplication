using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using FluentValidation;
using MediatR;


namespace EventManagerService.Application.Commands.CreateUserEvent
{
    public class CreateUserEventCommandHandler : IRequestHandler<CreateUserEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateUserEventCommand request, CancellationToken cancellationToken)
        {
            UserEvent userEvent = new()
            {
                Creator = _unitOfWork.Users.Get(u => u.Id == request.CreatorId),
                CreateTime = DateTime.UtcNow,
                UpdateTime = DateTime.UtcNow,
                EventDuration = request.EventDuration,
                EventDateTime = request.EventDateTime,
                Categories = (request.CategoryIds is not null) ? _unitOfWork.Categories.Where(c => request.CategoryIds.Contains(c.Id)).ToList() : null,
                Location = request.Location,
                DeadLine = request.DeadLine,
                GenderRules = request.GenderRules,
                MinUsers = request.MinUsers,
                MaxUsers = request.MaxUsers,
                MinAge = request.MinAge,
                MaxAge = request.MaxAge,
                Description = request.Description,
                UserEvents = (request.UserEventIds is not null) ? _unitOfWork.UserEvents.Where(e => request.UserEventIds.Contains(e.Id)).ToList() : null,
                CommercialEvents = (request.CommercialEventIds is not null) ? _unitOfWork.CommercialEvents.Where(e => request.CommercialEventIds.Contains(e.Id)).ToList() : null
            };

            await _unitOfWork.UserEvents.AddAsync(userEvent);
            _unitOfWork.SaveChanges();
        }
    }
}
