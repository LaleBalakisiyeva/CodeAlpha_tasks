using AutoMapper;
using CodeAlpha_EventRegistrationSystem.Business.DTOs.Event;
using CodeAlpha_EventRegistrationSystem.Business.DTOs.Registration;
using CodeAlpha_EventRegistrationSystem.Business.DTOs.User;
using CodeAlpha_EventRegistrationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeAlpha_EventRegistrationSystem.Business.Helpers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Event Mapping
            CreateMap<Event, EventGetDto>().ReverseMap();
            CreateMap<EventCreateDto, Event>();
            CreateMap<EventUpdateDto, Event>();

            // User Mapping
            CreateMap<User, UserGetDto>().ReverseMap();
            CreateMap<UserCreateDto, User>();

            // Registration Mapping
            CreateMap<Registration, RegistrationGetDto>()
                .ForMember(dest => dest.EventTitle, opt => opt.MapFrom(src => src.Event.Title))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FullName));

            CreateMap<RegistrationCreateDto, Registration>();
        }
    }
}
