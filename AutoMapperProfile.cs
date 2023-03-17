using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserProfile, GetUserProfileDTO>();
            CreateMap<AddUserProfileDTO, UserProfile>();
            CreateMap<UpdateUserProfieDTO, UserProfile>();
        }

    }
}