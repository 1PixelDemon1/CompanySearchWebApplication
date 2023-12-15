using EventManagerService.Application.Interfaces;
using EventManagerService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerService.Application.Queries.GetAllEventCategories
{
    public class GetAllEventCategoriesQueryHandler : IRequestHandler<GetAllEventCategoriesQuery, IEnumerable<EventCategory>?>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllEventCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventCategory>?> Handle(GetAllEventCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.Categories.Where(c => true);
        }
    }
}
