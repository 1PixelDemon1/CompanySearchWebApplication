using EventManagerService.Application.Common.CustomExceptions;
using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.UpdateEventCategory
{
    public class UpdateEventCategoryCommandHandler : IRequestHandler<UpdateEventCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEventCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateEventCategoryCommand request, CancellationToken cancellationToken)
        {
            EventCategory? eventCategory = _unitOfWork.Categories.Get(c => c.Id == request.Id);
            if(eventCategory is null)
            {
                throw new CategoryNotFoundException(request.Id);
            }
            eventCategory.ParentCategory = (request.ParentCategoryId is null) ? null : _unitOfWork.Categories.Get(c => c.Id == request.ParentCategoryId);
            eventCategory.Name = request.Name;

            _unitOfWork.SaveChanges();
        }
    }
}
