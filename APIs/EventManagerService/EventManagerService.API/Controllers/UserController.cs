using AutoMapper;
using EventManagerService.API.Models;
using EventManagerService.Application.Commands.AssignUserCommercialEvent;
using EventManagerService.Application.Commands.AssignUserEvent;
using EventManagerService.Application.Commands.CancelCommercialEventAssignment;
using EventManagerService.Application.Commands.CancelUserEventAssignment;
using EventManagerService.Application.Commands.CreateUser;
using EventManagerService.Application.Commands.RemoveUser;
using EventManagerService.Application.Commands.UpdateUser;
using EventManagerService.Application.Queries.GetAllUsers;
using EventManagerService.Application.Queries.GetCommercialEventsSigned;
using EventManagerService.Application.Queries.GetEventsCreatedByUser;
using EventManagerService.Application.Queries.GetUser;
using EventManagerService.Application.Queries.GetUserEventsSigned;
using EventManagerService.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost(nameof(Upsert))]
        public async Task<ResponseDto> Upsert([FromBody] UserDto userDto)
        {
            ResponseDto responseDto = new ResponseDto();

            if (userDto.Id == 0)
            {
                try
                {
                    await _mediator.Send(new CreateUserCommand()
                    {
                        Email = userDto.Email,
                        Name = userDto.Name,
                        PhoneNumber = userDto.PhoneNumber,
                        Gender = userDto.Gender,
                        Age = userDto.Age
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
                    await _mediator.Send(new UpdateUserCommand()
                    {
                        Id = userDto.Id,
                        Email = userDto.Email,
                        Name = userDto.Name,
                        PhoneNumber = userDto.PhoneNumber,
                        Gender = userDto.Gender,
                        Age = userDto.Age
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

        [HttpPost(nameof(AssignUserToEvent))]
        public async Task<ResponseDto> AssignUserToEvent(int eventId, int userId)
        {
            ResponseDto responseDto = new ResponseDto();

            var command = new AssignUserEventCommand()
            {
                EventId = eventId,
                UserId = userId
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
        
        [HttpPost(nameof(AssignUserToCommercialEvent))]
        public async Task<ResponseDto> AssignUserToCommercialEvent(int eventId, int userId)
        {
            ResponseDto responseDto = new ResponseDto();

            var command = new AssignUserCommercialEventCommand()
            {
                EventId = eventId,
                UserId = userId
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
        
        [HttpPost(nameof(CancelUserEventAssignment))]
        public async Task<ResponseDto> CancelUserEventAssignment(int eventId, int userId)
        {
            ResponseDto responseDto = new ResponseDto();

            var command = new CancelUserEventAssignmentCommand()
            {
                EventId = eventId,
                UserId = userId
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

        [HttpPost(nameof(CancelCommercialEventAssignment))]
        public async Task<ResponseDto> CancelCommercialEventAssignment(int eventId, int userId)
        {
            ResponseDto responseDto = new ResponseDto();

            var command = new CancelCommercialEventAssignmentCommand()
            {
                EventId = eventId,
                UserId = userId
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

        [HttpDelete(nameof(Remove))]
        public async Task<ResponseDto> Remove(int userId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new RemoveUserCommand()
            {
                Id = userId
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

        [HttpGet(nameof(GetAllUsers))]
        public async Task<ResponseDto> GetAllUsers()
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetAllUsersQuery() {};
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

        [HttpGet(nameof(GetUser))]
        public async Task<ResponseDto> GetUser(int userId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetUserQuery() 
            {
                Id = userId
            };
            try
            {
                responseDto.Data = _mapper.Map<UserDto>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetEventsCreatedByUser))]
        public async Task<ResponseDto> GetEventsCreatedByUser(int userId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetEventsCreatedByUserQuery()
            {
                Id = userId
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

        [HttpGet(nameof(GetUserEventsSignedIn))]
        public async Task<ResponseDto> GetUserEventsSignedIn(int userId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetUserEventsSignedQuery()
            {
                UserId = userId
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

        [HttpGet(nameof(GetCommercialEventsSignedIn))]
        public async Task<ResponseDto> GetCommercialEventsSignedIn(int userId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetCommercialEventsSignedQuery()
            {
                UserId = userId
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
    }
}
