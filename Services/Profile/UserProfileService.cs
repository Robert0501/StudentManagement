using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Services.Profile
{
    public class UserProfileService : IUserProfileService
    {

        private readonly DataContext _context;

        public UserProfileService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<UserProfile>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<UserProfile>>();
            serviceResponse.Data = await _context.UserProfile.ToListAsync();

            if (serviceResponse.Data is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "There are no users";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<UserProfile>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<UserProfile>();
            serviceResponse.Data = await _context.UserProfile.FirstOrDefaultAsync(u => u.UserProfileId == id);

            if (serviceResponse.Data is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "The user with id = " + id + " does not exist";
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<UserProfile>>> AddNewProfile(UserProfile newProfile)
        {
            _context.UserProfile.Add(newProfile);
            await _context.SaveChangesAsync();
            var serviceResponse = new ServiceResponse<List<UserProfile>>();
            serviceResponse.Data = await _context.UserProfile.ToListAsync();

            return serviceResponse;
        }
        public async Task<ServiceResponse<UserProfile>> UpdateProfile(UserProfile updatedProfile)
        {
            var serviceResponse = new ServiceResponse<UserProfile>();
            var user = await _context.UserProfile.FirstOrDefaultAsync(u => u.UserProfileId == updatedProfile.UserProfileId);

            if (user is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "The user with id = " + updatedProfile.UserProfileId + " does not exist";
            }
            else
            {
                user.Email = updatedProfile.Email;
                user.Password = updatedProfile.Password;

                await _context.SaveChangesAsync();

                serviceResponse.Data = user;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<UserProfile>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<UserProfile>>();
            var user = await _context.UserProfile.FirstOrDefaultAsync(u => u.UserProfileId == id);

            if (user is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "The user with id = " + id + " does not exist";
            }
            else
            {
                _context.UserProfile.Remove(user);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.UserProfile.ToListAsync();
            }

            return serviceResponse;
        }


    }
}