using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EventManagerService.Application.Commands.CreateCommercialEvent
{
    public class CreateCommercialEventCommandHandler : IRequestHandler<CreateCommercialEventCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateCommercialEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCommercialEventCommand request, CancellationToken cancellationToken)
        {            
            CommercialEvent commercialEvent = new()
            {
                Creator = _unitOfWork.CommercialUsers.Get(u => u.Id == request.CreatorId),
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
                Price = request.Price,
                CommercialEvents = (request.CommercialEventIds is not null) ? _unitOfWork.CommercialEvents.Where(e => request.CommercialEventIds.Contains(e.Id)).ToList() : null
            };

            await _unitOfWork.CommercialEvents.AddAsync(commercialEvent);
            _unitOfWork.SaveChanges();
        }
    }
}
