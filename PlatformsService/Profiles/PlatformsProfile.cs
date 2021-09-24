using AutoMapper;
using PlatformsService.Dtos;
using PlatformsService.Models;

namespace PlatformsService.Profiles
{
    public class PlatformsProfile: Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}