using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSAMentorshipCompanionWebAPI.Models
{
    [PrimaryKey(nameof(GoalId))]
    public class Goal
    {
        
        public int GoalId { get; set; }
        
        public int? MentorshipId { get; set; }
        [MaxLength(50)]
        public string StudentId { get; set; }

        public string GoalName { get; set;}
        public string GoalDescription { get; set;} = string.Empty;

        public DateTime? GoalDate { get; set; }
        public DateTime? Deadline { get; set; }

        public string Status { get; set; }
        
        public ChatThread? GoalThread { get; set; }


    }
}
