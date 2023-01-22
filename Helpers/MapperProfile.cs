using AuthApi.Entities;
using AuthApi.Models;
using AutoMapper;

namespace AuthApi.Helpers;


public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, AuthenticateResponse>().ReverseMap();
        CreateMap<User, AuthenticateRequest>().ReverseMap();
        CreateMap<User, UserModel>().ReverseMap();
    }
}