using Microsoft.EntityFrameworkCore;

namespace MSSAMentorshipCompanionWebAPI.Models
{
    [PrimaryKey(nameof(UserID))]
    public class UserCredentials
    {
        public string UserID { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get; set; }
        public string AccountStatus { get; set; }
        public bool NeedPasswordReset { get; set; }
        public UserProfile? UserProfile { get; set; }

    }
}
