using Application.Entites;
using AutoMapper;
using Rep_WOF.Dtos;

namespace Rep_WOF.Extentions
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
