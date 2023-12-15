using AutoMapper;
using EventManagerService.API.Models;
using EventManagerService.Application.Commands.CreateCommercialEvent;
using EventManagerService.Application.Commands.RemoveCommercialEvent;
using EventManagerService.Application.Commands.UpdateCommercialEvent;
using EventManagerService.Application.Queries.GetCommercialEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EventManagerService.Application.Queries.GetUsersFromEvent;
using EventManagerService.Application.Queries.GetEventCategoriesFromCommercialEvent;
using EventManagerService.Application.Queries.GetAllCommercialEvents;

namespace EventManagerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommercialEventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CommercialEventController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost(nameof(Upsert))]
        public async Task<ResponseDto> Upsert([FromBody] CommercialEventDto commercialEventDto)
        {
            ResponseDto responseDto = new ResponseDto();

            if (commercialEventDto.Id == 0)
            {
                try
                {
                    await _mediator.Send(new CreateCommercialEventCommand()
                    {
                        CreatorId = commercialEventDto.CreatorId,
                        DeadLine = commercialEventDto.DeadLine,
                        Description = commercialEventDto.Description,
                        EventDateTime = commercialEventDto.EventDateTime,
                        EventDuration = new TimeSpan(commercialEventDto.EventDuration ?? -1),
                        GenderRules = commercialEventDto.GenderRules,
                        Location = commercialEventDto.Location,
                        MinAge = commercialEventDto.MinAge,
                        MaxAge = commercialEventDto.MaxAge,
                        MaxUsers = commercialEventDto.MaxUsers,
                        MinUsers = commercialEventDto.MinUsers,
                        CommercialEventIds = commercialEventDto.CommercialEventIds,
                        CategoryIds = commercialEventDto.CategoryIds,
                        Price = commercialEventDto.Price
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
                    await _mediator.Send(new UpdateCommercialEventCommand()
                    {
                        Id = commercialEventDto.Id,
                        CreatorId = commercialEventDto.CreatorId,
                        DeadLine = commercialEventDto.DeadLine,
                        Description = commercialEventDto.Description,
                        EventDateTime = commercialEventDto.EventDateTime,
                        EventDuration = new TimeSpan(commercialEventDto.EventDuration ?? -1),
                        GenderRules = commercialEventDto.GenderRules,
                        Location = commercialEventDto.Location,
                        MinAge = commercialEventDto.MinAge,
                        MaxAge = commercialEventDto.MaxAge,
                        MaxUsers = commercialEventDto.MaxUsers,
                        MinUsers = commercialEventDto.MinUsers,
                        CommercialEventIds = commercialEventDto.CommercialEventIds,
                        CategoryIds = commercialEventDto.CategoryIds,
                        Price = commercialEventDto.Price
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
        public async Task<ResponseDto> Remove(int commercialEventId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new RemoveCommercialEventCommand()
            {
                Id = commercialEventId
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

        [HttpGet(nameof(GetAllCommercialEvents))]
        public async Task<ResponseDto> GetAllCommercialEvents()
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetAllCommercialEventsQuery() { };
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

        [HttpGet(nameof(GetCommercialEvent))]
        public async Task<ResponseDto> GetCommercialEvent(int commercialEventId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetCommercialEventQuery()
            {
                Id = commercialEventId
            };
            try
            {
                responseDto.Data = _mapper.Map<CommercialEventDto>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetUsersFromCommercialEvent))]
        public async Task<ResponseDto> GetUsersFromCommercialEvent(int commercialEventId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetUsersFromCommercialEventQuery()
            {
                Id = commercialEventId
            };
            try
            {
                responseDto.Data = _mapper.Map<IEnumerable<UserDto>>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetCategoriesFromCommercialEvent))]
        public async Task<ResponseDto> GetCategoriesFromCommercialEvent(int commercialEventId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetEventCategoriesFromCommercialEventQuery()
            {
                CommercialEventId = commercialEventId
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

        [HttpGet(nameof(GetCreator))]
        public async Task<ResponseDto> GetCreator(int commercialEventId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetCommercialEventQuery()
            {
                Id = commercialEventId
            };
            try
            {
                responseDto.Data = _mapper.Map<CommercialUserDto>((await _mediator.Send(command)).Creator);
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
