using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.RemoveEventCategory
{
    public class RemoveEventCategoryCommandHandler : IRequestHandler<RemoveEventCategoryCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public RemoveEventCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveEventCategoryCommand request, CancellationToken cancellationToken)
        {
            EventCategory? eventCategory = _unitOfWork.Categories.Get(c => c.Id == request.Id);
            if(eventCategory is null) 
            {
                throw new CategoryNotFoundException(request.Id);
            }
            _unitOfWork.Categories.Remove(eventCategory);
            _unitOfWork.SaveChanges();
        }
    }
}
