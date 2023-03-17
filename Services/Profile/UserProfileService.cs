using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentManagement.Services.Profile
{
    public class UserProfileService : IUserProfileService
    {
        RegularExpression expression = new RegularExpression();
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserProfileService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetUserProfileDTO>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserProfileDTO>>();
            var dbUsers = await _context.UserProfile.ToListAsync();
            serviceResponse.Data = dbUsers.Select(u => _mapper.Map<GetUserProfileDTO>(u)).ToList();

            if (serviceResponse.Data is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "There are no users";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserProfileDTO>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserProfileDTO>();
            var dbUser = await _context.UserProfile.FirstOrDefaultAsync(u => u.UserProfileId == id);
            serviceResponse.Data = _mapper.Map<GetUserProfileDTO>(dbUser);

            if (serviceResponse.Data is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "The user with id = " + id + " does not exist";
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetUserProfileDTO>>> AddNewProfile(AddUserProfileDTO newProfile)
        {
            var serviceResponse = new ServiceResponse<List<GetUserProfileDTO>>();
            if (!expression.isMatch(newProfile.email, expression.Email))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Please insert a valid email";
            }
            else if (!expression.isMatch(newProfile.password, expression.Password))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Your password is not strong enough";
            }
            else
            {
                _context.Add(_mapper.Map<UserProfile>(newProfile));
                await _context.SaveChangesAsync();

                var dbUsers = await _context.UserProfile.ToListAsync();
                serviceResponse.Data = dbUsers.Select(u => _mapper.Map<GetUserProfileDTO>(u)).ToList();
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<GetUserProfileDTO>> UpdateProfile(UpdateUserProfieDTO updatedProfile)
        {
            var serviceResponse = new ServiceResponse<GetUserProfileDTO>();
            var user = await _context.UserProfile.FirstOrDefaultAsync(u => u.UserProfileId == updatedProfile.UserProfileId);

            if (user is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "The user with id = " + updatedProfile.UserProfileId + " does not exist";
            }
            else
            {
                user.Password = updatedProfile.Password;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserProfileDTO>(user);
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetUserProfileDTO>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserProfileDTO>>();

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
                var dbUser = await _context.UserProfile.ToListAsync();
                serviceResponse.Data = dbUser.Select(u => _mapper.Map<GetUserProfileDTO>(u)).ToList();
            }

            return serviceResponse;
        }


    }
}