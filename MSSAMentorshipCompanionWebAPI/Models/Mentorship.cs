using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSAMentorshipCompanionWebAPI.Models
{
    [PrimaryKey(nameof(MentorshipId))]
    public class Mentorship
    {
        
        public int MentorshipId { get; set; }

        public string StudentID { get; set; }

        public string MentorID { get; set; }

        List<Goal> Goals { get; set; }

    }
}
