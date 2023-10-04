using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSAMentorshipCompanionWebAPI.Models
{
    [PrimaryKey(nameof(UserID))]
    public class UserProfile
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LinkedInURL { get; set; }
        public string JobTitle { get; set; }
        public UserCredentials UserCredentials { get; set; }

    }
}
