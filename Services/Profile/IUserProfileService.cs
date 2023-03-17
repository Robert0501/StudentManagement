using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Services.Profile
{
    public interface IUserProfileService
    {
        List<UserProfile> GetAllUsers();
        UserProfile GetUserById(int id);
        List<UserProfile> AddNewProfile(UserProfile newProfile);
        UserProfile UpdateProfile(UserProfile updatedProfile);
        public List<UserProfile> DeleteUser(int id);
    }
}