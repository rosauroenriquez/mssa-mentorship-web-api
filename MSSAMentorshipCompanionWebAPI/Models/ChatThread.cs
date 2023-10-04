using Microsoft.EntityFrameworkCore;

namespace MSSAMentorshipCompanionWebAPI.Models
{
    [PrimaryKey(nameof(ThreadId))]
    public class ChatThread
    {
        public int ThreadId { get; set; }

        public List<ChatMessage> ChatMessages { get; set; }
    }
}
