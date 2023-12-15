using AutoMapper;
using EventManagerService.API.Models;
using EventManagerService.Domain.Entities;

namespace EventManagerService.API.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CommercialUser, CommercialUserDto>();
            CreateMap<CommercialEvent, CommercialEventDto>()
                .ForMember(ce => ce.EventDuration, opt => opt.MapFrom(src => src.EventDuration.Value.Ticks))
                .ForMember(ce => ce.CommercialEventIds, opt => opt.MapFrom(src => src.CommercialEvents.Select(ces => ces.Id)))
                .ForMember(ce => ce.CategoryIds, opt => opt.MapFrom(src => src.Categories.Select(cat => cat.Id)))
                .ForMember(ce => ce.CreatorId, opt => opt.MapFrom(src => src.Creator.Id));
            CreateMap<UserEvent, UserEventDto>()
                .ForMember(e => e.EventDuration, opt => opt.MapFrom(src => src.EventDuration.Value.Ticks))
                .ForMember(e => e.CommercialEventIds, opt => opt.MapFrom(src => src.CommercialEvents.Select(es => es.Id)))
                .ForMember(e => e.UserEventIds, opt => opt.MapFrom(src => src.UserEvents.Select(ues => ues.Id)))
                .ForMember(e => e.CategoryIds, opt => opt.MapFrom(src => src.Categories.Select(cat => cat.Id)))
                .ForMember(e => e.CreatorId, opt => opt.MapFrom(src => src.Creator.Id));
            CreateMap<EventCategory, EventCategoryDto>()
                .ForMember(c => c.ParentCategoryId, opt => opt.MapFrom(src => src.ParentCategory.Id));
        }
    }
}
