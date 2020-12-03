using System.Linq;
using AutoMapper;
using server.DTO;
using server.Entities;

namespace server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, KorisnikDto>()
                .ForMember(dest => dest.GlavnaSlikaUrl, opt => opt.MapFrom(src =>
                                                                src.Slike.FirstOrDefault(x => x.GlavnaSlika).Url));
            CreateMap<Photo, PhotoDto>();
        }
    }
}