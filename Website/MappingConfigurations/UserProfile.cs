using AutoMapper;
using Website.Models;
using Website.Models.VIewModels;

namespace Website.MappingConfigurations
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            // Default mapping when property names are same
            CreateMap<UserTable, UserViewModel>();
        }
    }
}
