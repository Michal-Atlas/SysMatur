using AutoMapper;
using SysMatur.Data.Objects;

namespace SysMatur.Api.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}