using AutoMapper;
using AutoMapper.Execution;
using Hydra.WebApi.DTOs;
using Hydra.WebApi.Entities;
using Hydra.WebApi.Extensions;

namespace Hydra.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(d => d.Age, o => o.MapFrom(s => s.DateOfBirth.CalculateAge()))
                .ForMember(d => d.PhotoUrl, s =>
                s.MapFrom(x => x.Photos.FirstOrDefault(a => a.IsMain)!.Url));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<string, DateOnly>().ConvertUsing(s=> DateOnly.Parse(s));
            CreateMap<Message,MessageDto>()
                .ForMember(d=>d.SendPhotoUrl,
                o => o.MapFrom(s=> s.Sender.Photos.FirstOrDefault(x=>x.IsMain)!.Url))
                .ForMember(d=>d.RecipienthotoUrl,
                o => o.MapFrom(s=> s.Recipient.Photos.FirstOrDefault(x=>x.IsMain)!.Url));

        }
    }
}
