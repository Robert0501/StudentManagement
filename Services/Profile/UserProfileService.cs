using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Services.Profile
{
    public class UserProfileService : IUserProfileService
    {
        private static List<UserProfile> users = new List<UserProfile>
        {
            new UserProfile("rob@gmail.com", "rob", PersonType.Student)
        };

        public List<UserProfile> GetAllUsers()
        {
            return users;
        }

        public UserProfile GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.UserProfileId == id);
            return user;
        }
        public List<UserProfile> AddNewProfile(UserProfile newProfile)
        {
            users.Add(newProfile);
            return users;
        }
        public UserProfile UpdateProfile(UserProfile updatedProfile)
        {
            var user = users.FirstOrDefault(u => u.UserProfileId == updatedProfile.UserProfileId);

            user.Email = updatedProfile.Email;
            user.Password = updatedProfile.Password;

            return user;
        }
        public List<UserProfile> DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.UserProfileId == id);
            users.Remove(user);
            return users;
        }


    }
}