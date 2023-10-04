using Microsoft.EntityFrameworkCore;
using MSSAMentorshipCompanionWebAPI.Data;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Repository
{
    
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly DataContext _dataContext;

        public UserProfileRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateUserProfile(UserProfile userProfile)
        {
            userProfile.UserCredentials.HashedPassword 
                = BCrypt.Net.BCrypt.HashPassword(userProfile.UserCredentials.HashedPassword);
            
            await _dataContext.AddAsync(userProfile);

            return await Save();
        }

        public async Task<UserProfile?> GetProfile(string userID)
        {
            return await _dataContext.UserProfiles.Where(p => p.UserID == userID).FirstOrDefaultAsync();
        }

        public async Task<List<UserProfile>> GetProfiles()
        {
            var userProfiles = await _dataContext.UserProfiles.OrderBy(p => p.FirstName).ToListAsync();
            return userProfiles;
        }

        public async Task<List<UserProfile>> GetProfilesBySearch(string searchInput, int range)
        {
            if (range == 4) 
            {
                return await _dataContext.UserProfiles.Where
                    (p => p.FirstName.Contains(searchInput) ||  
                    p.LastName.Contains(searchInput))
                    .OrderBy(p => p.FirstName).ToListAsync();
            }

            return await _dataContext.UserProfiles.Where
                (p => p.UserCredentials.Role.Contains(searchInput))
                .OrderBy(p => p.FirstName).ToListAsync();
        }

        public async Task<bool> ProfileExists(string userID)
        {
            return await _dataContext.UserProfiles.Where(p => p.UserID == userID).AnyAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync(); //this is when the actual sql is generated and executed in DB 
            return saved > 0;
        }

        public async Task<bool> UpdateUserProfile(UserProfile userProfile)
        {            
            await Task.Run(() => _dataContext.Update(userProfile));
            return await Save();
        }
    }
}
