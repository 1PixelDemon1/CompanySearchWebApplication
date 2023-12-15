using AutoMapper;
using EventManagerService.API.Models;
using EventManagerService.Application.Commands.CreateEventCategory;
using EventManagerService.Application.Commands.RemoveEventCategory;
using EventManagerService.Application.Commands.UpdateEventCategory;
using EventManagerService.Application.Queries.GetAllEventCategories;
using EventManagerService.Application.Queries.GetCommercialEventsByEventCategory;
using EventManagerService.Application.Queries.GetCommercialEventsByEventCategoryHierarchy;
using EventManagerService.Application.Queries.GetEventCategoryHierarchy;
using EventManagerService.Application.Queries.GetUserEventsByEventCategory;
using EventManagerService.Application.Queries.GetUserEventsByEventCategoryHierarchy;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace EventManagerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EventCategoryController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost(nameof(Upsert))]
        public async Task<ResponseDto> Upsert([FromBody] EventCategoryDto eventCategoryDto)
        {
            ResponseDto responseDto = new ResponseDto();

            if (eventCategoryDto.Id == 0)
            {
                try
                {
                    await _mediator.Send(new CreateEventCategoryCommand()
                    {
                        Name = eventCategoryDto.Name,
                        ParentCategoryId = eventCategoryDto.ParentCategoryId
                    });
                }
                catch (Exception ex)
                {
                    responseDto.IsSuccess = false;
                    responseDto.Message = ex.Message;
                }
            }
            else
            {
                try
                {
                    await _mediator.Send(new UpdateEventCategoryCommand()
                    {
                        Id = eventCategoryDto.Id,
                        Name = eventCategoryDto.Name,
                        ParentCategoryId = eventCategoryDto.ParentCategoryId
                    });
                }
                catch (Exception ex)
                {
                    responseDto.IsSuccess = false;
                    responseDto.Message = ex.Message;
                }
            }
            return responseDto;
        }

        [HttpDelete(nameof(Remove))]
        public async Task<ResponseDto> Remove(int eventCategoryId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new RemoveEventCategoryCommand()
            {
                Id = eventCategoryId
            };
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetAllCategories))]
        public async Task<ResponseDto> GetAllCategories()
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetAllEventCategoriesQuery() { };
            try
            {
                responseDto.Data = _mapper.Map<IEnumerable<EventCategoryDto>>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }
        
        [HttpGet(nameof(GetUserEventsByCategory))]
        public async Task<ResponseDto> GetUserEventsByCategory(int eventCategoryId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetUserEventsByEventCategoryQuery()
            {
                EventCategoryId = eventCategoryId
            };
            try
            {
                responseDto.Data = _mapper.Map<IEnumerable<UserEventDto>>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetUserEventsByCategoryHierarchy))]
        public async Task<ResponseDto> GetUserEventsByCategoryHierarchy(int baseEventCategoryId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetUserEventsByEventCategoryHierarchyQuery()
            {
                BaseEventCategoryId = baseEventCategoryId
            };
            try
            {
                responseDto.Data = _mapper.Map<IEnumerable<UserEventDto>>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetCommercialEventsByCategory))]
        public async Task<ResponseDto> GetCommercialEventsByCategory(int eventCategoryId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetCommercialEventsByEventCategoryQuery()
            {
                EventCategoryId = eventCategoryId
            };
            try
            {
                responseDto.Data = _mapper.Map<IEnumerable<CommercialEventDto>>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetCommercialEventsByCategoryHierarchy))]
        public async Task<ResponseDto> GetCommercialEventsByCategoryHierarchy(int baseEventCategoryId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetCommercialEventsByEventCategoryHierarchyQuery()
            {
                BaseEventCategoryId = baseEventCategoryId
            };
            try
            {
                responseDto.Data = _mapper.Map<IEnumerable<CommercialEventDto>>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetEventCategoryHierarchy))]
        public async Task<ResponseDto> GetEventCategoryHierarchy(int eventCategoryId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetEventCategoryHierarchyQuery()
            {
                EventCategoryId = eventCategoryId
            };
            try
            {
                responseDto.Data = _mapper.Map<IEnumerable<EventCategoryDto>>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }
    }
}
