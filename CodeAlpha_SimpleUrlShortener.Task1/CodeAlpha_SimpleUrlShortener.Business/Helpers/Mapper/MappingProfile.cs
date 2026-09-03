using AutoMapper;
using CodeAlpha_SimpleUrlShortener.Business.DTOs.Url;
using CodeAlpha_SimpleUrlShortener.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_SimpleUrlShortener.Business.Helpers.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UrlCreateDto, UrlMapping>();
        }
    }
}
