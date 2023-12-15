using AutoMapper;
using EventManagerService.API.Models;
using EventManagerService.Application.Commands.AssignUserEvent;
using EventManagerService.Application.Commands.CreateCommercialUser;
using EventManagerService.Application.Commands.CreateUser;
using EventManagerService.Application.Commands.RemoveCommercialUser;
using EventManagerService.Application.Commands.RemoveUser;
using EventManagerService.Application.Commands.UpdateCommercialUser;
using EventManagerService.Application.Commands.UpdateUser;
using EventManagerService.Application.Queries.GetAllCommercialUsers;
using EventManagerService.Application.Queries.GetAllUsers;
using EventManagerService.Application.Queries.GetCommercialUser;
using EventManagerService.Application.Queries.GetEventsCreatedByCommercialUser;
using EventManagerService.Application.Queries.GetEventsCreatedByUser;
using EventManagerService.Application.Queries.GetUser;
using EventManagerService.Application.Queries.GetUserEventsSigned;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagerService.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommercialUserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CommercialUserController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost(nameof(Upsert))]
        public async Task<ResponseDto> Upsert([FromBody] CommercialUserDto commercialUserDto)
        {
            ResponseDto responseDto = new ResponseDto();

            if (commercialUserDto.Id == 0)
            {
                try
                {
                    await _mediator.Send(new CreateCommercialUserCommand()
                    {
                        PersonalAccount = commercialUserDto.PersonalAccount,
                        Name = commercialUserDto.Name
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
                    await _mediator.Send(new UpdateCommercialUserCommand()
                    {
                        Id = commercialUserDto.Id,
                        Name = commercialUserDto.Name,
                        PersonalAccount = commercialUserDto.PersonalAccount,
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
        public async Task<ResponseDto> Remove(int commercialUserId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new RemoveCommercialUserCommand()
            {
                Id = commercialUserId
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

        [HttpGet(nameof(GetAllCommerciaUsers))]
        public async Task<ResponseDto> GetAllCommerciaUsers()
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetAllCommercialUsersQuery() { };
            try
            {
                responseDto.Data = _mapper.Map<IEnumerable<CommercialUserDto>>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetCommercialUser))]
        public async Task<ResponseDto> GetCommercialUser(int commercialUserId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetCommercialUserQuery()
            {
                Id = commercialUserId
            };
            try
            {
                responseDto.Data = _mapper.Map<CommercialUserDto>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.Message = ex.Message;
            }
            return responseDto;
        }

        [HttpGet(nameof(GetEventsCreatedByCommercialUser))]
        public async Task<ResponseDto> GetEventsCreatedByCommercialUser(int commercialUserId)
        {
            ResponseDto responseDto = new ResponseDto();
            var command = new GetEventsCreatedByCommercialUserQuery()
            {
                Id = commercialUserId
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
