using AutoMapper;
using EventManagerService.API.Models;
using EventManagerService.Application.Commands.CreateUserEvent;
using EventManagerService.Application.Commands.RemoveUserEvent;
using EventManagerService.Application.Commands.UpdateUserEvent;
using EventManagerService.Application.Queries.GetAllUserEvents;
using EventManagerService.Application.Queries.GetAllUsers;
using EventManagerService.Application.Queries.GetEventCategoriesFromUserEvent;
using EventManagerService.Application.Queries.GetEventsCreatedByUser;
using EventManagerService.Application.Queries.GetUser;
using EventManagerService.Application.Queries.GetUserEvent;
using EventManagerService.Application.Queries.GetUserEventsSigned;
using EventManagerService.Application.Queries.GetUsersFromEvent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EventManagerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserEventController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost(nameof(Upsert))]
        public async Task<ResponseDto> Upsert([FromBody] UserEventDto userEventDto)
        {
            ResponseDto responseDto = new ResponseDto();

            if (userEventDto.Id == 0)
            {
                try
                {
                    await _mediator.Send(new CreateUserEventCommand()
                    {
                        CreatorId = userEventDto.CreatorId,
                        DeadLine = userEventDto.DeadLine,
                        Description = userEventDto.Description,
                        EventDateTime = userEventDto.EventDateTime,
                        EventDuration = new TimeSpan(userEventDto.EventDuration ?? -1),
                        GenderRules = userEventDto.GenderRules,
                        Location = userEventDto.Location,
                        MinAge = userEventDto.MinAge,
                        MaxAge = userEventDto.MaxAge,
                        MaxUsers = userEventDto.MaxUsers,
                        MinUsers = userEventDto.MinUsers,
                        CommercialEventIds = userEventDto.CommercialEventIds,
                        CategoryIds = userEventDto.CategoryIds,
                        UserEventIds = userEventDto.UserEventIds
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
                    await _mediator.Send(new UpdateUserEventCommand()
                    {
                        Id = userEventDto.Id,
                        CreatorId = userEventDto.CreatorId,
                        DeadLine = userEventDto.DeadLine,
                        Description = userEventDto.Description,
                        EventDateTime = userEventDto.EventDateTime,
                        EventDuration = new TimeSpan(userEventDto.EventDuration ?? -1),
                        GenderRules = userEventDto.GenderRules,
                        Location = userEventDto.Location,
                        MinAge = userEventDto.MinAge,
                        MaxAge = userEventDto.MaxAge,
                        MaxUsers = userEventDto.MaxUsers,
                        MinUsers = userEventDto.MinUsers,
                        CommercialEventIds = userEventDto.CommercialEventIds,
                        CategoryIds = userEventDto.CategoryIds,
                        UserEventIds = userEventDto.UserEventIds
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
        public async Task<ResponseDto> Remove(int userEventId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new RemoveUserEventCommand()
            {
                Id = userEventId
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

        [HttpGet(nameof(GetAllUserEvents))]
        public async Task<ResponseDto> GetAllUserEvents()
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetAllUserEventsQuery() { };
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

        [HttpGet(nameof(GetUserEvent))]
        public async Task<ResponseDto> GetUserEvent(int userEventId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetUserEventQuery()
            {
                Id = userEventId
            };
            try
            {
                responseDto.Data = _mapper.Map<UserEventDto>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetUsersFromEvent))]
        public async Task<ResponseDto> GetUsersFromEvent(int userEventId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetUsersFromEventQuery()
            {
                Id = userEventId
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

        [HttpGet(nameof(GetCategoriesFromEvent))]
        public async Task<ResponseDto> GetCategoriesFromEvent(int userEventId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetEventCategoriesFromUserEventQuery()
            {
                UserEventId = userEventId
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
        public async Task<ResponseDto> GetCreator(int userEventId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetUserEventQuery()
            {
                Id = userEventId
            };
            try
            {
                responseDto.Data = _mapper.Map<UserDto>((await _mediator.Send(command)).Creator);
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
