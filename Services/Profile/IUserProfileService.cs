using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Services.Profile
{
    public interface IUserProfileService
    {
        Task<ServiceResponse<List<GetUserProfileDTO>>> GetAllUsers();
        Task<ServiceResponse<GetUserProfileDTO>> GetUserById(int id);
        Task<ServiceResponse<List<GetUserProfileDTO>>> AddNewProfile(AddUserProfileDTO newProfile);
        Task<ServiceResponse<GetUserProfileDTO>> UpdateProfile(UpdateUserProfieDTO updatedProfile);
        Task<ServiceResponse<List<GetUserProfileDTO>>> DeleteUser(int id);
    }
}