using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Commands.CreateEventCategory
{
    public class CreateEventCategoryCommandHandler : IRequestHandler<CreateEventCategoryCommand>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateEventCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateEventCategoryCommand request, CancellationToken cancellationToken)
        {
            EventCategory eventCategory = new EventCategory
            {
                Name = request.Name,
                ParentCategory = (request.ParentCategoryId is null) ? null : _unitOfWork.Categories.Get(c => c.Id == request.ParentCategoryId)
            };
            await _unitOfWork.Categories.AddAsync(eventCategory);
            _unitOfWork.SaveChanges();
        }
    }
}
