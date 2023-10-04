using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSAMentorshipCompanionWebAPI.Models
{

    [PrimaryKey(nameof(ChatMessageId))]
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }

        [ForeignKey(nameof(ThreadId))]
        public int ThreadId { get; set; }

        public string Content { get; set; }

        public string SenderId { get; set; }

        public DateTime MessageTimeStamp { get; set; }
    }
}
