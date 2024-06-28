using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DateFinder.Domain.DTO;
using DateFinder.Domain.Storage;

namespace DateFinder.Domain.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // create the mappings
            CreateMap<DateDto, Date>().ReverseMap();
            CreateMap<FindMapDatesRequestDto, Date>()
                .ForMember(dest => dest.Duration, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
