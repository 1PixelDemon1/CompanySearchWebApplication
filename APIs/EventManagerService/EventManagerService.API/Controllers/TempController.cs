using EventManagerService.Application.Commands.AssignUserEvent;
using EventManagerService.Application.Commands.CreateCommercialUser;
using EventManagerService.Application.Commands.CreateUser;
using EventManagerService.Application.Commands.CreateUserEvent;
using EventManagerService.Application.Queries.GetAllUserEvents;
using EventManagerService.Application.Queries.GetAllUsers;
using EventManagerService.Application.Queries.GetUser;
using EventManagerService.Application.Queries.GetUserEvent;
using EventManagerService.Application.Queries.GetUsersFromEvent;
using EventManagerService.Domain.Entities;
using EventManagerService.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventManagerService.API.Controllers
{
    [Route("test")]
    public class TempController : ControllerBase
    {

        private readonly EventManagerDbContext _dbContext;

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public TempController(EventManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost(nameof(CreateUser))]
        public async void CreateUser()
        {
            var command = new CreateUserCommand()
            {
                Email = "test@gmail.com",
                Name = "User",
                PhoneNumber = "1234567890",
                Gender = Domain.Entities.User.Genders.MALE,
                Age = 20
            };
            await Mediator.Send(command);
        }
        [HttpPost(nameof(CreateCommercialUser))]
        public async void CreateCommercialUser()
        {
            var command = new CreateCommercialUserCommand()
            {
                Name = "VIMers corp",
                PersonalAccount = "12345"
            };
            await Mediator.Send(command);
        }

        [HttpPost(nameof(CreateEvent))]
        public async void CreateEvent()
        {
            var command = new CreateUserEventCommand()
            {
                CreatorId = 1,
                EventDuration = TimeSpan.FromSeconds(100),
                EventDateTime = DateTime.UtcNow.AddDays(10),
                Location = "TownX",
                Description = "Very cool event",
                GenderRules = GenderRules.ALL,
                DeadLine = null,
                MinUsers = 0,
                MaxUsers = 5,
                MinAge = 18,
                MaxAge = -1,
                CategoryIds = null,
                //UserEventIds = null,
                CommercialEventIds = new List<int> { 1 }
            };

            await Mediator.Send(command);
        }

        [HttpPost(nameof(AssignUser))]
        public async void AssignUser(int EventIndex, int UserIndex)
        {
            var command = new AssignUserEventCommand()
            {
                EventId = EventIndex,
                UserId = UserIndex
            };
            await Mediator.Send(command);
        }

        [HttpGet(nameof(GetUsersFromEvent))]
        public async Task<IEnumerable<User>?> GetUsersFromEvent(int EventIndex)
        {
            var command = new GetUsersFromEventQuery()
            {
                Id = EventIndex
            };
            return await Mediator.Send(command);
        }

        [HttpGet(nameof(GetUser))]
        public async Task<User> GetUser(int Id)
        {
            var command = new GetUserQuery()
            {
                Id = Id
            };
            return await Mediator.Send(command);
        }

        [HttpGet(nameof(GetUserEvent))]
        public async Task<UserEvent> GetUserEvent(int Id)
        {
            var command = new GetUserEventQuery()
            {
                Id = Id
            };
            return await Mediator.Send(command);
        }

        [HttpGet(nameof(GetAllUsers))]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var command = new GetAllUsersQuery() {};
            return await Mediator.Send(command);
        }

        [HttpGet(nameof(GetAllUserEvents))]
        public async Task<IEnumerable<UserEvent>> GetAllUserEvents()
        {
            var command = new GetAllUserEventsQuery() { };
            return await Mediator.Send(command);
        }
    }
}
