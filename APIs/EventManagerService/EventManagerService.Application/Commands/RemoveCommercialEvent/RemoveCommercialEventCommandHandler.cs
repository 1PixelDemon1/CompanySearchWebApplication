using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;

namespace EventManagerService.Application.Commands.RemoveCommercialEvent
{
    public class RemoveCommercialEventCommandHandler : IRequestHandler<RemoveCommercialEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCommercialEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveCommercialEventCommand request, CancellationToken cancellationToken)
        {
            CommercialEvent commercialEvent = _unitOfWork.CommercialEvents.Get(u => u.Id == request.Id);
            if (commercialEvent is null)
            {
                throw new EventNotFoundException(request.Id);
            }
            _unitOfWork.CommercialEvents.Remove(commercialEvent);
            _unitOfWork.SaveChanges();
        }
    }
}
