using AutoMapper;
using VetClinic.BL.Users.Entity;
using VetClinic.Service.Controllers.Entities.UserEntities;

namespace VetClinic.Service.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<UserFilter, UserFilterModel>();
        CreateMap<RegisterUserRequest, CreateUserModel>();
    }
}