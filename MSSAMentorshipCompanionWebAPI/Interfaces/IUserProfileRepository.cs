using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<List<UserProfile>> GetProfiles();

        Task<List<UserProfile>> GetProfilesBySearch(string searchInput, int range);

        Task<UserProfile?> GetProfile(string userID);

        Task<bool> ProfileExists(string userID);

        Task<bool> CreateUserProfile(UserProfile userProfile);

        Task<bool> UpdateUserProfile(UserProfile userProfile);
        Task<bool> Save();

    }
}
