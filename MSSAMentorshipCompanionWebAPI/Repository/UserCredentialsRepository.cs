using Microsoft.EntityFrameworkCore;
using MSSAMentorshipCompanionWebAPI.Data;
using MSSAMentorshipCompanionWebAPI.Interfaces;
using MSSAMentorshipCompanionWebAPI.Models;

namespace MSSAMentorshipCompanionWebAPI.Repository
{
    public class UserCredentialsRepository : IUserCredentialsRepository
    {
        private readonly DataContext _dataContext;
        public UserCredentialsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<UserCredentials?> GetUser(string userID)
        {
            var user = await _dataContext.UserCredentials.Where(p => p.UserID == userID).FirstOrDefaultAsync();
            return user;
        }

        public async Task<List<UserCredentials>> GetUsers() 
        {
            return await _dataContext.UserCredentials.OrderBy(p => p.UserID).ToListAsync();
        }

        public async Task<UserCredentials?> Authenticate(string email, string password)
        {
            UserCredentials? user = await _dataContext.UserCredentials.Where(p => p.EmailAddress == email).FirstOrDefaultAsync();
            //await Task.Run(() => { });
            if (user != null) 
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.HashedPassword))
                {
                    return user;
                }
            }            
            return null;
        }

        public async Task<bool> UserExists(string userID)
        {
            return await _dataContext.UserCredentials.AnyAsync(p => p.UserID == userID);
        }

        public async Task<bool> CreateUser(UserCredentials userCredentials)
        {
            //Notes from Teddy: Change Tracker: checking if its Add,Modify,Update
            // connected or disconnected
            // EntityState.Added mean this is a disconnected state
            //userCredentials.HashedPassword = BCrypt.Net.BCrypt.HashPassword(userCredentials.HashedPassword);
            
            await Task.Run(() => userCredentials.HashedPassword = BCrypt.Net.BCrypt.HashPassword(userCredentials.HashedPassword));
            await _dataContext.AddAsync(userCredentials);

            return await Save();
        }

        

        public async Task<bool> UpdatePassword(UserCredentials userCredentials, string updatedPassword)
        {
            userCredentials.HashedPassword = BCrypt.Net.BCrypt.HashPassword(updatedPassword);
            userCredentials.NeedPasswordReset = false;
            await Task.Run(() => _dataContext.Update(userCredentials));
            return await Save();
        }

        public async Task<bool> ResetPassword(UserCredentials userCredentials) 
        {
            userCredentials.HashedPassword = BCrypt.Net.BCrypt.HashPassword($"default.{userCredentials.UserID}");
            userCredentials.NeedPasswordReset = true;
            await Task.Run(() => _dataContext.Update(userCredentials));
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _dataContext.SaveChangesAsync(); //this is when the actual sql is generated and executed in DB 
            return saved > 0;
        }
    }
}
