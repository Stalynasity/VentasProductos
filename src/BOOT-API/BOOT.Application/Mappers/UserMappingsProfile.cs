using AutoMapper;
using BOOT.Application.Dtos.User.Request;
using BOOT.Domain.Entities;

namespace BOOT.Application.Mappers
{
    public class UserMappingsProfile: Profile
    {
        public UserMappingsProfile() 
        {
            CreateMap<UserRequestDto, User>();
            CreateMap<TokenRequestDto, User>();
        }

       
    }
}
