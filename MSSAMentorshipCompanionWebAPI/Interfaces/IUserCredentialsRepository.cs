using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Interfaces
{
    public interface IUserCredentialsRepository
    {
        Task <List<UserCredentials>> GetUsers();
        Task <UserCredentials?> GetUser(string userID);

        Task<UserCredentials?> Authenticate(string email, string password);

        Task <bool> UserExists(string userID);

        Task <bool> CreateUser(UserCredentials userCredentials);
        Task <bool> UpdatePassword(UserCredentials userCredentials, string updatedPassword);

        Task <bool> ResetPassword(UserCredentials userCredentials);
        Task <bool> Save();
    }
}
