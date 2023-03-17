using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Services.Profile
{
    public interface IUserProfileService
    {
        Task<ServiceResponse<List<UserProfile>>> GetAllUsers();
        Task<ServiceResponse<UserProfile>> GetUserById(int id);
        Task<ServiceResponse<List<UserProfile>>> AddNewProfile(UserProfile newProfile);
        Task<ServiceResponse<UserProfile>> UpdateProfile(UserProfile updatedProfile);
        Task<ServiceResponse<List<UserProfile>>> DeleteUser(int id);
    }
}